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

        public void PreencherItensParticipante(List<string> itens, ListaItens lista)
        {
            foreach (string item in itens)
            {
                if (!lista.Itens.Contains(item))
                {
                    lista.Itens.Add(item);
                }
            }
        }


        //Funções para trabalhar no banco de dados
        public void Commit()
        {
            CursorBD.Write(this);
        }

        public Dictionary<string, List<Participante>> Match()
        {
            Dictionary<string, List<Participante>> matchs = CursorBD.Match(this);

            return matchs;
        }

        public static Participante BundleToParticipante(Bundle b)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();

            

            dictionary["email"] = b.GetString("e_mail");
            dictionary["nome"] = b.GetString("nome");
            dictionary["campus"] = b.GetString("campus");
            dictionary["senha"] = b.GetString("senha");
            dictionary["nascimento"] = b.GetString("nascimento");
            dictionary["telefone"] = b.GetString("telefone");
            dictionary["campus"] = b.GetString("campus");

            Participante p = new Participante(dictionary);

            p.Hobbies.Itens = b.GetStringArrayList("hobbies").ToList();
            p.Aprender.Itens = b.GetStringArrayList("aprender").ToList();
            p.Ensinar.Itens = b.GetStringArrayList("ensinar").ToList();

            return p;
        }

        //Função para utilizar Bundle e enviar objeto entre activities
        public Bundle ParticipanteToBundle()
        {
            Bundle bundle = new Bundle();

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