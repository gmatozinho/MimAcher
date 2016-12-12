using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Widget;
using MimAcher.Mobile.com.Activities;
using MimAcher.Mobile.com.Activities.TAB;
using MimAcher.Mobile.com.Entidades;
using MimAcher.Mobile.com.Entidades.Fabricas;

namespace MimAcher.Mobile.com.Utilitarios
{
    public static class Mensagens
    {
        internal static void MensagemDeInformacaoInvalidaPadrao(Context contexto, string informacao)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Dado Inv�lido: " + informacao);
            alert.SetMessage("Por favor, tente novamente");
            alert.SetPositiveButton("Ok", (senderAlert, args) => { });
            alert.Show();
        }

        internal static void MensagemDeInformacoesEditadasComSucesso(Context contexto)
        {
            const string toast = "Suas informa��es foram alteradas com sucesso";
            Toast.MakeText(contexto, toast, ToastLength.Long).Show();
        }

        internal static void MensagemDeAdicionarItemSucesso(string item,Context activity, string text)
        {
            var toast = string.Format("{1} Inserido: {0}", item, text);
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        internal static void MensagemDeAdicionarItemFalha(string item, Context activity, string text)
        {
            var toast = string.Format("Voce j� possui este {1}: {0} ", item, text);
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        internal static void MensagemDeAdicionarItemNadaInserido(Context activity)
        {
            const string toast = ("Nada Inserido");
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        internal static void MensagemDeConfirmarSenhaInvalido(Context contexto)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("As senhas n�o conferem!");
            alert.SetMessage("Por favor corrija para podermos realizar seu cadastro");
            alert.SetPositiveButton("Ok", (senderAlert, args) => { });
            alert.Show();
        }

        internal static void MensagemDeSenhaInvalida(Context contexto)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Senha Invalida");
            alert.SetMessage("A senha deve ser composta de no min�mo 8 caracteres");
            alert.SetPositiveButton("Ok", (senderAlert, args) => {
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
        
        internal static void MensagemParaRegistrarGeolocalizacao(Context contexto, Participante participante)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Voc� deseja registrar sua localiza��o?");
            alert.SetMessage(
                "Registre para gente o local onde voc� mora para que possamos sugerir as pessoas que est�o mais pr�ximas de voc�.");

            alert.SetPositiveButton("Sim", async (senderAlert, args) =>
            {
                Toast.MakeText(contexto, "Sua localiza��o ser� registrada!", ToastLength.Short).Show();
                participante.Localizacao = await Geolocalizacao.CapturarLocalizacao();
                CursorBd.AtualizarParticipante(participante);
            });

            alert.SetNegativeButton("N�o", (sender, args) => Toast.MakeText(contexto, "Sua localiza��o n�o ser� registrada", ToastLength.Short).Show());

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        internal static void MensagemDeDataInvalida(Context contexto)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Data de Nascimento Invalida");
            alert.SetMessage("A Data de Nascimento deve estar de acordo com o modelo: 30/06/2002");
            alert.SetPositiveButton("Ok", (senderAlert, args) => {
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        internal static void MensagemDeLogout(Context contexto, HomeActivity home)
        {
            var alert = new AlertDialog.Builder(contexto);
            alert.SetTitle("Deseja realizar Logout");
            alert.SetPositiveButton("Ok", (senderAlert, args) =>
            {
                home.Logout();
            });

            alert.SetNegativeButton("Cancelar", (sender, args) =>
            {
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }

        internal static void MensagemOpcoes(List<string> listNomeCodItem,int codParticipanteAtivo, FabricaTelasComResultados telaResultados)
        {
            var codItemSelecionado = Convert.ToInt32(listNomeCodItem[0]);
            var alert = new AlertDialog.Builder(telaResultados);
            alert.SetTitle("Op��es");
            alert.SetMessage("Voc� deseja remover o item ou consultar combina��es?");
            alert.SetPositiveButton("Ver Combina��es", (senderAlert, args) =>
            {
                telaResultados.VerCombinacoes(codItemSelecionado, codParticipanteAtivo, telaResultados);
            });
            alert.SetNegativeButton("Remover", (senderAlert, args) =>
            {
                MensagemParaRemoverItemSelecionado(listNomeCodItem,codParticipanteAtivo, telaResultados);
            });
            alert.Show();
        }

        private static void MensagemParaRemoverItemSelecionado(IReadOnlyList<string> listNomeCodItem, int codParticipanteAtivo, FabricaTelasComResultados telaResultados)
        {
            var codItemSelecionado = Convert.ToInt32(listNomeCodItem[0]);
            var itemSelecionado = listNomeCodItem[1];
            var tipoRelacao = telaResultados.GetType().ToString();

            var alert = new AlertDialog.Builder(telaResultados);
            alert.SetTitle("Remover!");
            alert.SetMessage("Voc� tem certeza que deseja remover?\n\n" + itemSelecionado);
            alert.SetPositiveButton("Ok", (senderAlert, args) =>
            {
                RemoverRelacao(tipoRelacao,codItemSelecionado,codParticipanteAtivo);
                Toast.MakeText(telaResultados, itemSelecionado + " foi exlu�do!", ToastLength.Short).Show();
                telaResultados.RemoverItemSelecionado(itemSelecionado);
            });
            alert.SetNegativeButton("Cancelar", (senderAlert, args) =>
            {
                Toast.MakeText(telaResultados, itemSelecionado + " n�o ser� removido!", ToastLength.Short).Show();
            });
            alert.Show();
        }

        internal static void MensagemServidorOnline(Context activity)
        {
            const string toast = "Servidor Online";
            Toast.MakeText(activity, toast, ToastLength.Long).Show();
        }

        internal static void MensagemServidorOffline(Context activity)
        {
            var alert = new AlertDialog.Builder(activity);
            alert.SetTitle("Notifica��o:");
            alert.SetMessage("Desculpe o transtorno, estamos enfrentando problemas com o servidor, tente novamente mais tarde.");
            alert.SetPositiveButton("Ok", (senderAlert, args) => { });
            alert.Show();
        }

        internal static void MensagemInternetDesativada(Context activity)
        {
            var alert = new AlertDialog.Builder(activity);
            alert.SetTitle("Notifica��o:");
            alert.SetMessage("Por favor verifique se algum servi�o de internet est� ligado");
            alert.SetPositiveButton("Ok", (senderAlert, args) => { });
            alert.Show();
        }

        internal static void MensagemInternetAtivadaMasComProblema(Context activity)
        {
            var alert = new AlertDialog.Builder(activity);
            alert.SetTitle("Notifica��o:");
            alert.SetMessage("Por favor verifique sua conex�o com a internet!");
            alert.SetPositiveButton("Ok", (senderAlert, args) => { });
            alert.Show();
        }

        internal static void MensagemErroLogin(Context context)
        {
            var alert = new AlertDialog.Builder(context);
            alert.SetTitle("Falha ao Logar!");
            alert.SetMessage("Usu�rio ou senha incorretos");
            alert.SetPositiveButton("Ok", (senderAlert, args) => { });
            alert.Show();
        }

        internal static void MensagemErroCadastro(Context context)
        {
            var alert = new AlertDialog.Builder(context);
            alert.SetTitle("Falha ao Inscrever!");
            alert.SetMessage("N�o foi poss�vel realizar sua inscri��o, tente novamente!");
            alert.SetPositiveButton("Ok", (senderAlert, args) => { });
            alert.Show();
        }


        public static void MensagemCadastroBemSucedido(Context context)
        {
            const string toast = ("Usu�rio Criado");
            Toast.MakeText(context, toast, ToastLength.Long).Show();
        }

        private static void RemoverRelacao(string tipoCombinacao, int codItem, int codParticipante)
        {

            if (tipoCombinacao == typeof(ResultHobbiesActivity).ToString())
            {
                CursorBd.DeletarHobbie(codParticipante, codItem);
            }
            else if (tipoCombinacao == typeof(ResultAprenderActivity).ToString())
            {
                CursorBd.DeletarAprender(codParticipante,codItem);
            }
            else if (tipoCombinacao == typeof(ResultEnsinarActivity).ToString())
            {
                CursorBd.DeletarEnsinar(codParticipante,codItem);
            }
            
        }
        
    }
}