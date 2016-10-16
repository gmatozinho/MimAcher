using MimAcher.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Data;

namespace MimAcher.Postgres
{ 
    internal class CursorPostgres
    {
        string username = "postgres",
               password = "ifes", 
               database = "mimacher";

        public void InserirParticipante(Participante participante)
        {
            try
            {
                string stringConexao = string.Format("Server = 127.0.0.1; User Id = {0}; Password = {1}; Database = {2}; ",
                    username, password, database);

                NpgsqlConnection conexao = new NpgsqlConnection(stringConexao);
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
                parametroFunction.DbType = System.Data.DbType.AnsiString;
                parametroFunction.Value = participante.Campus;
                comandoSQL.Parameters.Add(parametroFunction);

                comandoSQL.ExecuteNonQuery();

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
                    parametroFunction.ParameterName = "email_participante";
                    parametroFunction.DbType = System.Data.DbType.AnsiString;
                    parametroFunction.Value = participante.Email;
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
                    parametroFunction.ParameterName = "email_participante";
                    parametroFunction.DbType = System.Data.DbType.AnsiString;
                    parametroFunction.Value = participante.Email;
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
                    parametroFunction.ParameterName = "email_participante";
                    parametroFunction.DbType = System.Data.DbType.AnsiString;
                    parametroFunction.Value = participante.Email;
                    comandoSQL.Parameters.Add(parametroFunction);

                    comandoSQL.ExecuteNonQuery();
                }
            }
            catch
            {

            }
        }
    }
}
