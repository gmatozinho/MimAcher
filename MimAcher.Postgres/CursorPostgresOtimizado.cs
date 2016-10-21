using MimAcher.Entidades;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MimAcher.Postgres
{
    class CursorPostgres
    {
        protected Dictionary<string, int> campi;
        protected static string username = "postgres",
                                password = "ifes",
                                database = "mimacher";
        protected static string stringConexao = string.Format("Server = 127.0.0.1; User Id = {0}; Password = {1}; Database = {2}; ",
                   username, password, database);
        protected NpgsqlConnection conexao;

        public CursorPostgres()
        {
            conexao = new NpgsqlConnection(stringConexao);
            if (conexao.State == System.Data.ConnectionState.Closed)
                conexao.Open();
            campi = new Dictionary<string, int>();
            NpgsqlCommand comandoSQL = new NpgsqlCommand("SELECT local, cod_campus FROM ma_campus;", conexao);
            NpgsqlDataReader leitor = comandoSQL.ExecuteReader();

            while (leitor.Read())
            {
                campi[leitor[0].ToString()] = Int32.Parse(leitor[1].ToString());
            }

            leitor.Close();
            leitor.Dispose();
        }

        public void InserirParticipante(Participante participante)
        {
            try
            {
                if (conexao.State == System.Data.ConnectionState.Closed)
                    conexao.Open();

                NpgsqlCommand comandoSQL = new NpgsqlCommand("inserir_participante", conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                var parametroFunction = comandoSQL.CreateParameter();
                parametroFunction.ParameterName = "nome_param";
                parametroFunction.DbType = System.Data.DbType.AnsiString;
                parametroFunction.Value = participante.Nome;
                comandoSQL.Parameters.Add(parametroFunction);

                parametroFunction = comandoSQL.CreateParameter();
                parametroFunction.ParameterName = "email_param";
                parametroFunction.DbType = System.Data.DbType.AnsiString;
                parametroFunction.Value = participante.Email;
                comandoSQL.Parameters.Add(parametroFunction);

                parametroFunction = comandoSQL.CreateParameter();
                parametroFunction.ParameterName = "senha_param";
                parametroFunction.DbType = System.Data.DbType.AnsiString;
                parametroFunction.Value = participante.Senha;
                comandoSQL.Parameters.Add(parametroFunction);

                parametroFunction = comandoSQL.CreateParameter();
                parametroFunction.ParameterName = "telefone_param";
                parametroFunction.DbType = System.Data.DbType.Int32;
                parametroFunction.Value = Int32.Parse(participante.Telefone);
                comandoSQL.Parameters.Add(parametroFunction);

                parametroFunction = comandoSQL.CreateParameter();
                parametroFunction.ParameterName = "nascimento_param";
                parametroFunction.DbType = System.Data.DbType.Date;
                parametroFunction.Value = participante.Nascimento;
                comandoSQL.Parameters.Add(parametroFunction);

                parametroFunction = comandoSQL.CreateParameter();
                parametroFunction.ParameterName = "campus_param";
                parametroFunction.DbType = System.Data.DbType.Int32;
                parametroFunction.Value = campi[participante.Campus];
                comandoSQL.Parameters.Add(parametroFunction);

                parametroFunction = comandoSQL.CreateParameter();
                parametroFunction.ParameterName = "codigo_participante";
                parametroFunction.Direction = ParameterDirection.ReturnValue;
                parametroFunction.DbType = System.Data.DbType.Int32;
                comandoSQL.Parameters.Add(parametroFunction);

                comandoSQL.Prepare();
                NpgsqlDataReader leitor = comandoSQL.ExecuteReader();
                int codigo_participante = -1;
                while (leitor.Read())
                {
                    codigo_participante = Int32.Parse(leitor[0].ToString());
                }

                leitor.Close();
                leitor.Dispose();

                foreach (string hobbie in participante.Hobbies.Itens)
                {
                    comandoSQL = new NpgsqlCommand("inserir_hobbie", conexao);
                    comandoSQL.CommandType = CommandType.StoredProcedure;

                    parametroFunction = comandoSQL.CreateParameter();
                    parametroFunction.ParameterName = "nome_item";
                    parametroFunction.DbType = System.Data.DbType.AnsiString;
                    parametroFunction.Value = hobbie;
                    comandoSQL.Parameters.Add(parametroFunction);

                    parametroFunction = comandoSQL.CreateParameter();
                    parametroFunction.ParameterName = "codigo_participante";
                    parametroFunction.DbType = System.Data.DbType.Int32;
                    parametroFunction.Value = codigo_participante;
                    comandoSQL.Parameters.Add(parametroFunction);

                    comandoSQL.ExecuteNonQuery();
                }
                foreach (string ensinar in participante.Ensinar.Itens)
                {
                    comandoSQL = new NpgsqlCommand("inserir_ensinar", conexao);
                    comandoSQL.CommandType = CommandType.StoredProcedure;

                    parametroFunction = comandoSQL.CreateParameter();
                    parametroFunction.ParameterName = "nome_item";
                    parametroFunction.DbType = System.Data.DbType.AnsiString;
                    parametroFunction.Value = ensinar;
                    comandoSQL.Parameters.Add(parametroFunction);

                    parametroFunction = comandoSQL.CreateParameter();
                    parametroFunction.ParameterName = "codigo_participante";
                    parametroFunction.DbType = System.Data.DbType.Int32;
                    parametroFunction.Value = codigo_participante;
                    comandoSQL.Parameters.Add(parametroFunction);

                    comandoSQL.ExecuteNonQuery();
                }
                foreach (string aprender in participante.Aprender.Itens)
                {
                    comandoSQL = new NpgsqlCommand("inserir_aprender", conexao);
                    comandoSQL.CommandType = CommandType.StoredProcedure;

                    parametroFunction = comandoSQL.CreateParameter();
                    parametroFunction.ParameterName = "nome_item";
                    parametroFunction.DbType = System.Data.DbType.AnsiString;
                    parametroFunction.Value = aprender;
                    comandoSQL.Parameters.Add(parametroFunction);

                    parametroFunction = comandoSQL.CreateParameter();
                    parametroFunction.ParameterName = "codigo_participante";
                    parametroFunction.DbType = System.Data.DbType.Int32;
                    parametroFunction.Value = codigo_participante;
                    comandoSQL.Parameters.Add(parametroFunction);

                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.Write("Deu pau jovem: " + ex.Message);
            }
        }
        public void Close()
        {
            conexao.Close();
        }
    }
}
