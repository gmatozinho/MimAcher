using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MimAcher.SourceCode
{
    public class Aluno : Usuario
    {
        private List<string> gostos;
        private List<string> interesses;
        private List<string> competencias;
        private string nome;
        private int idade;
        private string email;
        private string telefone;
        //private Geography localizacao;

        public static int tipoUsuario = 1;
        
        internal List<string> Gostos
        {
            get
            {
                return gostos;
            }
        }

        internal List<string> Interesses
        {
            get
            {
                return interesses;
            }
        }

        internal List<string> Competencias
        {
            get
            {
                return competencias;
            }
        }

        //Construtor
        public Aluno(string id, string senha, string nome, int idade, string email, string telefone/*, geography localizacao*/) : base(id, senha)
        {
            gostos = new List<string>();
            interesses = new List<string>();
            competencias = new List<string>();
            this.nome = nome;
            this.idade = idade;
            this.email = email;
            this.telefone = telefone;
            //this.localizacao = localizacao;
        }

        //Adicionar strings individualmente
        public void addGosto(string a)
        {
            gostos.Add(a);
        }
        public void addInteresse(string a)
        {
            interesses.Add(a);
        }
        public void addCompetencia(string a)
        {
            competencias.Add(a);
        }

        //Remover strings individualmente
        public void removeGosto(string a)
        {
            gostos.Remove(a);
        }
        public void removeInteresse(string a)
        {
            interesses.Remove(a);
        }
        public void removeCompetencia(string a)
        {
            competencias.Remove(a);
        }

        //Funções para trabalhar no banco de dados
        public void commit()
        {
            Cursor.write(this);
        }

        public Dictionary<string, List<Aluno>> match()
        {
            Dictionary<string, List<Aluno>> matchs = Cursor.match(this);

            return matchs;
        }
    }
}