using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDePartipanteHobbie
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDePartipanteHobbie()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE_HOBBIE ObterHobbieDoParticipantePorId(int id)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Find(id);
        }

        public MA_PARTICIPANTE_HOBBIE ObterParticipanteHobbiePorItemEParticipante(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_participante == hobbieparticipante.cod_participante && l.cod_item == hobbieparticipante.cod_item).SingleOrDefault();
        }

        public MA_PARTICIPANTE_HOBBIE ObterParticipanteHobbiePorItemEParticipante(int id_item, int id_participante)
        {
            MIMACHEREntities ContextoModificado = new MIMACHEREntities();

            return ContextoModificado.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_participante == id_participante && l.cod_item == id_item).SingleOrDefault();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterHobbiesDeParticipantePorIdDeItem(int id_item)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_item == id_item).ToList();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsHobbiesDeParticipantePorPorItemPaginadosPorVinteRegistros(MA_PARTICIPANTE_HOBBIE participantehobbie)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_item == participantehobbie.cod_item && l.cod_status == 1).OrderBy(l => l.cod_participante).Skip(participantehobbie.cod_p_hobbie).Take(20).ToList();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsHobbiesDeParticipantePorPorItemPaginadosPorVinteRegistros(int id_item)
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_item == id_item && l.cod_status == 1).OrderBy(l => l.cod_participante).Take(20).ToList();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.ToList();
        }

        public List<MA_PARTICIPANTE_HOBBIE> ObterTodosOsRegistrosAtivos()
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Where(l => l.cod_status == 1).ToList();
        }

        public void InserirNovoParticipanteHobbie(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteHobbie(hobbieparticipante))
            {
                this.Contexto.MA_PARTICIPANTE_HOBBIE.Add(hobbieparticipante);
                this.Contexto.SaveChanges();
            }
            else
            {
                MA_PARTICIPANTE_HOBBIE participantehobbieconferencia = ObterParticipanteHobbiePorItemEParticipante(hobbieparticipante);

                if (participantehobbieconferencia.cod_status != hobbieparticipante.cod_status)
                {
                    AtualizarAprendizadoDeHobbieSemConferencia(hobbieparticipante);
                }
            }
        }

        public Boolean InserirNovoParticipanteHobbieComRetorno(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteHobbie(hobbieparticipante))
            {
                try
                {
                    this.Contexto.MA_PARTICIPANTE_HOBBIE.Add(hobbieparticipante);
                    this.Contexto.SaveChanges();

                    return true;
                }
                catch(Exception e)
                {
                    return false;
                }
                
            }
            else
            {
                MA_PARTICIPANTE_HOBBIE participantehobbieconferencia = ObterParticipanteHobbiePorItemEParticipante(hobbieparticipante);

                if (participantehobbieconferencia.cod_status != hobbieparticipante.cod_status)
                {
                    return AtualizarAprendizadoDeHobbieComRetorno(hobbieparticipante);
                }
                else
                {
                    return false;
                }
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_HOBBIE.Count();
        }

        public void RemoverHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbiedoparticipante)
        {
            this.Contexto.MA_PARTICIPANTE_HOBBIE.Remove(hobbiedoparticipante);
            this.Contexto.SaveChanges();
        }

        public void AtualizarHobbieDoParticipante(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteHobbie(hobbieparticipante))
            {
                AtualizarAprendizadoDeHobbieSemConferencia(hobbieparticipante);
            }
            else
            {
                MA_PARTICIPANTE_HOBBIE participantehobbieconferencia = ObterParticipanteHobbiePorItemEParticipante(hobbieparticipante);

                if (participantehobbieconferencia.cod_status != hobbieparticipante.cod_status)
                {
                    AtualizarAprendizadoDeHobbieSemConferencia(hobbieparticipante);
                }
            }
        }

        public Boolean AtualizarHobbieDoParticipanteComRetorno(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteHobbie(hobbieparticipante))
            {
                AtualizarAprendizadoDeHobbieSemConferencia(hobbieparticipante);

                return true;
            }
            else
            {
                MA_PARTICIPANTE_HOBBIE participantehobbieconferencia = ObterParticipanteHobbiePorItemEParticipante(hobbieparticipante.cod_item, hobbieparticipante.cod_participante);

                if (participantehobbieconferencia.cod_status != hobbieparticipante.cod_status)
                {
                    AtualizarAprendizadoDeHobbieSemConferencia(hobbieparticipante);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AtualizarAprendizadoDeHobbieSemConferencia(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            MIMACHEREntities Contexto = new MIMACHEREntities();
            
            try
            {
                Contexto.Entry(hobbieparticipante).State = EntityState.Modified;
                Contexto.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }            
        }

        public Boolean AtualizarAprendizadoDeHobbieComRetorno(MA_PARTICIPANTE_HOBBIE hobbieparticipante)
        {
            MA_PARTICIPANTE_HOBBIE participantehobbie = new MA_PARTICIPANTE_HOBBIE();

            try
            {
                this.Contexto.Entry(hobbieparticipante).State = EntityState.Modified;
                this.Contexto.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public Boolean VerificarSeExisteRelacaoDeParticipanteHobbie(MA_PARTICIPANTE_HOBBIE participantehobbie)
        {
            if (ObterParticipanteHobbiePorItemEParticipante(participantehobbie) != null)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public Boolean VerificarSeExisteHobbieDeParticipantePorIdDeItem(int id_item)
        {
            if(ObterHobbiesDeParticipantePorIdDeItem(id_item).Count() > 0)
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
