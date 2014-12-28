using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesLayer;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using TIL.CustomExceptions;

namespace BLL
{
    public class GestorCalificaciones
    {
        public void agregarCalificacion(int idUsuario, int idCurso, double nota, int periodo, int annio, String comentarios)
        {
            try
            {
                Calificacion calificacion = new Calificacion(0, idUsuario, idCurso, nota, periodo, annio, comentarios);

                if (calificacion.IsValid)
                {
                    CalificacionRepository.Instance.Insert(calificacion);
                    CalificacionRepository.Instance.Save();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in calificacion.GetRuleViolations())
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

        public void editarCalificacion(int idCalificacion, int idCurso, double nota, int periodo, int annio)
        {
            try
            {
                Calificacion calificacion = CalificacionRepository.Instance.GetById(idCalificacion);
                calificacion.IdCurso = idCurso;
                calificacion.Nota = nota;
                calificacion.Periodo = periodo;
                calificacion.Annio = annio;
                CalificacionRepository.Instance.Update(calificacion);
                CalificacionRepository.Instance.Save();
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

        public void eliminarCalificacion(int idCalificacion)
        {
            Calificacion calificacion = CalificacionRepository.Instance.GetById(idCalificacion);
            CalificacionRepository.Instance.Delete(calificacion);
            CalificacionRepository.Instance.Save();
        }

        public Calificacion consultarCalificacionById(int idCalificacion)
        {
            Calificacion calificacion = null;

            try
            {
                calificacion = CalificacionRepository.Instance.GetById(idCalificacion);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }

            return calificacion;
        }

        public IEnumerable<Calificacion> consultarCalificaciones(int idUsuario, int idCarrera)
        {
            IEnumerable<Calificacion> lstCalificacion = null;
            try
            {
                lstCalificacion = CalificacionRepository.Instance.GetByUsuario(idUsuario, idCarrera);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }

            return lstCalificacion;
        }
    }
}
