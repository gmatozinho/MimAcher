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

        public MA_ENSINAR ObterTipoDeEnsinoPorId(int id)
        {
            return this.Contexto.MA_ENSINAR.Find(id);
        }

        public List<MA_ENSINAR> ObterTodosOsRegistrosDoQueSePodeEnsinado()
        {
            return this.Contexto.MA_ENSINAR.ToList();
        }

        public List<MA_ENSINAR> ObterTodosOsRegistrosDoQuePodemSerEnsinadosPorNome(String nome)
        {
            return this.Contexto.MA_ENSINAR.Where(l => l.nome.Equals(nome)).ToList();
        }

        public void InserirNovoEnsino(MA_ENSINAR ensino)
        {
            MIMACHEREntities Contexto = new MIMACHEREntities();
            
            Contexto.MA_ENSINAR.Add(ensino);
            Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_ENSINAR.Count();
        }

        public void RemoverEnsino(MA_ENSINAR ensino)
        {
            this.Contexto.MA_ENSINAR.Remove(ensino);
            this.Contexto.SaveChanges();
        }

        public void AtualizarEnsino(MA_ENSINAR ensino)
        {
            MIMACHEREntities Contexto = new MIMACHEREntities();

            Contexto.Entry(ensino).State = EntityState.Modified;
            Contexto.SaveChanges();
        }
    }
}
