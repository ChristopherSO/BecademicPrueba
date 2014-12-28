using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using EntitiesLayer;
using DAL;
using TIL.CustomExceptions;

namespace BLL
{
    public class GestorAprobacion
    {
        public void agregarAprobacion(int idSolicitud, int idUsuario, DateTime fecha, String comentario, bool aprobado)
        {
            try
            {
                Aprobacion aprobacion = new Aprobacion(0, idSolicitud, idUsuario, fecha, comentario, aprobado);

                if (aprobacion.IsValid)
                {
                    AprobacionesRepository.Instance.Insert(aprobacion);
                    AprobacionesRepository.Instance.Save();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in aprobacion.GetRuleViolations())
                    {
                        sb.AppendLine(rv.ErrorMessage);
                    }
                    throw new ApplicationException(sb.ToString());
                }

            }
            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        public void editarAprobacion(int idAprobacion, int idSolicitud, int idUsuario, DateTime fecha, String comentario, bool aprobado)
        {
            try
            {
                Aprobacion aprobacion = AprobacionesRepository.Instance.GetById(idAprobacion);
                aprobacion.IdSolicitud = idSolicitud;
                aprobacion.IdUsuario = idUsuario;
                aprobacion.Fecha = fecha;
                aprobacion.Comentario = comentario;
                aprobacion.Aprobado = aprobado;
                AprobacionesRepository.Instance.Update(aprobacion);
                AprobacionesRepository.Instance.Save();
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        public void eliminarAprobacion(int idAprobacion)
        {
            try
            {
                Aprobacion aprobacion = AprobacionesRepository.Instance.GetById(idAprobacion);
                AprobacionesRepository.Instance.Delete(aprobacion);
                AprobacionesRepository.Instance.Save();
            }
            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        public IEnumerable<Aprobacion> consultarAprobaciones()
        {
            try
            {
                return AprobacionesRepository.Instance.GetAll();
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }

        }

        public Aprobacion consultarAprobacionById(int idAprobacion)
        {
            Aprobacion aprobacion = null;

            try
            {
                aprobacion = AprobacionesRepository.Instance.GetById(idAprobacion);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }

            return aprobacion;
        }
    }
}
