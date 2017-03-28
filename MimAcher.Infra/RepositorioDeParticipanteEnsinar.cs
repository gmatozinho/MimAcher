using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using MimAcher.Dominio;

namespace MimAcher.Infra
{
    public class RepositorioDeParticipanteEnsinar
    {
        public MIMACHEREntities Contexto { get; set; }

        public RepositorioDeParticipanteEnsinar()
        {
            this.Contexto = new MIMACHEREntities();
        }

        public MA_PARTICIPANTE_ENSINAR ObterRelacaoDoQueOParticipanteEnsinaPorId(int id)
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.Find(id);
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterEnsinosDeParticipantePorIdDeItem(int idItem)
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.Where(l => l.cod_item == idItem).ToList();
        }

        public MA_PARTICIPANTE_ENSINAR ObterEnsinoDeParticipantePorItemEParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.Where(l => l.cod_participante == participanteensinar.cod_participante && l.cod_item == participanteensinar.cod_item).SingleOrDefault();
        }

        public MA_PARTICIPANTE_ENSINAR ObterEnsinoDeParticipantePorItemEParticipante(int idItem, int idParticipante)
        {
            MIMACHEREntities contextoModificado = new MIMACHEREntities();

            return contextoModificado.MA_PARTICIPANTE_ENSINAR.Where(l => l.cod_participante == idParticipante && l.cod_item == idItem).SingleOrDefault();
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.Where(l => l.cod_item == participanteensinar.cod_item && l.cod_status == 1).Skip(participanteensinar.cod_p_ensinar).Take(20).ToList();
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsEnsinamentosDeParticipantePorPorItemPaginadosPorVinteRegistros(int idItem)
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.Where(l => l.cod_item == idItem && l.cod_status == 1).Take(20).ToList();        
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.ToList();
        }

        public List<MA_PARTICIPANTE_ENSINAR> ObterTodosOsRegistrosAtivos()
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.Where(l => l.cod_status == 1).ToList();
        }

        public void InserirNovoEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteensinar))
            {
                this.Contexto.MA_PARTICIPANTE_ENSINAR.Add(participanteensinar);
                this.Contexto.SaveChanges();
            }
            else
            {
                MA_PARTICIPANTE_ENSINAR participanteensinarconferencia = ObterEnsinoDeParticipantePorItemEParticipante(participanteensinar);

                if (participanteensinarconferencia.cod_status != participanteensinar.cod_status)
                {
                    AtualizarEnsinamentoDeParticipanteSemConferencia(participanteensinar);
                }
            }
        }

        public Boolean InserirNovoEnsinamentoDeParticipanteComRetorno(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteensinar))
            {
                this.Contexto.MA_PARTICIPANTE_ENSINAR.Add(participanteensinar);
                this.Contexto.SaveChanges();

                return true;
            }
            else
            {
                MA_PARTICIPANTE_ENSINAR participanteensinarconferencia = ObterEnsinoDeParticipantePorItemEParticipante(participanteensinar);

                try
                {
                    if (participanteensinarconferencia.cod_status != participanteensinar.cod_status)
                    {
                        return AtualizarEnsinamentoDeParticipanteComRetorno(participanteensinar);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch(Exception)
                {
                    return false;
                }
            }
        }

        public int BuscarQuantidadeRegistros()
        {
            return this.Contexto.MA_PARTICIPANTE_ENSINAR.Count();
        }

        public void RemoverEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            this.Contexto.MA_PARTICIPANTE_ENSINAR.Remove(participanteensinar);
            this.Contexto.SaveChanges();
        }

        public Boolean AtualizarEnsinamentoDeParticipanteComRetorno(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteensinar))
            {
                AtualizarEnsinamentoDeParticipanteSemConferencia(participanteensinar);

                return true;
            }
            else
            {
                MA_PARTICIPANTE_ENSINAR participanteensinarconferencia = ObterEnsinoDeParticipantePorItemEParticipante(participanteensinar.cod_item, participanteensinar.cod_participante);

                if (participanteensinarconferencia.cod_status != participanteensinar.cod_status)
                {
                    AtualizarEnsinamentoDeParticipanteSemConferencia(participanteensinar);

                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AtualizarEnsinamentoDeParticipante(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (!VerificarSeExisteRelacaoDeParticipanteAprender(participanteensinar))
            {
                AtualizarEnsinamentoDeParticipanteSemConferencia(participanteensinar);
            }
            else
            {
                MA_PARTICIPANTE_ENSINAR participanteensinarconferencia = ObterEnsinoDeParticipantePorItemEParticipante(participanteensinar);

                if (participanteensinarconferencia.cod_status != participanteensinar.cod_status)
                {
                    AtualizarEnsinamentoDeParticipanteSemConferencia(participanteensinar);
                }
            }
        }

        public void AtualizarEnsinamentoDeParticipanteSemConferencia(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            MIMACHEREntities contexto = new MIMACHEREntities();

            contexto.Entry(participanteensinar).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public Boolean VerificarSeExisteRelacaoDeParticipanteAprender(MA_PARTICIPANTE_ENSINAR participanteensinar)
        {
            if (ObterEnsinoDeParticipantePorItemEParticipante(participanteensinar) != null)
            {
                return true;
            }
            return false;
        }

        public Boolean VerificarSeExisteEnsinoDeParticipantePorIdDeItem(int idItem)
        {
            if (ObterEnsinosDeParticipantePorIdDeItem(idItem).Count() > 0)
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
