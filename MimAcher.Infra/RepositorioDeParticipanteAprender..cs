using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeAprendizadoDeParticipante
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeAprendizadoDeParticipante()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE_APRENDER ObterAprendizadoDoParticipantePorId(int id)
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.Find(id);
        }

        public MA_PARTICIPANTE_APRENDER ObterAprendizadoDeParticipantePorItemEParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.Where(l => l.cod_participante == participanteaprender.cod_participante && l.cod_item == participanteaprender.cod_item).SingleOrDefault();
        }
        
        public MA_PARTICIPANTE_APRENDER ObterAprendizadoDeParticipantePorItemEParticipante(int idItem, int idParticipante)
        {
            MIMACHEREntities contextoModificado = new MIMACHEREntities();
            
            return contextoModificado.MA_PARTICIPANTE_APRENDER.Where(l => l.cod_participante == idParticipante && l.cod_item == idItem).SingleOrDefault();
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterAprendizadoDeParticipantePorIdDeItem(int idItem)
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.Where(l => l.cod_item == idItem).ToList();
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsAprendizadoDeParticipantePorPorItemPaginadosPorVinteRegistros(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.Where(l => l.cod_item == participanteaprender.cod_item && l.cod_status == 1).Skip(participanteaprender.cod_p_aprender).Take(20).ToList();
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsAprendizadoDeParticipantePorPorItemPaginadosPorVinteRegistros(int idItem)
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.Where(l => l.cod_item == idItem && l.cod_status == 1).OrderBy(l => l.cod_participante).Take(20).ToList();
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.ToList();
        }

        public List<MA_PARTICIPANTE_APRENDER> ObterTodosOsRegistrosAtivos()
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.Where(l => l.cod_status == 1).ToList();
        }

        public void InserirNovoAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteaprender))
            {
                this.Contexto.MA_PARTICIPANTE_APRENDER.Add(participanteaprender);
                this.Contexto.SaveChanges();
            }
            else
            {
                MA_PARTICIPANTE_APRENDER participanteaprenderconferencia = ObterAprendizadoDeParticipantePorItemEParticipante(participanteaprender);

                if (participanteaprenderconferencia.cod_status != participanteaprender.cod_status)
                {
                    AtualizarAprendizadoDeParticipanteSemConferencia(participanteaprender);
                }
            }
        }

        public Boolean InserirNovoAprendizadoDeParticipanteComRetorno(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteaprender))
            {
                this.Contexto.MA_PARTICIPANTE_APRENDER.Add(participanteaprender);
                this.Contexto.SaveChanges();

                return true;
            }
            else
            {
                MA_PARTICIPANTE_APRENDER participanteaprenderconferencia = ObterAprendizadoDeParticipantePorItemEParticipante(participanteaprender);

                if (participanteaprenderconferencia.cod_status != participanteaprender.cod_status)
                {
                    return AtualizarAprendizadoDeParticipanteComRetorno(participanteaprender);
                }
                else
                {
                    return false;
                }
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_APRENDER.Count();
        }

        public void RemoverAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            this.Contexto.MA_PARTICIPANTE_APRENDER.Remove(participanteaprender);
            this.Contexto.SaveChanges();
        }

        public Boolean AtualizarAprendizadoDeParticipanteComRetorno(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteaprender))
            {
                AtualizarAprendizadoDeParticipanteSemConferencia(participanteaprender);

                return true;
            }
            else
            {
                MA_PARTICIPANTE_APRENDER participanteaprenderconferencia = ObterAprendizadoDeParticipantePorItemEParticipante(participanteaprender.cod_item, participanteaprender.cod_participante);

                if (participanteaprenderconferencia.cod_status != participanteaprender.cod_status)
                {
                    AtualizarAprendizadoDeParticipanteSemConferencia(participanteaprender);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AtualizarAprendizadoDeParticipante(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteaprender))
            {
                AtualizarAprendizadoDeParticipanteSemConferencia(participanteaprender);
            }
            else
            {
                MA_PARTICIPANTE_APRENDER participanteaprenderconferencia = ObterAprendizadoDeParticipantePorItemEParticipante(participanteaprender);

                if (participanteaprenderconferencia.cod_status != participanteaprender.cod_status)
                {
                    AtualizarAprendizadoDeParticipanteSemConferencia(participanteaprender);
                }
            }
        }

        public void AtualizarAprendizadoDeParticipanteSemConferencia(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            MIMACHEREntities contexto = new MIMACHEREntities();

            contexto.Entry(participanteaprender).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public Boolean VerificarSeExisteRelacaoDeParticipanteAprender(MA_PARTICIPANTE_APRENDER participanteaprender)
        {
            if (ObterAprendizadoDeParticipantePorItemEParticipante(participanteaprender) != null)
            {
                return true;
            }
            return false;
        }

        public Boolean VerificarSeExisteAprendizadoDeParticipantePorIdDeItem(int idItem)
        {
            if (ObterAprendizadoDeParticipantePorIdDeItem(idItem).Count() > 0)
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
