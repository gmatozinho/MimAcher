using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;
using MimAcher.Mobile.com.Utilitarios;

namespace MimAcher.Mobile.com.Entidades
{
    [Serializable]
    public class Participante : Usuario
    {
        //Properties
        public ListaItens Hobbies { get; set;}
        

        public ListaItens Aprender {get; set;}
        

        public ListaItens Ensinar { get; set; }
        

        public string Nome { get; set; }

        public string Nascimento { get; set; }
        
        public string Telefone { get; set; }

        public string Campus { get; }

        public string Localizacao { get; set; }


        //Construtor
        public Participante(Dictionary<string, string> atributos) : base(atributos)
        {
            Hobbies = new ListaItens();
            Aprender = new ListaItens();
            Ensinar = new ListaItens();

            Nome = atributos["nome"];
            Nascimento = atributos["nascimento"];
            Telefone = atributos["telefone"];
            Campus = atributos["campus"];
            Localizacao = atributos["localizacao"];
        }
        
        //Funções para trabalhar no banco de dados
        public int Inscrever()
        {
            return CursorBd.CadastrarParcipante(this);
        }


        public Dictionary<string, List<Participante>> Match()
        {
            var matchs = CursorBd.Match(this);

            return matchs;
        }


        public static Participante BundleToParticipante(Bundle b)
        {
            var dictionary = new Dictionary<string, string>
            {
                ["email"] = b.GetString("e_mail"),
                ["nome"] = b.GetString("nome"),
                ["campus"] = b.GetString("campus"),
                ["senha"] = b.GetString("senha"),
                ["nascimento"] = b.GetString("nascimento"),
                ["telefone"] = b.GetString("telefone"),
                ["campus"] = b.GetString("campus"),
                ["localizacao"] = b.GetString("localizacao")
            };

            var p = new Participante(dictionary)
            {
                Hobbies = {Conteudo = b.GetStringArrayList("hobbie").ToList()},
                Aprender = {Conteudo = b.GetStringArrayList("aprender").ToList()},
                Ensinar = {Conteudo = b.GetStringArrayList("ensinar").ToList()}
            };

            return p;
        }

        //Função para utilizar Bundle e enviar objeto entre activities
        public Bundle ParticipanteToBundle()
        {
            var bundle = new Bundle();

            bundle.PutStringArrayList("hobbie", Hobbies.Conteudo);
            bundle.PutStringArrayList("aprender", Aprender.Conteudo);
            bundle.PutStringArrayList("ensinar", Ensinar.Conteudo);
            bundle.PutString("nome", Nome);
            bundle.PutString("campus", Campus);
            bundle.PutString("senha", Senha);
            bundle.PutString("email", Email);
            bundle.PutString("telefone", Telefone);
            bundle.PutString("nascimento", Nascimento);
            bundle.PutString("localizacao",Localizacao);

            return bundle;
        }


    }
}