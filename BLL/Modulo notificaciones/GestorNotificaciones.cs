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
    public class GestorNotificaciones
    {

        /// <summary>
        /// Agrega una notificación a un usuario.
        /// idUsuario = Usuario a notificar.
        /// idUsuarioAutor = Usuario quien emitió un veredicto (sólo en tipo de notificación Veredicto).
        /// Tipos de notificación: 
        ///     1) Veredicto, 
        ///     2) Solicitud aprobada, 
        ///     3) Solicitud rechazada,
        ///     4) Mensaje,
        ///     5) Cambios académicos,
        ///     6) Beca reactivada,
        ///     7) Beca desactivada
        /// </summary>
        public void agregarNotificacionAUsuario(int idUsuario, int idUsuarioAutor, int idTipoNotificacion, string mensaje)
        {
            try
            {
                Notificacion notificacion = new Notificacion(-1, idUsuarioAutor, idTipoNotificacion, mensaje, new DateTime());
                if (notificacion.IsValid)
                {
                    NotificacionRepository.Instance.InsertarNotificacion(idUsuario, notificacion);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in notificacion.GetRuleViolations())
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


        /**
        * Consultar notificaciones no vistas
        * Metodo que permite listar objetos de tipo notificacion mediante el repositorio encargado.
        **/
        public IEnumerable<Notificacion> consultarNotificacionesNoVistas(int idUsuario)
        {
            IEnumerable<Notificacion> lstNotificaciones = null;

            try
            {
                lstNotificaciones = NotificacionRepository.Instance.ListarNoVistas(idUsuario);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
            return lstNotificaciones;
        }


        /**
        * Consultar todas las notificaciones
        * Metodo que permite listar objetos de tipo notificacion mediante el repositorio encargado.
        **/
        public IEnumerable<Notificacion> consultarNotificacionesTodas(int idUsuario)
        {
            IEnumerable<Notificacion> lstNotificaciones = null;

            try
            {
                lstNotificaciones = NotificacionRepository.Instance.ListarTodas(idUsuario);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
            return lstNotificaciones;
        }


        /**
        * Consultar la notificación por id
        * Metodo que permite obtener el objeto de tipo notificacion mediante el repositorio encargado.
        **/
        public Notificacion consultarNotificacionPorID(int pIdNotificacion)
        {
            try
            {
                return NotificacionRepository.Instance.GetById(pIdNotificacion);
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


        /**
        * Marcar la notificación como vista
        * Metodo que permite obtener el objeto de tipo notificacion mediante el repositorio encargado.
        **/
        public void marcarNotificacionComoVista(int pIdNotificacion, int pIdUsuario)
        {
            try
            {
                NotificacionRepository.Instance.marcarNotificacionComoVista(pIdNotificacion, pIdUsuario);
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


    }

}
