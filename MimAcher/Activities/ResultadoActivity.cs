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
using MimAcher.Activities.TAB;
using MimAcher.Entidades;
using com.refractored.fab;

namespace MimAcher
{
    [Activity(Label = "ResultadoActivity", Theme = "@style/Theme.Splash")]
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public class ResultadoActivity : TabActivity
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
    {
        private Bundle participante_bundle;
        private FloatingActionButton fab;
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            participante_bundle = Intent.GetBundleExtra("member");

            SetContentView(Resource.Layout.Resultado);
            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            //Toolbar will now take on default Action Bar characteristics
            //You can now use and reference the ActionBar
            SetActionBar(toolbar);

            ActionBar.Title = "Combinações";

            CreateTab(typeof(ResultHobbiesActivity), "hobbies", "Hobbies", Resource.Drawable.abc_tab_indicator_material);
            CreateTab(typeof(ResultAprenderActivity), "aprender", "Aprender", Resource.Drawable.abc_tab_indicator_material);
            CreateTab(typeof(ResultEnsinarActivity), "ensinar", "Ensinar", Resource.Drawable.abc_tab_indicator_material);

            FabOptions();           

        }

        private void FabOptions()
        {
            fab.Click += (s, arg) => {
                PopupMenu menu = new PopupMenu(this, fab);
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

                    if (intent != null)
                    {
                        intent.PutExtra("member", participante_bundle);
                        StartActivity(intent);
                    }
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

        //Define as funcionalidades destes menus
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.menu_search:
                    //do something
                    return true;
                case Resource.Id.menu_preferences:
                    //do something
                    var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                    //mudar para trabalhar com objeto do banco
                    editaractivity.PutExtra("member", participante_bundle);
                    StartActivity(editaractivity);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }




        private void CreateTab(Type activityType, string tag, string label, int drawableId)
        {
            var intent = new Intent(this, activityType);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.PutExtra("member", participante_bundle);
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
