using System;
using System.Collections.Generic;
using System.Data;
using MimAcher.BancoDadosLocal.Conexao.Parametros;
using MimAcher.Mobile.com.Entidades;
using Npgsql;

namespace MimAcher.BancoDadosLocal.Conexao
{
    class CursorPostgres : CursorGenerico
    {
        public CursorPostgres()
        {
            string username = "postgres",
                                password = "ifes",
                                database = "mimacher";
            stringConexao = string.Format("Server = 127.0.0.1; User Id = {0};" +
                                                              "Password = {1}; Database = {2}; ",
                                                               username, password, database);
            conexao = new NpgsqlConnection(stringConexao);
            conexao.Open();

            BuscaCampi();
        }

        override
        public void InserirParticipante(Participante participante)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                    conexao.Open();

                NpgsqlCommand comandoSQL = new NpgsqlCommand("inserir_participante", (NpgsqlConnection) conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosParticipante(comandoSQL, participante, campi);

                comandoSQL.Prepare();
                NpgsqlDataReader leitor = comandoSQL.ExecuteReader();
                int codigo_participante = -1;
                while (leitor.Read())
                {
                    codigo_participante = Int32.Parse(leitor[0].ToString());
                }

                leitor.Close();
                leitor.Dispose();

                InserirConteudo(participante, codigo_participante);
            }

            catch (Exception ex)
            {
                Console.Write("Deu pau jovem: " + ex.Message);
            }
        }

        override
        public void InserirConteudo(Participante participante, int codigo_participante)
        {
            NpgsqlCommand comandoSQL;

            foreach (string hobbie in participante.Hobbies.Conteudo)
            {
                comandoSQL = new NpgsqlCommand("inserir_hobbie", (NpgsqlConnection) conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSQL, hobbie, codigo_participante);

                comandoSQL.ExecuteNonQuery();
            }

            foreach (string ensinar in participante.Ensinar.Conteudo)
            {
                comandoSQL = new NpgsqlCommand("inserir_ensinar", (NpgsqlConnection) conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSQL, ensinar, codigo_participante);

                comandoSQL.ExecuteNonQuery();
            }

            foreach (string aprender in participante.Aprender.Conteudo)
            {
                comandoSQL = new NpgsqlCommand("inserir_aprender", (NpgsqlConnection) conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSQL, aprender, codigo_participante);

                comandoSQL.ExecuteNonQuery();
            }
        }

        override
        protected void BuscaCampi()
        {
            campi = new Dictionary<string, int>();
            NpgsqlCommand comandoSQL = new NpgsqlCommand("SELECT local, cod_campus FROM ma_campus;", (NpgsqlConnection) conexao);
            NpgsqlDataReader leitor = comandoSQL.ExecuteReader();

            while (leitor.Read())
            {
                campi[leitor[0].ToString()] = Int32.Parse(leitor[1].ToString());
            }

            leitor.Close();
            leitor.Dispose();
        }
        
    }
}
