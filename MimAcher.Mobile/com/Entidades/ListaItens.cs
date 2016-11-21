using System.Collections.Generic;
using Android.Content;
using MimAcher.Mobile.com.Utilitarios;

namespace MimAcher.Mobile.com.Entidades
{
    public class ListaItens
    {
        public List<string> Conteudo { get; set; }

        public ListaItens()
        {
            Conteudo = new List<string>();
        }

        //adicionar itens
        public void AdicionarItemComMensagem(string item, Context activity, string text)
        {
            if (!string.IsNullOrEmpty(item))
            {
                if (!Conteudo.Contains(item))
                {
                    Conteudo.Add(item);
                    Mensagens.MensagemDeAdicionarItemSucesso(item,activity,text);
                }
                else
                {
                    Mensagens.MensagemDeAdicionarItemFalha(item,activity,text);
                }
            }
            else
            {
                Mensagens.MensagemDeAdicionarItemNadaInserido(activity);
            }
        }

        public void AdicionarItemParaGerador(string item)
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