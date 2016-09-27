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
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);

            Bundle aluno_bundle = Intent.GetBundleExtra("aluno");
            Participante aluno = ParticipanteFactory.CriarParticipante(aluno_bundle);

            SetContentView(Resource.Layout.Resultado);

            Button nome_user = FindViewById<Button>(Resource.Id.nome_user);
            nome_user.Text = aluno.Nome;

            CreateTab(typeof(ResultGostosActivity), "gosto", "Gosto", Resource.Drawable.abc_tab_indicator_material);
            CreateTab(typeof(ResultAprenderActivity), "aprender", "Aprender", Resource.Drawable.abc_tab_indicator_material);
            CreateTab(typeof(ResultEnsinarActivity), "ensinar", "Ensinar", Resource.Drawable.abc_tab_indicator_material);

            nome_user.Click += delegate {
                var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                //mudar para trabalhar com objeto do banco
                editaractivity.PutExtra("aluno", aluno_bundle);
                StartActivity(editaractivity);
            };

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