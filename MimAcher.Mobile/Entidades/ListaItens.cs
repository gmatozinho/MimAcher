using System.Collections.Generic;
using Android.Content;
using Android.Widget;

namespace MimAcher.Mobile.Entidades
{
    public class ListaItens
    {
        public List<string> Conteudo { get; set; }

        public ListaItens()
        {
            Conteudo = new List<string>();
        }

        //adicionar itens
        public void AdicionarItemWithMessage(string item, Context activity, string text)
        {
            if (!string.IsNullOrEmpty(item))
            {
                if (!Conteudo.Contains(item))
                {
                    Conteudo.Add(item);
                    var toast = string.Format("{1} Inserido: {0}", item, text);
                    Toast.MakeText(activity, toast, ToastLength.Long).Show();
                }
                else
                {
                    var toast = string.Format("Voce já possui este {1}: {0} ", item, text);
                    Toast.MakeText(activity, toast, ToastLength.Long).Show();
                }
            }
            else
            {
                const string toast = ("Nada Inserido");
                Toast.MakeText(activity, toast, ToastLength.Long).Show();
            }
        }

        public void AdicionarItem(string item)
        {
            if (!Conteudo.Contains(item) && !string.IsNullOrEmpty(item))
            {
                Conteudo.Add(item);
            }
        }

        public void AdicionarItem(string item, List<string> list)
        {
            if (!Conteudo.Contains(item) && !list.Contains(item) && !string.IsNullOrEmpty(item))
            {
                Conteudo.Add(item);
            }
        }

        public void Clear()
        {
            Conteudo = new List<string>();
        }

        //Remover itens
        public void RemoverItem(string item)
        {

            if (Conteudo.Contains(item))
            {
                Conteudo.Remove(item);
            }
        }
    }
}