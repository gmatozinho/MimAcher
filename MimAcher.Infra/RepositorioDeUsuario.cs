using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeUsuario
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeUsuario()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_USUARIO ObterUsuarioPorId(int id)
        {
            return this.Contexto.MA_USUARIO.Find(id);
        }

        public MA_USUARIO ObterUsuarioPorEmail(MA_USUARIO usuario)
        {
            return this.Contexto.MA_USUARIO.Where(l => l.e_mail.ToLower().Equals(usuario.e_mail.ToLower())).SingleOrDefault();
        }

        public List<MA_USUARIO> ObterTodosOsUsuarios()
        {
            return this.Contexto.MA_USUARIO.ToList();
        }

        public MA_USUARIO ObterUsuarioPorEmail(String email)
        {
            return this.Contexto.MA_USUARIO.Where(l => l.e_mail.Equals(email)).SingleOrDefault();
        }

        public MA_USUARIO ObterUsuarioPorEmailESenha(String email, String senha)
        {
            return this.Contexto.MA_USUARIO.Where(l => l.e_mail.ToLower().Equals(email) && l.senha.ToLower().Equals(senha)).SingleOrDefault();
        }

        public void InserirUsuario(MA_USUARIO usuario)
        {
            if (!VerificarSeEmailDeUsuarioJaExiste(usuario))
            {
                this.Contexto.MA_USUARIO.Add(usuario);
                this.Contexto.SaveChanges();
            }
        }

        public Boolean InserirUsuarioComRetorno(MA_USUARIO usuario)
        {
            try
            {
                if (!VerificarSeEmailDeUsuarioJaExiste(usuario))
                {
                    this.Contexto.MA_USUARIO.Add(usuario);
                    this.Contexto.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                throw e;                
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return Contexto.MA_USUARIO.Count();
        }

        public void RemoverUsuario(MA_USUARIO usuario)
        {
            this.Contexto.MA_USUARIO.Remove(usuario);
            this.Contexto.SaveChanges();
        }

        public void AtualizarUsuario(MA_USUARIO usuario)
        {
            MA_USUARIO usuarioaconferir = new MA_USUARIO();

            MIMACHEREntities ContextoModificado = new MIMACHEREntities();

            if (VerificarSeEmailDeUsuarioJaExiste(usuario))
            {
                usuarioaconferir = ObterUsuarioPorEmail(usuario.e_mail);

                if (usuarioaconferir.cod_usuario == usuario.cod_usuario)
                {
                    ContextoModificado.Entry(usuario).State = EntityState.Modified;
                    ContextoModificado.SaveChanges();
                }
            }
            else
            {
                ContextoModificado.Entry(usuario).State = EntityState.Modified;
                ContextoModificado.SaveChanges();
            }
            
        }

        public Boolean AtualizarUsuarioComRetorno(MA_USUARIO usuario)
        {
            MA_USUARIO usuarioaconferir = new MA_USUARIO();

            MIMACHEREntities ContextoModificado = new MIMACHEREntities();

            if (VerificarSeEmailDeUsuarioJaExiste(usuario))
            {
                usuarioaconferir = ObterUsuarioPorEmail(usuario.e_mail);

                if (usuarioaconferir.cod_usuario == usuario.cod_usuario)
                {
                    ContextoModificado.Entry(usuario).State = EntityState.Modified;
                    ContextoModificado.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            else
            {
                ContextoModificado.Entry(usuario).State = EntityState.Modified;
                ContextoModificado.SaveChanges();

                return true;
            }
        }

        public Boolean VerificarSeEmailDeUsuarioJaExiste(MA_USUARIO usuario)
        {
            if (ObterUsuarioPorEmail(usuario) != null)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}
