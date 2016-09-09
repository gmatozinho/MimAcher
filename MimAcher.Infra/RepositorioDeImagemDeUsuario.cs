using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MimAcher.Infra
{
    public class RepositorioDeImagemDeUsuario
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeImagemDeUsuario()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_IMAGEM_USUARIO ObterImagemDeUsuarioPorId(int id)
        {
            return this.Contexto.MA_IMAGEM_USUARIO.Find(id);
        }

        public List<MA_IMAGEM_USUARIO> ObterTodosOsImagens()
        {
            return this.Contexto.MA_IMAGEM_USUARIO.ToList();
        }
        
        public MA_IMAGEM_USUARIO ObterImagemPorIdDeUsuario(int id_usuario)
        {
            return this.Contexto.MA_IMAGEM_USUARIO.Where(l => l.cod_us == id_usuario).SingleOrDefault();
        }
        
        public void InserirImagem(MA_IMAGEM_USUARIO Imagem)
        {
            this.Contexto.MA_IMAGEM_USUARIO.Add(Imagem);
            this.Contexto.SaveChanges();
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_IMAGEM_USUARIO.Count();
        }

        public void RemoverImagem(MA_IMAGEM_USUARIO Imagem)
        {
            this.Contexto.MA_IMAGEM_USUARIO.Remove(Imagem);
            this.Contexto.SaveChanges();
        }

        public void AtualizarImagem(MA_IMAGEM_USUARIO Imagem)
        {
            this.Contexto.Entry(Imagem).State = EntityState.Modified;
            this.Contexto.SaveChanges();
        }
    }
}
