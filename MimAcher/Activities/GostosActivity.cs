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

namespace MimAcher
{
    [Activity(Label = "GostosActivity", Theme = "@style/Theme.Splash")]
    public class GostosActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            //TODO ACERTAR OS OUTROS
            base.OnCreate(savedInstanceState);

            Bundle aluno_bundle = Intent.GetBundleExtra("aluno");
            Aluno aluno = AlunoFactory.CriarAluno(aluno_bundle);          

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Gostos);

            // Create your application here
            Button nome_user = FindViewById<Button>(Resource.Id.nome_user);
            Button ok = FindViewById<Button>(Resource.Id.ok);
            
            nome_user.Text = aluno.Nome;
            
            nome_user.Click += delegate {
                var editaractivity = new Intent(this, typeof(EditarPerfilActivity));
                //só falta atualizar
                editaractivity.PutExtra("aluno", aluno_bundle);
                StartActivity(editaractivity);
            };
            
            ok.Click += delegate {
                Dictionary<string, bool> Gostos = CriarDicionarioGostos();
                PreencherGostosAluno(Gostos, aluno);
                aluno.Commit();

                var queroaprenderactivity = new Intent(this, typeof(QueroAprenderActivity));
                //mudar para trabalhar com objeto do banco
                queroaprenderactivity.PutExtra("aluno", aluno_bundle);
                StartActivity(queroaprenderactivity);
            };

        }

        private Dictionary<string, bool> CriarDicionarioGostos()
        {
            //Checkbox Variables
            Dictionary<string, bool> Gostos = new Dictionary<string, bool>();
            CheckBox rock = FindViewById<CheckBox>(Resource.Id.rock);
            CheckBox games = FindViewById<CheckBox>(Resource.Id.games);
            CheckBox futebol = FindViewById<CheckBox>(Resource.Id.futebol);
            CheckBox pop = FindViewById<CheckBox>(Resource.Id.pop);
            CheckBox programacao = FindViewById<CheckBox>(Resource.Id.programacao);
            CheckBox empreender = FindViewById<CheckBox>(Resource.Id.empreender);
            CheckBox viajar = FindViewById<CheckBox>(Resource.Id.viajar);
            CheckBox analise_sistemas = FindViewById<CheckBox>(Resource.Id.analise_sistemas);

            Gostos.Add(rock.Text, rock.Checked);
            Gostos.Add(games.Text, games.Checked);
            Gostos.Add(futebol.Text, futebol.Checked);
            Gostos.Add(pop.Text, pop.Checked);
            Gostos.Add(programacao.Text, programacao.Checked);
            Gostos.Add(empreender.Text, empreender.Checked);
            Gostos.Add(viajar.Text, viajar.Checked);
            Gostos.Add(analise_sistemas.Text, analise_sistemas.Checked);

            return Gostos;
        }

        private void PreencherGostosAluno(Dictionary<string, bool> Gostos, Aluno aluno)
        {
            foreach (String strKey in Gostos.Keys)
            {
                if (Gostos[strKey])
                {
                    aluno.AdicionarGosto(strKey);
                }
            }
        }
    }
}