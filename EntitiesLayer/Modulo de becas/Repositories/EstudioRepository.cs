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
 * Repositorio de Estudios
 * Objeto encargado de levantar objetos de tipo Estudio bajo demanda del gestor.
 * Permite la comunicacion entre el gestor y los datos mediante objetos.
 **/
namespace EntitiesLayer
{

    public class EstudioRepository : IRepository<Estudio>
    {
        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        private static EstudioRepository instance;

        private EstudioRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        public void Insert(Estudio entity)
        {
            _insertItems.Add(entity);
        }

        public void Delete(Estudio entity)
        {
            _deleteItems.Add(entity);
        }

        public void Update(Estudio entity)
        {
            _updateItems.Add(entity);
        }

        public static EstudioRepository Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new EstudioRepository();
                }
                return instance;
            }
        }

        public IEnumerable<Estudio> GetAll()
        {
            List<Estudio> lista = new List<Estudio>();
            try
            {

            DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beca_listar_estudios");
            foreach(DataRow fila in tablaResultado.Rows)
            {
                
                DateTime fecha_estudio = DateTime.Parse(fila.ItemArray[2].ToString());

                Estudio _estudio = new Estudio { 
                    
                    Id = int.Parse(fila.ItemArray[0].ToString()),
                    idUsuarioFuncionario = int.Parse(fila.ItemArray[1].ToString()),
                    fecha = fecha_estudio.Year+"-"+fecha_estudio.Month+"-"+fecha_estudio.Day,
                    resumenEstudio = fila.ItemArray[3].ToString(),
                    esElegible = Boolean.Parse(fila.ItemArray[4].ToString())
                    
                };

                lista.Add(_estudio);

            }

            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }


            return lista;
        }

        public Estudio GetById(int idEstudio)
        {
            Estudio _estudio = new Estudio();

            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beca_detalles_estudio", new SPP[] { 
                    new SPP("id_estudio", idEstudio)
                });

                _estudio = new Estudio { 
            
                    Id = int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    idUsuarioFuncionario = int.Parse(tablaResultado.Rows[0].ItemArray[1].ToString()),
                    fecha = tablaResultado.Rows[0].ItemArray[2].ToString(),
                    resumenEstudio = tablaResultado.Rows[0].ItemArray[3].ToString(),
                    esElegible = Boolean.Parse(tablaResultado.Rows[0].ItemArray[4].ToString())
            
                };

            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }

            return _estudio;
        }

        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (_insertItems.Count > 0)
                    {
                        foreach (Estudio estudio in _insertItems)
                        {
                            InsertEstudio(estudio);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (Estudio estudio in _updateItems)
                        {
                            UpdateEstudio(estudio);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (Estudio estudio in _deleteItems)
                        {
                            DeleteEstudio(estudio);
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

        private void InsertEstudio(Estudio estudio)
        {
            
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_realizar_estudio", new SPP[] { 
                    new SPP("id_usuario_funcionario", estudio.idUsuarioFuncionario),
                    new SPP("fecha", estudio.fecha),
                    new SPP("resumen_socioeconomico", estudio.resumenEstudio),
                    new SPP("es_elegible", estudio.esElegible)
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }

        }

        private void UpdateEstudio(Estudio estudio)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_actualizar_estudio", new SPP[] {
                    new SPP("id_estudio", estudio.Id),
                    new SPP("id_usuario_funcionario", estudio.idUsuarioFuncionario),
                    new SPP("fecha", estudio.fecha),
                    new SPP("resumen_socioeconomico", estudio.resumenEstudio),
                    new SPP("es_elegible", estudio.esElegible)
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        private void DeleteEstudio(Estudio estudio)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_eliminar_estudio", new SPP[] { 
                    new SPP("id_estudio", estudio.Id),
                });
            }
            catch (SqlException ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));

            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

    }
}
