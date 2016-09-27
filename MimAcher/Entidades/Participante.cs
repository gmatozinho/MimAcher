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
    public class Participante : Usuario
    {
        public static int TipoUsuario {
            get { return 1; }
        }

        //Properties
        public List<string> Gostos { get; set;}
        

        public List<string> Aprender {get; set;}
        

        public List<string> Ensinar { get; set; }
        

        public string Nome { get; set; }

        public string Nascimento { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }


        //Construtor
        public Participante(Dictionary<string, string> atributos) : base(atributos)
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
        public void AdicionarGosto(string a)
        {
            Gostos.Add(a);
        }

        public void AdicionarAprender(string a)
        {
            Aprender.Add(a);
        }

        public void AdicionarEnsinar(string a)
        {
            Ensinar.Add(a);
        }

        //Remover strings individualmente
        public void RemoverGosto(string a)
        {
            Gostos.Remove(a);
        }

        public void RemoverAprender(string a)
        {
            Aprender.Remove(a);
        }

        public void RemoverEnsinar(string a)
        {
            Ensinar.Remove(a);
        }

        //Funções para trabalhar no banco de dados
        public void Commit()
        {
            Cursor.Write(this);
        }

        public Dictionary<string, List<Participante>> Match()
        {
            Dictionary<string, List<Participante>> matchs = Cursor.Match(this);

            return matchs;
        }

        //Função para utilizar Bundle e enviar objeto entre activities
        public Bundle ToBundle()
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