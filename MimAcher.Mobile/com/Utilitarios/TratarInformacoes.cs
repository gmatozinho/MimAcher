namespace MimAcher.Mobile.com.Utilitarios
{
    public class TratarInformacoes
    {
        public static string TrataNumeroTelefone(string telefone)
        {
            if (string.IsNullOrEmpty(telefone)) return telefone;
            return telefone.Length > 13 ? telefone.Remove(13) : telefone;
        }

        public static string TrataData(string data)
        {
            if (string.IsNullOrEmpty(data)) return data;
            return data.Length > 10 ? data.Remove(10) : data;
        }
    }
}