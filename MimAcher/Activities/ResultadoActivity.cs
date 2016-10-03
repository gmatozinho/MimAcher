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
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
    public class ResultadoActivity : TabActivity
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
    {
        public Bundle aluno_bundle;

        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            Bundle aluno_bundle = Intent.GetBundleExtra("aluno");
            Participante aluno = ParticipanteFactory.CriarParticipante(aluno_bundle);

            SetContentView(Resource.Layout.Resultado);

            var toolbar = FindViewById<Toolbar>((Resource.Id.toolbar));
            //Toolbar will now take on default Action Bar characteristics
            SetActionBar(toolbar);
            //You can now use and reference the ActionBar
            ActionBar.Title = aluno.Nome;

            CreateTab(typeof(ResultGostosActivity), "gosto", "Gosto", Resource.Drawable.abc_tab_indicator_material);
            CreateTab(typeof(ResultAprenderActivity), "aprender", "Aprender", Resource.Drawable.abc_tab_indicator_material);
            CreateTab(typeof(ResultEnsinarActivity), "ensinar", "Ensinar", Resource.Drawable.abc_tab_indicator_material);

         
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
                    editaractivity.PutExtra("aluno", aluno_bundle);
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
#pragma warning disable CS0618 // O tipo ou membro é obsoleto
            var drawableIcon = Resources.GetDrawable(drawableId);
#pragma warning restore CS0618 // O tipo ou membro é obsoleto
            spec.SetIndicator(label, drawableIcon);
            spec.SetContent(intent);

            TabHost.AddTab(spec);
        }


    }

}