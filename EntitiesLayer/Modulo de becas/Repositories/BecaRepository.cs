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
    /// Repositorio de becas.
    /// Objeto encargado de levantar objetos de becas bajo demanda del gestor. 
    /// Permite la comunicacion entre el gestor y los datos mediante objetos.
    /// </summary>
    public class BecaRepository : IRepository<Beca>
    {
        private static BecaRepository _instance;
        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        /// <summary>Crea listas de becas para insertar, eliminar y modificar.</summary>
        public BecaRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        /// <summary>Crea una instacia de un repositorio de becas.</summary>
        /// <value>Obtiene una instancia de BecaRepository.</value>
        /// <returns>_instance tipo: BecaRepository</returns>
        public static BecaRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BecaRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Inserta en la lista _insertItems una beca.
        /// </summary>
        /// <param name="entity">entity de tipo "Beca"</param>
        public void Insert(Beca entity)
        {
            _insertItems.Add(entity);
        }

        /// <summary>
        /// Inserta en la lista _deleteItems una beca.
        /// </summary>
        /// <param name="entity">entity de tipo "Beca"</param>
        public void Delete(Beca entity)
        {
            _deleteItems.Add(entity);
        }

        /// <summary>
        /// Inserta en la lista _updateItems una beca.
        /// </summary>
        /// <param name="entity">entity de tipo "Beneficiio"</param>
        public void Update(Beca entity)
        {
            _updateItems.Add(entity);
        }

        /// <summary>
        /// Consulta a la base de datos todos las becas registrados en el sistema.
        /// Crea instancias de las becas consultados.
        /// </summary>
        /// <returns>lista de tipo IEnumerable(Beca)</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Beca> GetAll()
        {
            List<Beca> lista = new List<Beca>();
            DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beca_listar");
            foreach (DataRow fila in tablaResultado.Rows)
            {
                lista.Add(new Beca(
                    int.Parse(fila.ItemArray[0].ToString()),
                    int.Parse(fila.ItemArray[1].ToString()),
                    DateTime.Parse(fila.ItemArray[2].ToString()),
                    int.Parse(fila.ItemArray[3].ToString()),
                    int.Parse(fila.ItemArray[4].ToString()),
                    bool.Parse(fila.ItemArray[5].ToString()),
                    fila.ItemArray[6].ToString()
                ));
            }

            return lista;
        }

        /// <summary>
        /// Consulta a la base de datos el tipo de beca registrado que es consultado por Id.
        /// Crea instancias de las becas consultados.
        /// </summary>
        /// <param name="idBeca">Id beca de tipo Integer</param>
        /// <returns>Objeto Beca</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public Beca GetById(int idBeca)
        {
            Beca Beca = null;

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beca_buscar_id", new SPP[] { 
                new SPP("id_beca", idBeca.ToString())
            });
                return new Beca(
                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[1].ToString()),
                    DateTime.Parse(tablaResultado.Rows[0].ItemArray[2].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[3].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[4].ToString()),
                    bool.Parse(tablaResultado.Rows[0].ItemArray[5].ToString()),
                    tablaResultado.Rows[0].ItemArray[6].ToString()
                );
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Diagnostics.Debug.Write(sqlException.Message);
                return Beca;
            }
        }


        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (_insertItems.Count > 0)
                    {
                        foreach (Beca Beca in _insertItems)
                        {
                            InsertBeca(Beca);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (Beca Beca in _updateItems)
                        {
                            UpdateBeca(Beca);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (Beca Beca in _deleteItems)
                        {
                            DeleteBeca(Beca);
                        }
                    }

                    scope.Complete();
                }
                catch (TransactionAbortedException ex)
                {
                    throw ex;
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

        private void InsertBeca(Beca Beca)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_insertar", new SPP[] { 
                    new SPP("id_carrera", Beca.IdCarrera.ToString()),
                    new SPP("fecha_aprobacion", Beca.FechaAprobacion.ToString("yyyy-MM-dd")),
                    new SPP("id_usuario", Beca.IdUsuario.ToString()),
                    new SPP("id_tipo_beca", Beca.IdTipoBeca.ToString()),
                    new SPP("estado", Beca.Estado.ToString()),
                    new SPP("comentario", Beca.Comentario)
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateBeca(Beca Beca)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_modificar", new SPP[] { 
                    new SPP("id_beca", Beca.Id.ToString()),
                    new SPP("id_carrera", Beca.IdCarrera.ToString()),
                    new SPP("fecha_aprobacion", Beca.FechaAprobacion.ToString()),
                    new SPP("id_usuario", Beca.IdUsuario.ToString()),
                    new SPP("id_tipo_beca", Beca.IdTipoBeca.ToString()),
                    new SPP("estado", Beca.Estado.ToString()),
                    new SPP("comentario", Beca.Comentario)
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteBeca(Beca Beca)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_eliminar", new SPP[] { 
                    new SPP("id_beca", Beca.Id.ToString()),
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }


        /// <summary>
        /// Consulta a la base de datos para obtener el id de la beca de un estudiante
        /// según la carrera indicada
        /// </summary>
        /// <returns>int idBeca</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public int obtenerIdBecaDeEstudiantePorCarrera(int idUsuario, int idCarrera)
        {
            int idBeca = -1;

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_usuario_obtener_id_beca", new SPP[] { 
                    new SPP("id_usuario", idUsuario.ToString()),
                    new SPP("id_carrera", idCarrera.ToString())
                });

                if (tablaResultado.Rows.Count > 0)
                {
                    idBeca = int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString());
                }

                return idBeca;
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Diagnostics.Debug.Write(sqlException.Message);
                return idBeca;
            }
        }


        /// <summary>
        /// Consulta a la base de datos para obtener el promedio de calificaciones de un estudiante
        /// según la carrera indicada
        /// </summary>
        /// <returns>double promedio</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public double obtenerPromedioCalificacionesDeEstudiantePorCarrera(int idUsuario, int idCarrera)
        {
            double promedio = -1;

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_usuario_promedio_calificaciones", new SPP[] { 
                    new SPP("id_usuario", idUsuario.ToString()),
                    new SPP("id_carrera", idCarrera.ToString())
                });

                if (tablaResultado.Rows.Count > 0)
                {
                    promedio = double.Parse(tablaResultado.Rows[0].ItemArray[0].ToString());
                }

                return promedio;
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Diagnostics.Debug.Write(sqlException.Message);
                return promedio;
            }
        }

    }
}