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

                var parameter = comandoSQL.CreateParameter();
                parameter.ParameterName = "nome_param";
                parameter.DbType = System.Data.DbType.AnsiString;
                parameter.Value = participante.Nome;
                comandoSQL.Parameters.Add(parameter);
                
                parameter = comandoSQL.CreateParameter();
                parameter.ParameterName = "email_param";
                parameter.DbType = System.Data.DbType.AnsiString;
                parameter.Value = participante.Email;
                comandoSQL.Parameters.Add(parameter);

                parameter = comandoSQL.CreateParameter();
                parameter.ParameterName = "senha_param";
                parameter.DbType = System.Data.DbType.AnsiString;
                parameter.Value = participante.Senha;
                comandoSQL.Parameters.Add(parameter);

                parameter = comandoSQL.CreateParameter();
                parameter.ParameterName = "telefone_param";
                parameter.DbType = System.Data.DbType.Int32;
                parameter.Value = Int32.Parse(participante.Telefone);
                comandoSQL.Parameters.Add(parameter);

                parameter = comandoSQL.CreateParameter();
                parameter.ParameterName = "nascimento_param";
                parameter.DbType = System.Data.DbType.Date;
                parameter.Value = participante.Nascimento;
                comandoSQL.Parameters.Add(parameter);

                parameter = comandoSQL.CreateParameter();
                parameter.ParameterName = "campus_param";
                parameter.DbType = System.Data.DbType.AnsiString;
                parameter.Value = participante.Campus;
                comandoSQL.Parameters.Add(parameter);

                comandoSQL.ExecuteNonQuery();

                foreach (string hobbie in participante.Hobbies.Itens)
                {

                }
                foreach (string ensinar in participante.Ensinar.Itens)
                {

                }
                foreach (string hobbie in participante.Aprender.Itens)
                {

                }
            }
            catch
            {

            }
        }
    }
}
