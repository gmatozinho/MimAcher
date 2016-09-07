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
        private DateTime nascimento;
        private string email;
        private string telefone;

        public static int tipoUsuario = 1;

        //Properties
        public List<string> Gostos {
            get {
                return gostos;
            }

            private set {
                gostos = value;
            }
        }

        public List<string> Interesses {
            get {
                return interesses;
            }

            private set {
                interesses = value;
            }
        }

        public List<string> Competencias {
            get {
                return competencias;
            }

            private set {
                competencias = value;
            }
        }

        public string Nome {
            get {
                return nome;
            }

            set {
                nome = value;
            }
        }

        public DateTime Nascimento {
            get {
                return nascimento;
            }

            set {
                nascimento = value;
            }
        }

        public string Email {
            get {
                return email;
            }

            set {
                email = value;
            }
        }

        public string Telefone {
            get {
                return telefone;
            }

            set {
                telefone = value;
            }
        }


        //Construtor
        public Aluno(Dictionary<string, string> atributos) : base(atributos)
        {
            Gostos = new List<string>();
            Interesses = new List<string>();
            Competencias = new List<string>();
            
            this.Nome = atributos["nome"];
            this.Nascimento = DateTime.Parse(atributos["nascimento"]);
            this.Email = atributos["email"];
            this.Telefone = atributos["telefone"];
        }

        //Adicionar strings individualmente
        public void adicionarGosto(string a)
        {
            Gostos.Add(a);
        }

        public void adicionarInteresse(string a)
        {
            Interesses.Add(a);
        }

        public void adicionarCompetencia(string a)
        {
            Competencias.Add(a);
        }

        //Remover strings individualmente
        public void removerGosto(string a)
        {
            Gostos.Remove(a);
        }

        public void removerInteresse(string a)
        {
            Interesses.Remove(a);
        }

        public void removerCompetencia(string a)
        {
            Competencias.Remove(a);
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