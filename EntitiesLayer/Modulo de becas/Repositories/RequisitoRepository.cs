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
 * Repositorio de cursos
 * Objeto encargado de levantar objetos de tipo Requisito bajo demanda del gestor.
 * Permite la comunicacion entre el gestor y los datos mediante objetos.
 **/
namespace EntitiesLayer
{

    public class RequisitoRepository : IRepository<Requisito>
    {
        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        private static RequisitoRepository instance;

        private RequisitoRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        public void Insert(Requisito entity)
        {
            _insertItems.Add(entity);
        }

        public void Delete(Requisito entity)
        {
            _deleteItems.Add(entity);
        }

        public void Update(Requisito entity)
        {
            _updateItems.Add(entity);
        }

        public static RequisitoRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RequisitoRepository();
                }
                return instance;
            }
        }

        public IEnumerable<Requisito> GetAll()
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

                return lista;
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

        public Requisito GetById(int idRequisito)
        {
            Requisito Requisito = null;

            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_requisito_id_buscar", new SPP[] { 
                new SPP("id_requisito", idRequisito.ToString())
            });

                return new Requisito(
                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[1].ToString()),
                    tablaResultado.Rows[0].ItemArray[2].ToString(),
                    tablaResultado.Rows[0].ItemArray[3].ToString()
                );
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);
                return Requisito;
            }
        }

        public TipoRequisito buscarTipoRequisitoPorId(int idTipoRequisito)
        {
            TipoRequisito TipoRequisito = null;

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_tipo_requisito_id_buscar", new SPP[] { 
                new SPP("id_tipo_requisito", idTipoRequisito.ToString())
            });
                return new TipoRequisito(
                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    tablaResultado.Rows[0].ItemArray[1].ToString()
                );
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {
                System.Diagnostics.Debug.Write(sqlException.Message);
                return TipoRequisito;
            }
        }


        public IEnumerable<TipoRequisito> consultarTipoRequisitos()
        {
            List<TipoRequisito> lista = new List<TipoRequisito>();
            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_tipo_requisito_listar");
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new TipoRequisito(
                        int.Parse(fila.ItemArray[0].ToString()),
                        fila.ItemArray[1].ToString(),
                        fila.ItemArray[2].ToString(),
                        fila.ItemArray[3].ToString()
                    ));
                }

                return lista;
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


        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (_insertItems.Count > 0)
                    {
                        foreach (Requisito Requisito in _insertItems)
                        {
                            InsertRequisito(Requisito);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (Requisito Requisito in _updateItems)
                        {
                            UpdateRequisito(Requisito);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (Requisito Requisito in _deleteItems)
                        {
                            DeleteRequisito(Requisito);
                        }
                    }

                    scope.Complete();
                }
                catch (TransactionAbortedException ex)
                {
                    throw new TransactionAbortedException(String.Format("Error: {0}", ex.Message));
                }
                catch (ApplicationException ex)
                {
                    throw new ApplicationException(String.Format("Error: {0}", ex.Message));
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

        private void InsertRequisito(Requisito Requisito)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_requisito_insertar", new SPP[] { 
                    new SPP("tipo_requisitos", Requisito.IdTipoRequisito.ToString()),
                    new SPP("nombre", Requisito.Nombre),
                    new SPP("descripcion", Requisito.Descripcion)
                });
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

        private void UpdateRequisito(Requisito Requisito)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_requisito_actualizar", new SPP[] { 
                    new SPP("id_requisito", Requisito.Id.ToString()),
                    new SPP("tipo_requisitos", Requisito.IdTipoRequisito.ToString()),
                    new SPP("nombre", Requisito.Nombre),
                    new SPP("descripcion", Requisito.Descripcion)
                });
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

        private void DeleteRequisito(Requisito requisito)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_requisito_eliminar", new SPP[] { 
                    new SPP("id_requisito", requisito.Id.ToString()),
                });
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