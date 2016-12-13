using System.Diagnostics;

namespace MimAcher.Mobile.com.Utilitarios
{
    public static class EnviarErro
    {
        public static void EnviandoTempoIniciarMain(Stopwatch tempo)
        {
            CursorBd.EnviarErro("Tempo" , "Carregar Main" , tempo.Elapsed.Milliseconds);
        }

        public static void EnviandoTempoIniciarEntrar(Stopwatch tempo)
        {
            CursorBd.EnviarErro("Tempo", "Logar", tempo.Elapsed.Milliseconds);
        }

        public static void EnviandoTempoIniciarInscrever(Stopwatch tempo)
        {
            CursorBd.EnviarErro("Tempo"," Carregar Inscrever", tempo.Elapsed.Milliseconds);
        }

        public static void EnviandoErroValidadores(string erro)
        {
            CursorBd.EnviarErro("Erro Validadores", erro, 1);
        }
    }
}