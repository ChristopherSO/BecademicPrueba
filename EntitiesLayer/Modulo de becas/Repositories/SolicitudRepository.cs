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

/**
 * Repositorio de Solicitudes
 * Objeto encargado de levantar objetos de tipo Solicitud bajo demanda del gestor.
 * Permite la comunicacion entre el gestor y los datos mediante objetos.
 **/
namespace EntitiesLayer
{

    public class SolicitudRepository : IRepository<Solicitud>
    {
        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        private static SolicitudRepository instance;

        private SolicitudRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        public void Insert(Solicitud entity)
        {
            _insertItems.Add(entity);
        }

        public void Delete(Solicitud entity)
        {
            _deleteItems.Add(entity);
        }

        public void Update(Solicitud entity)
        {
            _updateItems.Add(entity);
        }

        public static SolicitudRepository Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new SolicitudRepository();
                }
                return instance;
            }
        }

        /// <summary>
        /// Consulta a la base de datos todos los tipos de becas registrados en el sistema.
        /// Crea instancias de los tipos de becas consultados.
        /// </summary>
        /// <returns>listaSolicitud de tipo IEnumerable(Solicitud)</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Solicitud> GetAll()
        {
            List<Solicitud> lista = new List<Solicitud>();
            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beca_listar_solicitudes");
                foreach (DataRow fila in tablaResultado.Rows)
                {

                    Solicitud _solicitud = new Solicitud();

                    DateTime _fecha = DateTime.Parse(fila.ItemArray[5].ToString());

                    if (fila.ItemArray[4] != DBNull.Value)
                    {
                        _solicitud.idEstudio = int.Parse(fila.ItemArray[4].ToString());
                    }

                    _solicitud.Id = int.Parse(fila.ItemArray[0].ToString());
                    _solicitud.idUsuario = int.Parse(fila.ItemArray[1].ToString());
                    _solicitud.idCarrera = int.Parse(fila.ItemArray[2].ToString());
                    _solicitud.idTipoBeca = int.Parse(fila.ItemArray[3].ToString());


                    _solicitud.fecha = _fecha.Year + "-" + _fecha.Month + "-" + _fecha.Day;

                    lista.Add(_solicitud);

                }

            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }

            return lista;

        }


        public IEnumerable<Solicitud> GetByFase(int numFase)
        {
            List<Solicitud> lista = new List<Solicitud>();
            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beca_aprobacion_buscar_por_num_fase", new SPP[] { 
                    new SPP("num_fase", numFase)
                });
                foreach (DataRow fila in tablaResultado.Rows)
                {

                    Solicitud _solicitud = new Solicitud();

                    DateTime _fecha = DateTime.Parse(fila.ItemArray[5].ToString());

                    if (fila.ItemArray[4] != DBNull.Value)
                    {
                        _solicitud.idEstudio = int.Parse(fila.ItemArray[4].ToString());
                    }

                    _solicitud.Id = int.Parse(fila.ItemArray[0].ToString());
                    _solicitud.idUsuario = int.Parse(fila.ItemArray[1].ToString());
                    _solicitud.idCarrera = int.Parse(fila.ItemArray[2].ToString());
                    _solicitud.idTipoBeca = int.Parse(fila.ItemArray[3].ToString());


                    _solicitud.fecha = _fecha.Year + "-" + _fecha.Month + "-" + _fecha.Day;

                    lista.Add(_solicitud);

                }

            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }

            return lista;

        }

        /// <summary>
        /// Consulta a la base de datos el tipo de beca registrado que es consultado por Id.
        /// Crea instancias de los tipos de becas consultados.
        /// </summary>
        /// <param name="idSolicitud">Id tipo de beca de tipo Integer</param>
        /// <returns>Objeto tipo de beca</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public Solicitud GetById(int idSolicitud)
        {
            Solicitud _solicitud = new Solicitud();

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beca_detalles_solicitud", new SPP[] { 
                    new SPP("id_solicitud", idSolicitud)
                });

                DateTime _fecha = DateTime.Parse(tablaResultado.Rows[0].ItemArray[5].ToString());

                if (tablaResultado.Rows[0].ItemArray[4] != DBNull.Value)
                {
                    _solicitud.idEstudio = int.Parse(tablaResultado.Rows[0].ItemArray[4].ToString());
                }

                _solicitud.Id = int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString());
                _solicitud.idUsuario = int.Parse(tablaResultado.Rows[0].ItemArray[1].ToString());
                _solicitud.idCarrera = int.Parse(tablaResultado.Rows[0].ItemArray[2].ToString());
                _solicitud.idTipoBeca = int.Parse(tablaResultado.Rows[0].ItemArray[3].ToString());
                _solicitud.fecha = _fecha.Year + "-" + _fecha.Month + "-" + _fecha.Day;

            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }

            return _solicitud;
        }

        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (_insertItems.Count > 0)
                    {
                        foreach (Solicitud Solicitud in _insertItems)
                        {
                            InsertSolicitud(Solicitud);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (Solicitud Solicitud in _updateItems)
                        {
                            UpdateSolicitud(Solicitud);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (Solicitud Solicitud in _deleteItems)
                        {
                            DeleteSolicitud(Solicitud);
                        }
                    }

                    scope.Complete();
                }
                catch (TransactionAbortedException ex)
                {
                    throw new TransactionAbortedException(String.Format("Transaction Error: {0}", ex.Message));
                }
                catch (ApplicationException ex)
                {
                    throw ex;
                }
                finally
                {
                    Clear();
                }

            }
        }

        public void Clear()
        {
            _insertItems.Clear();
            _deleteItems.Clear();
            _updateItems.Clear();
        }

        /// <summary>
        /// Inserta el tipo de beca a la base de datos.
        /// </summary>
        /// <param name="Solicitud">objBeca de tipo "Solicitud"</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        private void InsertSolicitud(Solicitud Solicitud)
        {

            try
            {

                Object idDeEstudio = DBNull.Value;

                if (Solicitud.idEstudio > 0)
                {
                    idDeEstudio = Solicitud.idEstudio;
                }

                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_solicitar", new SPP[] { 
                    new SPP("id_usuario", Solicitud.idUsuario),
                    new SPP("id_carrera", Solicitud.idCarrera),
                    new SPP("id_tipo_beca", Solicitud.idTipoBeca),
                    new SPP("id_estudio", idDeEstudio),
                    new SPP("fecha", Solicitud.fecha)
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        private void UpdateSolicitud(Solicitud Solicitud)
        {
            try
            {
                Object idDeEstudio = DBNull.Value;

                if (Solicitud.idEstudio > 0)
                {
                    idDeEstudio = Solicitud.idEstudio;
                }
 
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_actualizar_solicitud", new SPP[] {
                    new SPP("id_solicitud", Solicitud.Id),
                    new SPP("id_usuario", Solicitud.idUsuario),
                    new SPP("id_carrera", Solicitud.idCarrera),
                    new SPP("id_tipo_beca", Solicitud.idTipoBeca),
                    new SPP("id_estudio", idDeEstudio),
                    new SPP("fecha", Solicitud.fecha)
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Elimina una instacia a un tipo de beca
        /// </summary>
        /// <param name="Solicitud">objBeca de tipo Solicitud</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        private void DeleteSolicitud(Solicitud Solicitud)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_rechazar_solicitud", new SPP[] { 
                    new SPP("id_solicitud", Solicitud.Id),
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }


    }
}
