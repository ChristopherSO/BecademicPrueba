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
    /// <author>Marco Durán</author>
    /// <summary>
    /// Repositorio de tipo de becas
    /// Objeto encargado de levantar objetos de tipo Becas bajo demanda del gestor.
    /// Permite la comunicacion entre el gestor y los datos mediante objetos.
    /// </summary>
    public class TipoBecaRepository : IRepository<TipoBeca>
    {
        private static TipoBecaRepository instance;

        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        /// <summary>Crea listas para insertar, eliminar y modificar tipos de beca.</summary>
        private TipoBecaRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        /// <summary>Crea una instacia de un repositorioTipoBeca.</summary>
        /// <valueipoBe>Obtiene una instancia de tipoBecaRepository.</value>
        /// <returns>_tcaRepository tipo: tipoBecaRepository</returns>
        public static TipoBecaRepository Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new TipoBecaRepository();
                }
                return instance;
            }
        }

        /// <summary>
        /// Inserta en la lista _insertItems un tipo de beca.
        /// </summary>
        /// <param name="entity">entity de tipo "TipoBeca"</param>
        public void Insert(TipoBeca entity)
        {
            _insertItems.Add(entity);
        }

        /// <summary>
        /// Inserta en la lista _deleteItems un tipo de beca.
        /// </summary>
        /// <param name="entity">entity de tipo "TipoBeca"</param>
        public void Delete(TipoBeca entity)
        {
            _deleteItems.Add(entity);
        }

        /// <summary>
        /// Inserta en la lista _updateItems un tipo de beca.
        /// </summary>
        /// <param name="entity">entity de tipo "TipoBeca"</param>
        public void Update(TipoBeca entity)
        {
            _updateItems.Add(entity);
        }

        /// <summary>
        /// Consulta a la base de datos todos los tipos de becas registrados en el sistema.
        /// Crea instancias de los tipos de becas consultados.
        /// </summary>
        /// <returns>listaTipoBeca de tipo IEnumerable(TipoBeca)</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<TipoBeca> GetAll()
        {
            List<TipoBeca> lista = new List<TipoBeca>();
            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_tipos_becas_listar");
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new TipoBeca(
                        int.Parse(fila.ItemArray[0].ToString()),
                        fila.ItemArray[1].ToString(),
                        fila.ItemArray[2].ToString(),
                        fila.ItemArray[3].ToString(),
                        fila.ItemArray[4].ToString(),
                        bool.Parse(fila.ItemArray[5].ToString()),
                        int.Parse(fila.ItemArray[6].ToString())
                    ));
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
        /// <param name="idTipoBeca">Id tipo de beca de tipo Integer</param>
        /// <returns>Objeto tipo de beca</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public TipoBeca GetById(int idTipoBeca)
        {
            TipoBeca tipoBeca = null;

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_tipo_beca_buscar_id", new SPP[] { 
                new SPP("id_tipo_beca", idTipoBeca.ToString())
            });

                tipoBeca = new TipoBeca(
                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    tablaResultado.Rows[0].ItemArray[1].ToString(),
                    tablaResultado.Rows[0].ItemArray[2].ToString(),
                    tablaResultado.Rows[0].ItemArray[3].ToString(),
                    tablaResultado.Rows[0].ItemArray[4].ToString(),
                    bool.Parse(tablaResultado.Rows[0].ItemArray[5].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[6].ToString())
                ); 
            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }

            return tipoBeca;
        }

        /// <summary>
        /// Busca tipos de becas consultados por el nombre.
        /// </summary>
        /// <param name="nombre">Nombre de tipo String</param>
        /// <returns>Objeto(s) de tipo de beca de tipo IEnumerable(TipoBeca).</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<TipoBeca> buscarTipoBeca(String nombre)
        {
            List<TipoBeca> lista = new List<TipoBeca>();

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_tipo_beca_buscar", new SPP[] { 
                new SPP("nombre", nombre.ToString())
                });

                if (tablaResultado.Rows.Count > 0)
                {
                    foreach (DataRow fila in tablaResultado.Rows)
                    {
                        lista.Add(new TipoBeca(
                            int.Parse(fila.ItemArray[0].ToString()),
                            fila.ItemArray[1].ToString(),
                            fila.ItemArray[2].ToString(),
                            fila.ItemArray[3].ToString(),
                            fila.ItemArray[4].ToString(),
                            bool.Parse(fila.ItemArray[5].ToString()),
                            int.Parse(fila.ItemArray[6].ToString())
                        ));
                    }
                }
                else
                {
                    lista.Add(new TipoBeca());
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }
            
            return lista;
        }

        /// <summary>
        /// Obtiene los requisitos asociados de un tipo de beca.
        /// </summary>
        /// <param name="idTipoBeca">Id tipo de beca de tipo Integer.</param>
        /// <returns>Lista de requisitos asociados a un tipo de beca de tipo IEnumerable(Requisito).</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Requisito> GetRequisitosBeca(int idTipoBeca)
        {
            List<Requisito> lista = new List<Requisito>();

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_requisitos_beca_buscar", new SPP[] { 
                new SPP("id_tipo_beca", idTipoBeca.ToString())
                });
                
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new Requisito(
                        int.Parse(fila.ItemArray[0].ToString()),
                        int.Parse(fila.ItemArray[1].ToString()),
                        fila.ItemArray[2].ToString(),
                        fila.ItemArray[3].ToString()
                    ));
                }
            }

            catch(Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }

            return lista;
        }

        /// <summary>
        /// Busca los beneficios asociados a un tipo de beca.
        /// </summary>
        /// <param name="idTipoBeca">Id tipo de beca de tipo Integer</param>
        /// <returns>Lista de beneficios asociados a un tipo de beca de tipo IEnumerable(Beneficio).</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Beneficio> GetBeneficiosBeca(int idTipoBeca)
        {
            List<Beneficio> lista = new List<Beneficio>();

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beneficio_beca_buscar", new SPP[] { 
                new SPP("id_tipo_beca", idTipoBeca.ToString())
            });

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
            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }
            
            return lista;
        }

        /// <summary>
        /// Busca los tipos de beca asociados a un beneficio.
        /// </summary>
        /// <param name="idBeneficio">Id beneficio de tipo Integer</param>
        /// <returns>Lista de tipos de beca asociados a un beneficio de tipo IEnumerable(TipoBeca).</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<TipoBeca> GetTiposDeBecaPorIdBeneficio(int idBeneficio)
        {
            List<TipoBeca> lista = new List<TipoBeca>();

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_tipo_beca_buscar_id_beneficio", new SPP[] { 
                new SPP("id_beneficio", idBeneficio.ToString())
            });

                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new TipoBeca());
                }
            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }

            return lista;
        }

        /// <summary>
        /// Busca las carreras asociadas a un tipo de beca.
        /// </summary>
        /// <param name="idTipoBeca">Id tipo de beca de tipo Integer</param>
        /// <returns>Lista de carreras asociadas a un tipo de beca de tipo IEnumerable(Carrera).</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Carrera> GetCarrerasBeca(int idTipoBeca)
        {
            List<Carrera> lista = new List<Carrera>();

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_carreras_beca_buscar", new SPP[] { 
                new SPP("id_tipo_beca", idTipoBeca.ToString())
            });

                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new Carrera(
                        int.Parse(fila.ItemArray[0].ToString()),
                        fila.ItemArray[1].ToString(),
                        fila.ItemArray[2].ToString(),
                        fila.ItemArray[3].ToString(),
                        fila.ItemArray[4].ToString()
                    ));
                }
            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }

            return lista;
        }

        /// <summary>
        /// Obtiene todos los beneficios registrados para luego cargarlos al combobox de Aministrar beneficios a un tipo de beca.
        /// </summary>
        /// <returns>Lista de beneficios de tipo IEnumerable(Beneficio).</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Beneficio> GetBeneficios()
        {
            List<Beneficio> lista = new List<Beneficio>();

            try
            {
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
            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }
            
            return lista;
        }

        /// <summary>
        /// Obtiene la lista de requisitos registrados para luego cargarlos al combobox de administrar requisitos a un tipo de beca.
        /// </summary>
        /// <returns>Lista de requisitos de tipo IEnumerable(Requisito)</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Requisito> GetRequisitos()
        {
            List<Requisito> lista = new List<Requisito>();

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_requisito_listar");
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new Requisito(
                        int.Parse(fila.ItemArray[0].ToString()),
                        int.Parse(fila.ItemArray[1].ToString()),
                        fila.ItemArray[2].ToString(),
                        fila.ItemArray[3].ToString()
                    ));
                }
            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }

            return lista;
        }

        /// <summary>
        /// Obtiene la lista de carreras registradas para luego llenarlos a los combobox a un tipo de beca.
        /// </summary>
        /// <returns>Lista de carreras de tipo IEnumerable(Carrera)</returns>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public IEnumerable<Carrera> GetCarreras()
        {
            List<Carrera> lista = new List<Carrera>();

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_carrera_listar");
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new Carrera(
                        int.Parse(fila.ItemArray[0].ToString()),
                        fila.ItemArray[1].ToString(),
                        fila.ItemArray[2].ToString(),
                        fila.ItemArray[3].ToString(),
                        fila.ItemArray[4].ToString()
                    ));
                }
            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }
            
            return lista;
        }

        /// <summary>
        /// Crea un objeto de tipo TransactionScope que llama a los métodos InsertTipoBeca, UpdateTipoBeca o DeleteTipoBeca
        /// </summary>
        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (_insertItems.Count > 0)
                    {
                        foreach (TipoBeca tipoBeca in _insertItems)
                        {
                            InsertTipoBeca(tipoBeca);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (TipoBeca tipoBeca in _updateItems)
                        {
                            UpdateTipoBeca(tipoBeca);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (TipoBeca tipoBeca in _deleteItems)
                        {
                            DeleteTipoBeca(tipoBeca);
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

        /// <summary>
        /// Limpia los datos que tiene _insertItems, _deleteItems y _updateItems.
        /// </summary>
        public void Clear()
        {
            _insertItems.Clear();
            _deleteItems.Clear();
            _updateItems.Clear();
        }

        /// <summary>
        /// Inserta el tipo de beca a la base de datos.
        /// </summary>
        /// <param name="tipoBeca">objBeca de tipo "TipoBeca"</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        private void InsertTipoBeca(TipoBeca tipoBeca)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_tipo_beca_agregar", new SPP[] { 
                    new SPP("nombre", tipoBeca.Nombre),
                    new SPP("descripcion", tipoBeca.Descripcion),
                    new SPP("icono", tipoBeca.Icono),
                    new SPP("color", tipoBeca.Color),
                    new SPP("socioeconomico", tipoBeca.Socioeconomico.ToString()),
                    new SPP("cantidad", tipoBeca.Cantidad.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Asigna beneficios a un tipo de beca
        /// </summary>
        /// <param name="pidTipoBeca">Id tipo de beca de tipo Integer</param>
        /// <param name="pidBeneficio">Id beneficio de tipo Integer</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public void AsignarBeneficioBeca(int pidTipoBeca, int pidBeneficio)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beneficio_beca_asignar", new SPP[] { 
                    new SPP("id_tipo_beca", pidTipoBeca.ToString()),
                    new SPP("id_beneficio", pidBeneficio.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Asigna requisitos a un tipo de beca
        /// </summary>
        /// <param name="pidTipoBeca">Id tipo de beca de tipo Integer</param>
        /// <param name="pidRequisito">Id requisito de tipo Integer</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public void AsignarRequisitoBeca(int pidTipoBeca, int pidRequisito)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_requisito_beca_asignar", new SPP[] { 
                    new SPP("id_tipo_beca", pidTipoBeca.ToString()),
                    new SPP("id_requisito", pidRequisito.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Asigna carreras a un tipo de beca
        /// </summary>
        /// <param name="pidTipoBeca">Id tipo de beca de tipo Integer</param>
        /// <param name="pidCarrera">Id carrera de tipo Integer</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public void AsignarCarreraBeca(int pidTipoBeca, int pidCarrera)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_beca_asignar", new SPP[] { 
                    new SPP("id_tipo_beca", pidTipoBeca.ToString()),
                    new SPP("id_carrera", pidCarrera.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Modifica una instancia de tipo de beca
        /// </summary>
        /// <param name="tipoBeca">objBeca de tipo TipoBeca</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        private void UpdateTipoBeca(TipoBeca tipoBeca)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_tipo_beca_modificar", new SPP[] { 
                    new SPP("id_tipo_beca", tipoBeca.Id.ToString()),
                    new SPP("nombre", tipoBeca.Nombre),
                    new SPP("descripcion", tipoBeca.Descripcion),
                    new SPP("icono", tipoBeca.Icono),
                    new SPP("color", tipoBeca.Color),
                    new SPP("socioeconomico", tipoBeca.Socioeconomico.ToString()),
                    new SPP("cantidad", tipoBeca.Cantidad.ToString())
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
        /// <param name="tipoBeca">objBeca de tipo TipoBeca</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        private void DeleteTipoBeca(TipoBeca tipoBeca)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_tipo_beca_eliminar", new SPP[] { 
                    new SPP("id_tipo_beca", tipoBeca.Id.ToString()),
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Elimina un requisito asignado a un tipo de beca.
        /// </summary>
        /// <param name="idRequisito">Id requisito de tipo Integer</param>
        /// <param name="idTipoBeca">IdTipoBeca de tipo Integer</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public void DeleteRequisitoBeca(int idRequisito, int idTipoBeca)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_requisito_beca_eliminar", new SPP[] { 
                    new SPP("id_requisito", idRequisito.ToString()),
                    new SPP("id_tipo_beca", idTipoBeca.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Elimina un beneficio asignado a un tipo de beca.
        /// </summary>
        /// <param name="idBeneficio">Id beneficio de tipo Integer.</param>
        /// <param name="idTipoBeca">IdTipoBeca de tipo Integer.</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public void DeleteBeneficioBeca(int idBeneficio, int idTipoBeca)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beneficio_beca_eliminar", new SPP[] { 
                    new SPP("id_beneficio", idBeneficio.ToString()),
                    new SPP("id_tipo_beca", idTipoBeca.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Elimina una carrera asignada a un tipo de beca.
        /// </summary>
        /// <param name="idCarrera">IdCarrera de tipo Integer.</param>
        /// <param name="idTipoBeca">IdTipoBeca de tipo Integer.</param>
        /// <exception cref="System.Exception">Se crea una nueva excepción por una mala ejecución del SQL.</exception>
        public void DeleteCarreraBeca(int idCarrera, int idTipoBeca)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_beca_eliminar", new SPP[] { 
                    new SPP("id_carrera", idCarrera.ToString()),
                    new SPP("id_tipo_beca", idTipoBeca.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }
    }
}
