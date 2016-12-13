using Android.App;

namespace MimAcher.Mobile.com.Entidades
{
    public class TelaENomeParaLoading
    {
        public Activity Tela { get; set;}
        public string NomeTela { get; set; }
        
        public TelaENomeParaLoading(Activity context, string nometela)
        {
            Tela = context;
            NomeTela = nometela;
        }
    }
}