using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MimAcher.Dominio;
using MimAcher.Infra;

namespace MimAcher.Aplicacao
{
    public class GestorDeAcesso
    {
        public RepositorioDeAcesso RepositorioDeAcesso { get; set; }

        public GestorDeAcesso()
        {
            this.RepositorioDeAcesso = new RepositorioDeAcesso();
        }

        public MA_ACESSO ObterAcessoPorId(int id)
        {
            return this.RepositorioDeAcesso.ObterAcessoPorId(id);
        }

        public MA_ACESSO ObterAcessoPorNome(MA_ACESSO acesso)
        {
            return this.RepositorioDeAcesso.ObterAcessoPorNome(acesso);
        }

        public List<MA_ACESSO> ObterTodosOsAcessos()
        {
            return this.RepositorioDeAcesso.ObterTodosOsAcessos();
        }

        public List<MA_ACESSO> ObterTodosOsAcessosPorNome(String nome)
        {
            return this.RepositorioDeAcesso.ObterTodosOsAcessosPorNome(nome);
        }

        public void InserirAcesso(MA_ACESSO acesso)
        {
            this.RepositorioDeAcesso.InserirAcesso(acesso);
        }

        public Boolean InserirAcessoComRetorno(MA_ACESSO acesso)
        {
            return this.RepositorioDeAcesso.InserirAcessoComRetorno(acesso);
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.RepositorioDeAcesso.BuscarQuantidadeRegistros();
        }

        public void RemoverAcesso(MA_ACESSO acesso)
        {
            this.RepositorioDeAcesso.RemoverAcesso(acesso);
        }

        public void AtualizarAcesso(MA_ACESSO acesso)
        {
            this.RepositorioDeAcesso.AtualizarAcesso(acesso);
        }

        public Boolean AtualizarAcessoComRetorno(MA_ACESSO acesso)
        {
            return this.RepositorioDeAcesso.AtualizarAcessoComRetorno(acesso);
        }

        public Boolean VerificarSeUsuarioTemAcessoWeb(int idAcesso)
        {
            if(idAcesso == 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
