using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Transactions;
using System.Data.SqlClient;
using System.Data;
using DAL;
using TIL.CustomExceptions;

namespace EntitiesLayer
{
    /// <author>Christopher Suárez</author>
    /// <summary>
    /// Repositorio de notificacions.
    /// Objeto encargado de levantar objetos de notificacions bajo demanda del gestor. 
    /// Permite la comunicacion entre el gestor y los datos mediante objetos.
    /// </summary>
    public class NotificacionRepository
    {
        private static NotificacionRepository _instance;

        /// <summary>Crea listas de notificacions para insertar, eliminar y modificar.</summary>
        public NotificacionRepository()
        {

        }

        /// <summary>Crea una instacia de un repositorio de notificacions.</summary>
        /// <value>Obtiene una instancia de NotificacionRepository.</value>
        /// <returns>_instance tipo: NotificacionRepository</returns>
        public static NotificacionRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NotificacionRepository();
                }
                return _instance;
            }
        }


        /// <summary>
        /// Consulta a la base de datos el tipo de notificacion registrado que es consultado por Id.
        /// Crea instancias de las notificaciones consultados.
        /// </summary>
        /// <param name="idNotificacion">Id notificacion de tipo Integer</param>
        /// <returns>Objeto Notificacion</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public Notificacion GetById(int idNotificacion)
        {
            Notificacion Notificacion = null;

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_notificacion_buscar_id", new SPP[] { 
                new SPP("id_notificacion", idNotificacion.ToString())
            });
                return new Notificacion(
                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[1].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[2].ToString()),
                    tablaResultado.Rows[0].ItemArray[3].ToString(),
                    DateTime.Parse(tablaResultado.Rows[0].ItemArray[4].ToString())
                );
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Diagnostics.Debug.Write(sqlException.Message);
                return Notificacion;
            }
        }


        /// <summary>
        /// Consulta a la base de datos todos las notificacions registrados en el sistema.
        /// Crea instancias de las notificacions consultados.
        /// </summary>
        /// <returns>lista de tipo IEnumerable(Notificacion)</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public TipoNotificacion buscarTipoNotificacionPorId(int idTipoNotificacion)
        {
            TipoNotificacion TipoNotificacion = null;

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_notificacion_buscar_tipo", new SPP[] { 
                new SPP("id_tipo_notificacion", idTipoNotificacion.ToString())
            });
                return new TipoNotificacion(
                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    tablaResultado.Rows[0].ItemArray[1].ToString(),
                    tablaResultado.Rows[0].ItemArray[2].ToString(),
                    tablaResultado.Rows[0].ItemArray[3].ToString(),
                    tablaResultado.Rows[0].ItemArray[4].ToString()
                );
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Diagnostics.Debug.Write(sqlException.Message);
                return TipoNotificacion;
            }
        }

        /// <summary>
        /// Consulta a la base de datos todos las notificacions registrados en el sistema.
        /// Crea instancias de las notificacions consultados.
        /// </summary>
        /// <returns>lista de tipo IEnumerable(Notificacion)</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Notificacion> ListarTodas(int idUsuario)
        {
            List<Notificacion> lista = new List<Notificacion>();

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_notificacion_listar_todas", new SPP[] { 
                    new SPP("id_usuario", idUsuario.ToString())
                });
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new Notificacion(
                        int.Parse(fila.ItemArray[0].ToString()),
                        int.Parse(fila.ItemArray[1].ToString()),
                        int.Parse(fila.ItemArray[2].ToString()),
                        fila.ItemArray[3].ToString(),
                        DateTime.Parse(fila.ItemArray[4].ToString())
                    ));
                }
                return lista;
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Diagnostics.Debug.Write(sqlException.Message);
                return lista;
            }
        }

        /// <summary>
        /// Consulta a la base de datos todos las notificacions registrados en el sistema.
        /// Crea instancias de las notificacions consultados.
        /// </summary>
        /// <returns>lista de tipo IEnumerable(Notificacion)</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Notificacion> ListarNoVistas(int idUsuario)
        {
            List<Notificacion> lista = new List<Notificacion>();

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_notificacion_listar_no_vistas", new SPP[] { 
                    new SPP("id_usuario", idUsuario.ToString())
                });
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new Notificacion(
                        int.Parse(fila.ItemArray[0].ToString()),
                        int.Parse(fila.ItemArray[1].ToString()),
                        int.Parse(fila.ItemArray[2].ToString()),
                        fila.ItemArray[3].ToString(),
                        DateTime.Parse(fila.ItemArray[4].ToString())
                    ));
                }
                return lista;
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Diagnostics.Debug.Write(sqlException.Message);
                return lista;
            }
        }

        public void InsertarNotificacion(int idUsuario, Notificacion Notificacion)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_notificacion_insertar", new SPP[] { 
                    new SPP("id_usuario", idUsuario.ToString()),
                    new SPP("id_usuario_autor", Notificacion.IdUsuarioAutor.ToString()),
                    new SPP("id_tipo_notificacion", Notificacion.IdTipoNotificacion.ToString()),
                    new SPP("mensaje", Notificacion.Mensaje),
                    new SPP("fecha", Notificacion.Fecha.ToString("yyyy-MM-dd"))
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Consulta a la base de datos el tipo de notificacion registrado que es consultado por Id.
        /// Crea instancias de las notificaciones consultados.
        /// </summary>
        /// <param name="idNotificacion">Id notificacion de tipo Integer</param>
        /// <returns>Objeto Notificacion</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public void marcarNotificacionComoVista(int idNotificacion, int idUsuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_notificacion_marcar_como_vista", new SPP[] { 
                    new SPP("id_notificacion", idNotificacion.ToString()),
                    new SPP("id_usuario", idUsuario.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }


    }
}
