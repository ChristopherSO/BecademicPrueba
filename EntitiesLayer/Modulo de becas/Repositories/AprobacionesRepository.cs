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
    public class AprobacionesRepository
    {
        private static AprobacionesRepository instance;
        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        private AprobacionesRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        public static AprobacionesRepository Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new AprobacionesRepository();
                }
                return instance;
            }
        }

        public void Insert(Aprobacion entity)
        {
            _insertItems.Add(entity);
        }

        public void Delete(Aprobacion entity)
        {
            _deleteItems.Add(entity);
        }

        public void Update(Aprobacion entity)
        {
            _updateItems.Add(entity);
        }

        public IEnumerable<Aprobacion> GetAll()
        {
            List<Aprobacion> lista = new List<Aprobacion>();
            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beca_listar_aprobacion");
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new Aprobacion(
                        int.Parse(fila.ItemArray[0].ToString()),
                        int.Parse(fila.ItemArray[1].ToString()),
                        int.Parse(fila.ItemArray[2].ToString()),
                        DateTime.Parse(fila.ItemArray[3].ToString()),
                        fila.ItemArray[4].ToString(),
                        bool.Parse(fila.ItemArray[5].ToString())
                    ));
                }
                
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
            return lista;
        }

        public Aprobacion GetById(int idAprobacion)
        {
            Aprobacion aprobacion = null;

            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_beca_aprobacion_buscar_id", new SPP[] { 
                new SPP("id_aprobacion", idAprobacion.ToString())
            });

                aprobacion = new Aprobacion(
                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[1].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[2].ToString()),
                    DateTime.Parse(tablaResultado.Rows[0].ItemArray[3].ToString()),
                    tablaResultado.Rows[0].ItemArray[4].ToString(),
                    bool.Parse(tablaResultado.Rows[0].ItemArray[5].ToString())
                ); 
            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }
            return aprobacion;
        }

        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (_insertItems.Count > 0)
                    {
                        foreach (Aprobacion aprobacion in _insertItems)
                        {
                            InsertAprobacion(aprobacion);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (Aprobacion aprobacion in _updateItems)
                        {
                            UpdateAprobacion(aprobacion);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (Aprobacion aprobacion in _deleteItems)
                        {
                            DeleteAprobacion(aprobacion);
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

        private void InsertAprobacion(Aprobacion aprobacion)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_aprobacion_agregar", new SPP[] { 
                    new SPP("id_solicitud", aprobacion.IdSolicitud.ToString()),
                    new SPP("id_usuario", aprobacion.IdUsuario.ToString()),
                    new SPP("fecha", aprobacion.Fecha.ToString("yyyy-MM-dd")),
                    new SPP("comentario", aprobacion.Comentario.ToString()),
                    new SPP("aprobado", aprobacion.Aprobado.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        private void UpdateAprobacion(Aprobacion aprobacion)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_aprobacion_modificar", new SPP[] { 
                    new SPP("id_aprobacion", aprobacion.Id.ToString()),
                    new SPP("id_solicitud", aprobacion.IdSolicitud.ToString()),
                    new SPP("id_usuario", aprobacion.IdUsuario.ToString()),
                    new SPP("fecha", aprobacion.Fecha.ToString("yyyy-MM-dd")),
                    new SPP("comentario", aprobacion.Comentario.ToString()),
                    new SPP("aprobado", aprobacion.Aprobado.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        private void DeleteAprobacion(Aprobacion aprobacion)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_beca_aprobacion_eliminar", new SPP[] { 
                    new SPP("id_aprobacion", aprobacion.Id.ToString()),
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }
    }
}
