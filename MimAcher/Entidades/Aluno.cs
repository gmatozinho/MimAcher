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

namespace MimAcher.Entidades
{
    [Serializable]
    public class Aluno : Usuario
    {
        private List<string> gostos;
        private List<string> aprender;
        private List<string> ensinar;
        private string nome;
        private string nascimento;
        private string email;
        private string telefone;

        public static int TipoUsuario {
            get { return 1; }
        }

        //Properties
        public List<string> Gostos {
            get {
                return gostos;
            }

            private set {
                gostos = value;
            }
        }

        public List<string> Aprender {
            get {
                return aprender;
            }

            private set {
                aprender = value;
            }
        }

        public List<string> Ensinar {
            get {
                return ensinar;
            }

            private set {
                ensinar = value;
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

        public string Nascimento {
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
            Aprender = new List<string>();
            Ensinar = new List<string>();
            
            this.Nome = atributos["nome"];
            this.Nascimento = atributos["nascimento"];
            this.Email = atributos["email"];
            this.Telefone = atributos["telefone"];
        }


        //Adicionar strings individualmente
        public void adicionarGosto(string a)
        {
            Gostos.Add(a);
        }

        public void adicionarAprender(string a)
        {
            Aprender.Add(a);
        }

        public void adicionarEnsinar(string a)
        {
            Ensinar.Add(a);
        }

        //Remover strings individualmente
        public void removerGosto(string a)
        {
            Gostos.Remove(a);
        }

        public void removerAprender(string a)
        {
            Aprender.Remove(a);
        }

        public void removerEnsinar(string a)
        {
            Ensinar.Remove(a);
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

        //Função para utilizar Bundle e enviar objeto entre activities
        public Bundle toBundle()
        {
            Bundle b = new Bundle();

            b.PutString("nome", this.Nome);
            b.PutString("id", this.Id);
            b.PutString("senha", this.Senha);
            b.PutString("email", this.Email);
            b.PutString("telefone", this.Telefone);
            b.PutString("nascimento",this.Nascimento);

            return b;
        }
    }
}