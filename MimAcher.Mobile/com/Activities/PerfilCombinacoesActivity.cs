using System;
using Android.App;
using Android.OS;
using Android.Widget;
using MimAcher.Mobile.com.Activities.TAB;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;
using MimAcher.Mobile.com.Utilitarios;

namespace MimAcher.Mobile.com.Activities
{
    [Activity(Label = "PerfilCombinacoesActivity", Theme = "@style/Theme.Splash")]
    public class PerfilCombinacoesActivity : FabricaTelasComTab
    {
        //Variaveis globais
        private Participante _participante;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //Recebendo o bundle(Objeto participante)
            var participanteBundle = Intent.GetBundleExtra("member");
            _participante = Participante.BundleToParticipante(participanteBundle);

            //Tenho q montar este _participante

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.PerfilCombinacao);

            //Iniciando as variaveis do contexto
            var emailInfoUser = FindViewById<TextView>(Resource.Id.email_info_user);
            var telefoneInfoUser = FindViewById<TextView>(Resource.Id.tel_number_user);
            var dtNascimentoInfoUser = FindViewById<TextView>(Resource.Id.dt_nascimento_info_user);
            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));

            SetActionBar(toolbar);

            //Modificando a parte textual
            ActionBar.Title = _participante.Nome;
            ActionBar.SetLogo(Android.Resource.Drawable.ButtonRadio);
            ActionBar.SetIcon(Resource.Drawable.logo);
            telefoneInfoUser.Text = _participante.Telefone;
            dtNascimentoInfoUser.Text = _participante.Nascimento;
            emailInfoUser.Text = _participante.Email;

            PreencherPreferenciasParticipante();

            //Criando os tabs
            CreateTab(typeof(CombinacoesHobbiesActivity), GetString(Resource.String.TitleHobbies), _participante);
            CreateTab(typeof(CombinacoesAprenderActivity), GetString(Resource.String.TitleAprender), _participante);
            CreateTab(typeof(CombinacoesEnsinarActivity), GetString(Resource.String.TitleEnsinar), _participante);

        }

        private void PreencherPreferenciasParticipante()
        {
            //Obter lista de itens do sistema
            var itens = CursorBd.ObterItens();
            //Montar hobbies, aprender e ensinar
            var relacoesdoparticipantecomitens = CursorBd.ObterParticipanteItens(Convert.ToInt32(_participante.CodigoParticipante), itens);
            _participante.Hobbies.Conteudo = relacoesdoparticipantecomitens["hobbie"];
            _participante.Aprender.Conteudo = relacoesdoparticipantecomitens["aprender"];
            _participante.Ensinar.Conteudo = relacoesdoparticipantecomitens["ensinar"];
        }
        
    }
}