using Android.App;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.com.Activities.TAB;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;

namespace MimAcher.Mobile.com.Activities
{
    [Activity(Label = "PerfilCombinacoesActivity", Theme = "@style/Theme.Splash")]
    public class PerfilCombinacoesActivity : FabricaTelasComTab
    {
        //Variaveis globais
        private Participante _participante;
        private PacoteAbstrato _pacote;

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
            telefoneInfoUser.Hint = _participante.Telefone;
            dtNascimentoInfoUser.Hint = _participante.Nascimento;

            //Criando os tabs
            CreateTab(typeof(ResultHobbiesActivity), GetString(Resource.String.TitleHobbies), _participante);
            CreateTab(typeof(ResultAprenderActivity), GetString(Resource.String.TitleAprender), _participante);
            CreateTab(typeof(ResultEnsinarActivity), GetString(Resource.String.TitleEnsinar), _participante);

        }

        //fazermenu
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_only_home, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_home:
                    _pacote = _participante;
                    IniciarHome(this, _pacote);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}