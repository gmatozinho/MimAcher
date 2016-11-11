﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.Activities;
using MimAcher.Mobile.Utilitarios;
using System.Threading.Tasks;

namespace MimAcher.Mobile.Entidades.Fabricas
{
    public class FabricaTelasComResultados : ListActivity, IFabricaTelas
    {
        //Variaveis globais
        protected List<string> Items;
        protected Participante Participante;

        public void IniciarHome(Context contexto, PacoteAbstrato pacote)
        {
            var resultadoctivity = new Intent(contexto, typeof(HomeActivity));
            IniciarOutraTela(resultadoctivity, pacote);
        }

        public void IniciarOutraTela(Intent activitydesejada, PacoteAbstrato pacote)
        {
            var participante = (Participante)pacote;
            activitydesejada.PutExtra("member", participante.ParticipanteToBundle());
            StartActivity(activitydesejada);
        }

        //Checa qual item foi clicado
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var itemSelecionado = Items[position];
            //Toast.MakeText(this, itemSelecionado, ToastLength.Short).Show();
            Mensagens.MensagemOpcoes(itemSelecionado,this);
        }

        internal void VerCombinacoes(string itemSelecionado)
        {
            //TODO pesquisar o item no banco, buscando as combinações
            Toast.MakeText(this, "Voce está na tela de exibição de combinações", ToastLength.Short).Show();
        }

        internal void RemoverItemSelecionado(string itemSelecionado)
        {
            Items.Remove(itemSelecionado);
            Participante.Aprender.Conteudo = Items;
            IniciarHome(this, Participante);
        }

        public void IniciarQueroAprenderActivity(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarQueroEnsinarActivity(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarHobbies(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarEditarPerfil(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarMain(Context contexto)
        {
            throw new NotImplementedException();
        }

        public Task IniciarInscrever()
        {
            throw new NotImplementedException();
        }

        public void IniciarEscolherFoto(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }

        public void IniciarAlterarSenha(Context contexto, PacoteAbstrato pacote)
        {
            throw new NotImplementedException();
        }
    }
}