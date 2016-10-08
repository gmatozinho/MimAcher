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
using MimAcher.Entidades;

namespace MimAcher.Entidades
{
    public class ListaItens
    {
        public List<string> Itens { get; set; }

        public ListaItens()
        {
           Itens = new List<string>();            
        }

        //adicionar itens
        public void AdicionarItem(string item, Context activity, string text)
        {
            if (item != "" && item != null)
            {
                if (!Itens.Contains(item))
                {
                    Itens.Add(item);
                    string toast = string.Format("{1} Inserido: {0}", item,text);
                    Toast.MakeText(activity, toast, ToastLength.Long).Show();
                }
                else
                {
                    string toast = string.Format("Voce já possui este {1}: {0} ", item,text);
                    Toast.MakeText(activity, toast, ToastLength.Long).Show();
                }
            }else
            {
                string toast = string.Format("Nada Inserido");
                Toast.MakeText(activity, toast, ToastLength.Long).Show();
            }
        }

        //Remover itens
        public void RemoverItem(string item)
        {

            if (Itens.Contains(item))
            {
                Itens.Remove(item);
            }
        }

        

    }
}