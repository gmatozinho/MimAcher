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
using static Android.Widget.TabHost;
using MimAcher.Entidades;

namespace MimAcher
{
    [Activity(Label = "ResultadoActivity", Theme = "@style/Theme.Splash")]
#pragma warning disable CS0618 // O tipo ou membro � obsoleto
    public class ResultadoActivity : TabActivity
#pragma warning restore CS0618 // O tipo ou membro � obsoleto
    {
        public Bundle participante_bundle;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            participante_bundle = Intent.GetBundleExtra("member");
            Participante participante = Participante.BundleToParticipante(participante_bundle);

            SetContentView(Resource.Layout.Resultado);

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            ActionBar.Title = participante.Nome;

            CreateTab(typeof(ResultGostosActivity), "gosto", "Gosto", Resource.Drawable.abc_tab_indicator_material);
            CreateTab(typeof(ResultAprenderActivity), "aprender", "Aprender", Resource.Drawable.abc_tab_indicator_material);
            CreateTab(typeof(ResultEnsinarActivity), "ensinar", "Ensinar", Resource.Drawable.abc_tab_indicator_material);

         
        }

        //Cria o menu de op��es
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

            var spec = TabHost.NewTabSpec(tag);
#pragma warning disable CS0618 // O tipo ou membro � obsoleto
            var drawableIcon = Resources.GetDrawable(drawableId);
#pragma warning restore CS0618 // O tipo ou membro � obsoleto
            spec.SetIndicator(label, drawableIcon);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }


    }

}