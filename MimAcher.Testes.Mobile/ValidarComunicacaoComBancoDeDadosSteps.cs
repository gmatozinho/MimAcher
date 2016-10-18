namespace Testes
{
    /* Testes prontos, aguardando finalização da classe cursor
    
    [Binding]
    public class ValidarComunicacaoComBancoDeDadosSteps
    {
        Participante participante, participanteBanco;
        Dictionary<string, string> dados;
        Dictionary<string, List<Participante>> matchs;

        [Given(@"eu tenho os dados de um participante")]
        public void GivenEuTenhoOsDadosDeUmParticipante()
        {
            Dictionary<string, string> dados = new Dictionary<string, string>();
            dados["nome"] = "Cayo";
            dados["nascimento"] = "24/01/1994";
            dados["email"] = "cayo@email.com";
            dados["telefone"] = "12345678";
            dados["campus"] = "Serra";
            dados["senha"] = "senha123";

            participante = new Participante(dados);
        }
        
        [Given(@"eu tenho um participante com '(.*)' em um item")]
        public void GivenEuTenhoUmParticipanteComEmUmItem(string relacao)
        {
            switch (relacao)
            {
                case("hobbie"):
                    ListaItens hobbie = new ListaItens();
                    hobbie.AdicionarItem("futebol");
                    participante.Hobbies = hobbie;
                    break;
                case ("aprender"):
                    ListaItens aprender = new ListaItens();
                    aprender.AdicionarItem("violao");
                    participante.Aprender = aprender;
                    break;
                case ("ensinar"):
                    ListaItens ensinar = new ListaItens();
                    ensinar.AdicionarItem("guitarra");
                    participante.Ensinar = ensinar;
                    break;
        }
        }
        
        [When(@"eu enviar os dados para o BD")]
        public void WhenEuEnviarOsDadosParaOBD()
        {
            participante.Commit();
        }
        
        [When(@"eu buscar os matchs dessa relacao no BD")]
        public void WhenEuBuscarOsMatchsDessaRelacaoNoBD()
        {
            matchs = participante.Match();
        }
        
        [Then(@"o banco deve armazenar os mesmos dados")]
        public void ThenOBancoDeveArmazenarOsMesmosDados()
        {
            participanteBanco = CursorBD.GetParticipante("cayo@email.com");

            Assert.AreEqual(participante.Nome, participanteBanco.Nome);
            Assert.AreEqual(participante.Email, participanteBanco.Email);
            Assert.AreEqual(participante.Nascimento, participanteBanco.Nascimento);
            Assert.AreEqual(participante.Campus, participanteBanco.Campus);
            Assert.AreEqual(participante.Telefone, participanteBanco.Telefone);
            Assert.AreEqual(participanteBanco.Login("senha123"), true);
        }
        
        [Then(@"todo match deve ter '(.*)' no mesmo item")]
        public void ThenTodoMatchDeveTerNoMesmoItem(string relacaoCompativel)
        {
            List<Participante> matchsDesejados = null;

            switch (relacaoCompativel)
            {
                case ("hobbie"):
                    if ((matchs.Keys.ToList()).Contains("hobbie"))
                        matchsDesejados = matchs["hobbie"];
                    break;
                case ("aprender"):
                    if ((matchs.Keys.ToList()).Contains("ensinar"))
                        matchsDesejados = matchs["ensinar"];
                    break;
                case ("ensinar"):
                    if ((matchs.Keys.ToList()).Contains("aprender"))
                        matchsDesejados = matchs["aprender"];
                    break;
            }

            ListaItens relacoesMatch = null;
            List<string> relacoes = null;

            foreach (Participante match in matchsDesejados)
            {
                switch (relacaoCompativel)
                {
                    case ("hobbie"):
                        relacoesMatch = match.Hobbies;
                        relacoes = relacoesMatch.Conteudo;
                        Assert.AreEqual(relacoes.Contains("futebol"), true);
                        break;
                    case ("aprender"):
                        relacoesMatch = match.Aprender;
                        relacoes = relacoesMatch.Conteudo;
                        Assert.AreEqual(relacoes.Contains("guitarra"), true);
                        break;
                    case ("ensinar"):
                        relacoesMatch = match.Ensinar;
                        relacoes = relacoesMatch.Conteudo;
                        Assert.AreEqual(relacoes.Contains("violao"), true);
                        break;
                }
            }
        }
    }
    */
}
