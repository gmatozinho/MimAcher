using System;
using System.Collections.Generic;
using System.Linq;
using Android.OS;

namespace MimAcher.Mobile.Entidades
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

        public string Campus { get; set; }


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
        }
        
        //Funções para trabalhar no banco de dados
        public void Commit()
        {
            CursorBD.Write(this);
        }

        public Dictionary<string, List<Participante>> Match()
        {
            var matchs = CursorBD.Match(this);

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
                ["campus"] = b.GetString("campus")
            };

            var p = new Participante(dictionary)
            {
                Hobbies = {Itens = b.GetStringArrayList("hobbies").ToList()},
                Aprender = {Itens = b.GetStringArrayList("aprender").ToList()},
                Ensinar = {Itens = b.GetStringArrayList("ensinar").ToList()}
            };

            return p;
        }

        //Função para utilizar Bundle e enviar objeto entre activities
        public Bundle ParticipanteToBundle()
        {
            var bundle = new Bundle();

            bundle.PutStringArrayList("hobbies", Hobbies.Itens);
            bundle.PutStringArrayList("aprender", Aprender.Itens);
            bundle.PutStringArrayList("ensinar", Ensinar.Itens);
            bundle.PutString("nome", Nome);
            bundle.PutString("campus", Campus);
            bundle.PutString("senha", Senha);
            bundle.PutString("email", Email);
            bundle.PutString("telefone", Telefone);
            bundle.PutString("nascimento", Nascimento);

            return bundle;
        }

    }
}