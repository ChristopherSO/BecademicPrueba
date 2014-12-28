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
    public class GestorBecas
    {
        public void agregarBeca(int pIdCarrera, DateTime pFechaAprobacion, int pIdUsuario, int pIdTipoBeca, bool pEstado, string pComentario)
        {
            try
            {
                Beca beca = new Beca(-1, pIdCarrera, pFechaAprobacion, pIdUsuario, pIdTipoBeca, pEstado, pComentario);

                if (beca.IsValid)
                {
                    BecaRepository.Instance.Insert(beca);
                    BecaRepository.Instance.Save();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in beca.GetRuleViolations())
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

        public void editarBeca(int pIdBeca, int pIdCarrera, DateTime pFechaAprobacion, int pIdUsuario, int pIdTipoBeca, bool pEstado, string pComentario)
        {
            try
            {
                Beca beca = BecaRepository.Instance.GetById(pIdBeca);
                beca.IdCarrera = pIdCarrera;
                beca.FechaAprobacion = pFechaAprobacion;
                beca.IdUsuario = pIdUsuario;
                beca.IdTipoBeca = pIdTipoBeca;
                beca.Estado = pEstado;
                beca.Comentario = pComentario;
                BecaRepository.Instance.Update(beca);
                BecaRepository.Instance.Save();
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

        public void eliminarBeca(int pIdBeca)
        {
            try
            {
                Beca beca = BecaRepository.Instance.GetById(pIdBeca);
                BecaRepository.Instance.Delete(beca);
                BecaRepository.Instance.Save();
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


        public IEnumerable<Beca> consultarBecas()
        {
            try
            {
                return BecaRepository.Instance.GetAll();
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

        public Beca consultarBecaPorID(int pIdBeca)
        {
            try
            {
                return BecaRepository.Instance.GetById(pIdBeca);
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


        /// <summary>
        /// Consulta a la base de datos para obtener el id de la beca de un estudiante
        /// según la carrera indicada. Devuelve -1 si no tiene becas otorgadas.
        /// </summary>
        /// <returns>int idBeca</returns>
        public int obtenerIdBecaDeEstudiantePorCarrera(int idUsuario, int idCarrera)
        {
            try
            {
                int idBeca = BecaRepository.Instance.obtenerIdBecaDeEstudiantePorCarrera(idUsuario, idCarrera);

                return idBeca;
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


        /// <summary>
        /// Obtiene el promedio de calificaciones del estudiante para la carrera indicada.
        /// Si el estudiante no tuviera ninguna calificación, devuelve -1.
        /// </summary>
        /// <returns>double promedioCalificaciones</returns>
        public double obtenerPromedioCalificacionesDeEstudiantePorCarrera(int idUsuario, int idCarrera)
        {
            try
            {
                double promedioCalificaciones = BecaRepository.Instance.obtenerPromedioCalificacionesDeEstudiantePorCarrera(idUsuario, idCarrera);

                return promedioCalificaciones;
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


        /// <summary>
        /// Obtiene el promedio de calificaciones del estudiante para la carrera indicada.
        /// Si el estudiante no tuviera ninguna calificación, devuelve -1.
        /// </summary>
        /// <returns>double promedioCalificaciones</returns>
        public void cambiarEstadoDeBeca(Beca beca, bool estado, string mensaje)
        {
            try
            {
                editarBeca(
                    beca.Id,
                    beca.IdCarrera,
                    beca.FechaAprobacion,
                    beca.IdUsuario,
                    beca.IdTipoBeca,
                    estado,
                    mensaje
                );
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


        /// <summary>
        /// Comprueba si el promedio de calificaciones de un estudiante cumple con el promedio mínimo
        /// para inactivar o activar su beca otorgada si la tuviera para una carrera indicada.
        /// </summary>
        public string validarEstadoBeca(int idUsuario, int idCarrera)
        {
            string resultado = "Texto inicialización";
            try
            {
                // Primero se comprueba que el usuario tenga una beca otorgada para la carrera indicada
                int idBeca = obtenerIdBecaDeEstudiantePorCarrera(idUsuario, idCarrera);

                if (idBeca > 0) // Si el usuario no tiene becas otorgadas, idBeca sería igual a -1, de lo contrario sería mayor a cero.
                {
                    // Se obtiene el promedio de calificaciones del estudiante para la carrera indicada
                    double promedioCalificaciones = obtenerPromedioCalificacionesDeEstudiantePorCarrera(idUsuario, idCarrera);

                    if (promedioCalificaciones > 0) // Si el usuario no tiene calificaciones, promedioCalificaciones sería igual a -1, de lo contrario sería mayor a cero.
                    {
                        Beca beca = consultarBecaPorID(idBeca);
                        GestorNotificaciones gestorNotificaciones = new GestorNotificaciones();
                        string mensajeReactivacion = "Su beca ha sido reactivada por<br>cumplimiento en el promedio<br>mínimo de calificaciones.";
                        string mensajeDesactivacion = "Su beca ha sido desactivada por<br>incumplimiento en el promedio<br>mínimo de calificaciones";

                        resultado = "No hay cambios";

                        if (beca.Estado == true && promedioCalificaciones < 80)         // Si la beca estaba activa y ahora no cumple con el promedio...
                        {
                            cambiarEstadoDeBeca(beca, false, mensajeDesactivacion);     // Se le desactiva la beca

                            gestorNotificaciones.agregarNotificacionAUsuario(idUsuario, 1, 7, mensajeDesactivacion);   // Se notifica al estudiante

                            resultado = "La beca fue desactivada";
                        }

                        if (beca.Estado == false && promedioCalificaciones >= 80)       // Si la beca estaba inactiva y ahora cumple con el promedio...
                        {
                            cambiarEstadoDeBeca(beca, true, mensajeReactivacion);       // Se le reactiva la beca

                            gestorNotificaciones.agregarNotificacionAUsuario(idUsuario, 1, 6, mensajeReactivacion);   // Se notifica al estudiante

                            resultado = "La beca fue reactivada";
                        }
                    }
                    else
                    {
                        resultado = "El usuario no tiene calificaciones";
                    }
                }
                else
                {
                    resultado = "El usuario no tiene becas aprobadas con esa carrera";
                }
                return resultado;
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