using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using com.refractored.fab;
using MimAcher.Activities.TAB;
using Resource = MimAcher.Resources.Resource;

namespace MimAcher.Activities
{
    [Activity(Label = "ResultadoActivity", Theme = "@style/Theme.Splash")]
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public class ResultadoActivity : TabActivity
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
    {
        //Variaveis globais
        private Bundle _participanteBundle;
        private FloatingActionButton _fab;


        //Metodos do controlador
        //Cria e controla a activity
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            //Recebendo o bundle(Objeto participante)
            _participanteBundle = Intent.GetBundleExtra("member");

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Resultado);

            //Iniciando as variaveis do contexto
            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            _fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            SetActionBar(toolbar);

            //Modificando a parte textual
            ActionBar.Title = "Combinações";

            //Criando os tabs
            CreateTab(typeof(ResultHobbiesActivity), "hobbies", "Hobbies", Resource.Drawable.abc_tab_indicator_material);
            CreateTab(typeof(ResultAprenderActivity), "aprender", "Aprender", Resource.Drawable.abc_tab_indicator_material);
            CreateTab(typeof(ResultEnsinarActivity), "ensinar", "Ensinar", Resource.Drawable.abc_tab_indicator_material);

            //Iniciando o botão flutuante
            FabOptions();           

        }

        private void FabOptions()
        {
            _fab.Click += (s, arg) => {
                var menu = new PopupMenu(this, _fab);
                menu.Inflate(Resource.Drawable.button_result_menu);

                menu.MenuItemClick += (s1, arg1) =>
                {
                    Console.WriteLine("{0} selected", arg1.Item.TitleFormatted);
                    Intent intent = null;

                    switch (arg1.Item.TitleFormatted.ToString())
                    {
                        case "Hobbies":
                            intent = new Intent(this, typeof(HobbiesActivity));
                            break;
                        case "Aprender":
                            intent = new Intent(this, typeof(QueroAprenderActivity));
                            break;
                        case "Ensinar":
                            intent = new Intent(this, typeof(QueroEnsinarActivity));
                            break;
                    }

                    if (intent == null) return;
                    intent.PutExtra("member", _participanteBundle);
                    StartActivity(intent);
                };
                menu.Show();
            };

        }

        //Cria o menu de opções
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Drawable.top_menus_search, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        //Define as funcionalidades deste menu
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_search:
                    //do something
                    return true;
                case Resource.Id.menu_preferences:

                    var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                    editaractivity.PutExtra("member", _participanteBundle);
                    StartActivity(editaractivity);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        //Cria os tabs
        private void CreateTab(Type activityType, string tag, string label, int drawableId)
        {
            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.PutExtra("member", _participanteBundle);
            var spec = TabHost.NewTabSpec(tag);
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            var drawableIcon = Resources.GetDrawable(drawableId);
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            spec.SetIndicator(label, drawableIcon);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }
    }
}
