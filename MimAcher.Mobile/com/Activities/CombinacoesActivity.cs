using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using MimAcher.Mobile.com.Activities.TAB;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Utilitarios;

namespace MimAcher.Mobile.com.Activities
{
    [Activity(Label = "Combinacoes", Theme = "@style/Theme.Splash")]
    public class CombinacoesActivity : ListActivity
    {
        //Variaveis globais
        protected List<Participante> Participantes;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //tenho q receber o item para gerar as combinações a serem geradas
            var codItem = Intent.GetIntExtra("item",0);
            var tipoCombinacao = Intent.GetStringExtra("tipocombinacao");
            var codParticipanteAtivo = Intent.GetIntExtra("codParticipanteAtivo", 0);

            //Exibindo o layout .axml
            SetContentView(Resource.Layout.Combinacoes);

            //Iniciando as variaveis do contexto
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetActionBar(toolbar);
            var itemSelecionado = ObterNomeItem(codItem);

            //Modificando a parte textual
            ActionBar.SetTitle(Resource.String.TitleCombinacoes);
            
            //combinacoes
            var combinacoesCod = CursorBd.Match(codItem,codParticipanteAtivo);
            var combinacaoDecisao = TratarTipoCombinacao(tipoCombinacao);
            ActionBar.Subtitle = combinacaoDecisao + " : " + itemSelecionado;
            Participantes = ObterParticipantes(combinacoesCod[combinacaoDecisao]);

            ListAdapter = new ListAdapterParticipante(this, Participantes);

        }

        private static string TratarTipoCombinacao(string tipoCombinacao)
        {
            var combinacaoTipo = "";

            if (tipoCombinacao == typeof(ResultHobbiesActivity).ToString())
            {
                combinacaoTipo =  "hobbie";
            }else if (tipoCombinacao == typeof(ResultAprenderActivity).ToString())
            {
                combinacaoTipo =  "aprender";
            }else if (tipoCombinacao == typeof(ResultEnsinarActivity).ToString())
            {
                combinacaoTipo = "ensinar";
            }

            return combinacaoTipo;

        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var participanteSelecionado = Participantes[position];
            var perfilcombinacaoctivity = new Intent(this, typeof(PerfilCombinacoesActivity));
            perfilcombinacaoctivity.PutExtra("member", participanteSelecionado.ParticipanteToBundle());
            StartActivity(perfilcombinacaoctivity);
        }

        private static List<Participante> ObterParticipantes(IEnumerable<int> participantesCod)
        {
            return participantesCod.Select(CursorBd.ObterDadosParticipante).ToList();
        }

        private string ObterNomeItem(int codItem)
        {
            var itens = CursorBd.ObterItens();
            if (codItem != 0) return itens[codItem];
            const string toast = ("Error");
            Toast.MakeText(this, toast, ToastLength.Long).Show();
            return itens[codItem];
        }

       
    }
}