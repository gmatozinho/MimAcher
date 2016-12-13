using System;
using System.Collections.Generic;
using System.Data;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Postgres.Conexao.Parametros;
using Npgsql;

namespace MimAcher.Postgres.Conexao
{
    class CursorPostgres : CursorGenerico
    {
        public CursorPostgres()
        {
            string username = "postgres",
                                password = "ifes",
                                database = "mimacher";
            StringConexao = string.Format("Server = 127.0.0.1; User Id = {0};" +
                                                              "Password = {1}; Database = {2}; ",
                                                               username, password, database);
            Conexao = new NpgsqlConnection(StringConexao);
            Conexao.Open();

            BuscaCampi();
        }

        override
        public void InserirParticipante(Participante participante)
        {
            try
            {
                if (Conexao.State == ConnectionState.Closed)
                    Conexao.Open();

                NpgsqlCommand comandoSql = new NpgsqlCommand("inserir_participante", (NpgsqlConnection) Conexao);
                comandoSql.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosParticipante(comandoSql, participante, Campi);

                comandoSql.Prepare();
                NpgsqlDataReader leitor = comandoSql.ExecuteReader();
                int codigoParticipante = -1;
                while (leitor.Read())
                {
                    codigoParticipante = Int32.Parse(leitor[0].ToString());
                }

                leitor.Close();
                leitor.Dispose();

                InserirConteudo(participante, codigoParticipante);
            }

            catch (Exception ex)
            {
                Console.Write("Deu pau jovem: " + ex.Message);
            }
        }

        override
        public void InserirConteudo(Participante participante, int codigoParticipante)
        {
            NpgsqlCommand comandoSql;

            foreach (string hobbie in participante.Hobbies.Conteudo)
            {
                comandoSql = new NpgsqlCommand("inserir_hobbie", (NpgsqlConnection) Conexao);
                comandoSql.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSql, hobbie, codigoParticipante);

                comandoSql.ExecuteNonQuery();
            }

            foreach (string ensinar in participante.Ensinar.Conteudo)
            {
                comandoSql = new NpgsqlCommand("inserir_ensinar", (NpgsqlConnection) Conexao);
                comandoSql.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSql, ensinar, codigoParticipante);

                comandoSql.ExecuteNonQuery();
            }

            foreach (string aprender in participante.Aprender.Conteudo)
            {
                comandoSql = new NpgsqlCommand("inserir_aprender", (NpgsqlConnection) Conexao);
                comandoSql.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSql, aprender, codigoParticipante);

                comandoSql.ExecuteNonQuery();
            }
        }

        override
        protected void BuscaCampi()
        {
            Campi = new Dictionary<string, int>();
            NpgsqlCommand comandoSql = new NpgsqlCommand("SELECT local, cod_campus FROM ma_campus;", (NpgsqlConnection) Conexao);
            NpgsqlDataReader leitor = comandoSql.ExecuteReader();

            while (leitor.Read())
            {
                Campi[leitor[0].ToString()] = Int32.Parse(leitor[1].ToString());
            }

            leitor.Close();
            leitor.Dispose();
        }
        
    }
}
