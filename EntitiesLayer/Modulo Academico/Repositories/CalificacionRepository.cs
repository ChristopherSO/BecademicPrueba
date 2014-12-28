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
    public class CalificacionRepository : IRepository<Calificacion>
    {

        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        private static CalificacionRepository instance;

        private CalificacionRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        public void Insert(Calificacion entity)
        {
            _insertItems.Add(entity);
        }

        public void Delete(Calificacion entity)
        {
            _deleteItems.Add(entity);
        }

        public void Update(Calificacion entity)
        {
            _updateItems.Add(entity);
        }

        public static CalificacionRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CalificacionRepository();
                }
                return instance;
            }
        }

        public IEnumerable<Calificacion> GetByUsuario(int idUsuario, int idCarrera)
        {
            List<Calificacion> lista = new List<Calificacion>();
            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_calificacion_listar", new SPP[] { 
                new SPP("id_usuario", idUsuario.ToString()),
                new SPP("id_carrera", idCarrera.ToString())
            });

                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new Calificacion(
                        int.Parse(fila.ItemArray[0].ToString()),
                        int.Parse(fila.ItemArray[1].ToString()),
                        int.Parse(fila.ItemArray[2].ToString()),
                        double.Parse(fila.ItemArray[3].ToString()),
                        int.Parse(fila.ItemArray[4].ToString()),
                        int.Parse(fila.ItemArray[5].ToString()),
                        fila.ItemArray[6].ToString()

                    ));
                }
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }


            return lista;
        }

        public IEnumerable<Calificacion> GetAll()
        {
            List<Calificacion> lista = new List<Calificacion>();
            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_calificacion_listar");

                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new Calificacion(
                        int.Parse(fila.ItemArray[0].ToString()),
                        int.Parse(fila.ItemArray[1].ToString()),
                        int.Parse(fila.ItemArray[2].ToString()),
                        double.Parse(fila.ItemArray[3].ToString()),
                        int.Parse(fila.ItemArray[4].ToString()),
                        int.Parse(fila.ItemArray[5].ToString()),
                        fila.ItemArray[6].ToString()

                    ));
                }

            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }


            return lista;
        }

        public Calificacion GetById(int idCalificacion)
        {
            Calificacion calificacion = new Calificacion();

            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_calificacion_id_buscar", new SPP[] { 
                        new SPP("id_calificacion", idCalificacion.ToString())
                    });

                calificacion = new Calificacion(
                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[1].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[2].ToString()),
                    double.Parse(tablaResultado.Rows[0].ItemArray[3].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[4].ToString()),
                    int.Parse(tablaResultado.Rows[0].ItemArray[5].ToString()),
                    tablaResultado.Rows[0].ItemArray[6].ToString()
                );

            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }

            return calificacion;
        }

        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (_insertItems.Count > 0)
                    {
                        foreach (Calificacion calificacion in _insertItems)
                        {
                            InsertCalificacion(calificacion);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (Calificacion calificacion in _updateItems)
                        {
                            UpdateCalificacion(calificacion);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (Calificacion calificacion in _deleteItems)
                        {
                            DeleteCalificacion(calificacion);
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

        private void InsertCalificacion(Calificacion calificacion)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_calificacion_insertar", new SPP[] { 
                    new SPP("id_usuario", calificacion.IdUsuario.ToString()),
                    new SPP("id_curso", calificacion.IdCurso.ToString()),
                    new SPP("calificacion", calificacion.Nota.ToString()),
                    new SPP("periodo", calificacion.Periodo.ToString()),
                    new SPP("annio", calificacion.Annio.ToString()),
                    new SPP("comentarios_adicionales", calificacion.Comentarios)
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }

        }

        private void UpdateCalificacion(Calificacion calificacion)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_calificacion_actualizar", new SPP[] {
                    new SPP("id_calificacion", calificacion.Id.ToString()),
                    new SPP("id_curso", calificacion.IdCurso.ToString()),
                    new SPP("calificacion", calificacion.Nota.ToString()),
                    new SPP("periodo", calificacion.Periodo.ToString()),
                    new SPP("annio", calificacion.Annio.ToString()),
                    new SPP("comentarios_adicionales", calificacion.Comentarios)
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        private void DeleteCalificacion(Calificacion calificacion)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_calificacion_eliminar", new SPP[] { 
                        new SPP("id_calificacion", calificacion.Id.ToString())
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