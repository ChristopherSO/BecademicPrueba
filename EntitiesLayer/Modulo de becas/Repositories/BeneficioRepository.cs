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
    /// Repositorio de beneficios.
    /// Objeto encargado de levantar objetos de beneficios bajo demanda del gestor. 
    /// Permite la comunicacion entre el gestor y los datos mediante objetos.
    /// </summary>
    public class BeneficioRepository : IRepository<Beneficio>
    {
        private static BeneficioRepository _instance;
        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        /// <summary>Crea listas de beneficios para insertar, eliminar y modificar.</summary>
        public BeneficioRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        /// <summary>Crea una instacia de un repositorio de beneficios.</summary>
        /// <value>Obtiene una instancia de BeneficioRepository.</value>
        /// <returns>_instance tipo: BeneficioRepository</returns>
        public static BeneficioRepository Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BeneficioRepository();
                }
                return _instance;
            }
        }

        /// <summary>
        /// Inserta en la lista _insertItems un beneficio.
        /// </summary>
        /// <param name="entity">entity de tipo "Beneficio"</param>
        public void Insert(Beneficio entity)
        {
            _insertItems.Add(entity);
        }

        /// <summary>
        /// Inserta en la lista _deleteItems un beneficio.
        /// </summary>
        /// <param name="entity">entity de tipo "Beneficio"</param>
        public void Delete(Beneficio entity)
        {
            _deleteItems.Add(entity);
        }

        /// <summary>
        /// Inserta en la lista _updateItems un beneficio.
        /// </summary>
        /// <param name="entity">entity de tipo "Beneficiio"</param>
        public void Update(Beneficio entity)
        {
            _updateItems.Add(entity);
        }

        /// <summary>
        /// Consulta a la base de datos todos los beneficios registrados en el sistema.
        /// Crea instancias de los beneficios consultados.
        /// </summary>
        /// <returns>lista de tipo IEnumerable(Beneficio)</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Beneficio> GetAll()
        {
            List<Beneficio> lista = new List<Beneficio>();
            DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beneficio_listar");
            foreach (DataRow fila in tablaResultado.Rows)
            {
                lista.Add(new Beneficio(
                    int.Parse(fila.ItemArray[0].ToString()),
                    int.Parse(fila.ItemArray[1].ToString()),
                    fila.ItemArray[2].ToString(),
                    fila.ItemArray[3].ToString(),
                    fila.ItemArray[4].ToString()                    
                ));
            }

            return lista;
        }

        /// <summary>
        /// Consulta a la base de datos el tipo de beca registrado que es consultado por Id.
        /// Crea instancias de los beneficios consultados.
        /// </summary>
        /// <param name="idBeneficio">Id beneficio de tipo Integer</param>
        /// <returns>Objeto Beneficio</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public Beneficio GetById(int idBeneficio)
        {
            Beneficio Beneficio = null;

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beneficio_buscar_id", new SPP[] { 
                new SPP("id_beneficio", idBeneficio.ToString())
            });
                return new Beneficio(
                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[1].ToString()),
                    tablaResultado.Rows[0].ItemArray[2].ToString(),
                    tablaResultado.Rows[0].ItemArray[3].ToString(),
                    tablaResultado.Rows[0].ItemArray[4].ToString()                    
                );
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Diagnostics.Debug.Write(sqlException.Message);
                return Beneficio;
            }
        }

        public IEnumerable<TipoBeneficio> BuscarTiposDeBeneficios()
        {
            List<TipoBeneficio> lista = new List<TipoBeneficio>();
            DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_tipo_beneficio_listar");
            int cantidadDeRegistros = tablaResultado.Rows.Count;
            int id;
            string nombre;
            foreach (DataRow fila in tablaResultado.Rows)
            {
                TipoBeneficio tipoBeneficio = new TipoBeneficio(
                    int.Parse(fila.ItemArray[0].ToString()),
                    fila.ItemArray[1].ToString()
                );
                id = tipoBeneficio.Id;
                nombre = tipoBeneficio.Nombre;
                lista.Add(tipoBeneficio);
            }

            return lista;
        }

        public TipoBeneficio buscarTipoBeneficioPorId(int idTipoBeneficio)
        {
            TipoBeneficio TipoBeneficio = null;

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_tipo_beneficio_buscar_id", new SPP[] { 
                new SPP("id_tipo_beneficio", idTipoBeneficio.ToString())
            });
                return new TipoBeneficio(
                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    tablaResultado.Rows[0].ItemArray[1].ToString()
                );
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Diagnostics.Debug.Write(sqlException.Message);
                return TipoBeneficio;
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
                        foreach (Beneficio Beneficio in _insertItems)
                        {
                            InsertBeneficio(Beneficio);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (Beneficio Beneficio in _updateItems)
                        {
                            UpdateBeneficio(Beneficio);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (Beneficio Beneficio in _deleteItems)
                        {
                            DeleteBeneficio(Beneficio);
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

        private void InsertBeneficio(Beneficio Beneficio)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beneficio_insertar", new SPP[] { 
                    new SPP("tipo_beneficio", Beneficio.IdTipoBeneficio.ToString()),
                    new SPP("nombre", Beneficio.Nombre),
                    new SPP("descripcion", Beneficio.Descripcion),
                    new SPP("valor", Beneficio.Valor)
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateBeneficio(Beneficio Beneficio)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beneficio_modificar", new SPP[] { 
                    new SPP("id_beneficio", Beneficio.Id.ToString()),
                    new SPP("tipo_beneficio", Beneficio.IdTipoBeneficio.ToString()),
                    new SPP("nombre", Beneficio.Nombre),
                    new SPP("descripcion", Beneficio.Descripcion),
                    new SPP("valor", Beneficio.Valor)
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void DeleteBeneficio(Beneficio Beneficio)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beneficio_eliminar", new SPP[] { 
                    new SPP("id_beneficio", Beneficio.Id.ToString()),
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }


    }
}
