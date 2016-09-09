using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeEnsinar
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeEnsinar()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public List<ENSINAR> ObterTodosOsRegistrosDoQueSePodeEnsinado()
        {
            return this.Contexto.ENSINAR.ToList();
        }

        public List<ENSINAR> ObterTodosOsRegistrosDoQuePodemSerEnsinadosPorNome(String nome)
        {
            return this.Contexto.ENSINAR.Where(l => l.nome.Equals(nome)).ToList();
        }

        public void InserirNovoEnsino(ENSINAR ensino)
        {
            this.Contexto.ENSINAR.Add(ensino);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.ENSINAR.Count();
        }

        public void RemoverEnsino(ENSINAR ensino)
        {
            this.Contexto.ENSINAR.Remove(ensino);
            this.Contexto.SaveChanges();
        }

        public void AtualizarEnsino(ENSINAR ensino)
        {
            this.Contexto.Entry(ensino).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
