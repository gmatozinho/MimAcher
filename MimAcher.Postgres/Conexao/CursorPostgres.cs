﻿using System;
using System.Collections.Generic;
using System.Data;
using MimAcher.Mobile.Entidades;
using MimAcher.Postgres.Conexao.Parametros;
using Npgsql;

namespace MimAcher.Postgres.Conexao
{
    class CursorPostgres
    {
        private Dictionary<string, int> campi;
        private static string username = "postgres",
                                password = "ifes",
                                database = "mimacher";

        private static string stringConexao = string.Format("Server = 127.0.0.1; User Id = {0};" + 
                                                              "Password = {1}; Database = {2}; ",
                                                               username, password, database);
        private readonly NpgsqlConnection conexao;

        public CursorPostgres()
        {
            conexao = new NpgsqlConnection(stringConexao);
            conexao.Open();

            BuscaCampi();
        }

        public void InserirParticipante(Participante participante)
        {
            try
            {
                if (conexao.State == ConnectionState.Closed)
                    conexao.Open();

                NpgsqlCommand comandoSQL = new NpgsqlCommand("inserir_participante", conexao);
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

        public void InserirConteudo(Participante participante, int codigo_participante)
        {
            NpgsqlCommand comandoSQL;

            foreach (string hobbie in participante.Hobbies.Conteudo)
            {
                comandoSQL = new NpgsqlCommand("inserir_hobbie", conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSQL, hobbie, codigo_participante);

                comandoSQL.ExecuteNonQuery();
            }

            foreach (string ensinar in participante.Ensinar.Conteudo)
            {
                comandoSQL = new NpgsqlCommand("inserir_ensinar", conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSQL, ensinar, codigo_participante);

                comandoSQL.ExecuteNonQuery();
            }

            foreach (string aprender in participante.Aprender.Conteudo)
            {
                comandoSQL = new NpgsqlCommand("inserir_aprender", conexao);
                comandoSQL.CommandType = CommandType.StoredProcedure;

                FabricaParametros.CriarParametrosItem(comandoSQL, aprender, codigo_participante);

                comandoSQL.ExecuteNonQuery();
            }
        }

        public void Close()
        {
            conexao.Close();
        }

        private void BuscaCampi()
        {
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
        
    }
}
