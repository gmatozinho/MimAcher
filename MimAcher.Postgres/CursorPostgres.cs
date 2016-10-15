using MimAcher.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace MimAcher.Postgres
{ 
    internal class CursorPostgres
    {
        string server = "localhost", 
               port = "5432",
               userId = "postgres",
               password = "ifes", 
               database = "mimacher";

        public void InserirParticipante(Participante participante)
        {
            try
            {
                string stringConexao = string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};",
                    server, port, userId, password, database);

                NpgsqlConnection conexao = new NpgsqlConnection(stringConexao);
                conexao.Open();

                string comandoSql = "INSERT INTO participante(nome, email, senha, campus, nascimento, telefone " +
                    "VALUES ({0}, {1}, {2}, {3}, {4}, {5});";
                string.Format(comandoSql, participante.Nome, participante.Email, participante.Senha, participante.Campus,
                              participante.Nascimento, participante.Telefone);
                
                NpgsqlCommand comandoPostgres = new NpgsqlCommand();
                comandoPostgres.CommandText = comandoSql;
                comandoPostgres.ExecuteNonQuery();

                foreach(string hobbie in participante.Hobbies.Itens)
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
