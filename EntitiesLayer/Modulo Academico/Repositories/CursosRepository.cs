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
 * Objeto encargado de levantar objetos de tipo Curso bajo demanda del gestor.
 * Permite la comunicacion entre el gestor y los datos mediante objetos.
 **/
namespace EntitiesLayer
{

    public class CursosRepository : IRepository<Curso>
    {
        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        private static CursosRepository instance;

        private CursosRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        public void Insert(Curso entity)
        {
            _insertItems.Add(entity);
        }

        public void Delete(Curso entity)
        {
            _deleteItems.Add(entity);
        }

        public void Update(Curso entity)
        {
            _updateItems.Add(entity);
        }

        public static CursosRepository Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new CursosRepository();
                }
                return instance;
            }
        }

        public IEnumerable<Curso> GetAll()
        {
            List<Curso> lista = new List<Curso>();
            try
            {

            DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_select_cursos");
            foreach(DataRow fila in tablaResultado.Rows)
            {
                lista.Add(new Curso(
                    int.Parse(fila.ItemArray[0].ToString()),
                    fila.ItemArray[1].ToString(),
                    fila.ItemArray[2].ToString(),
                    fila.ItemArray[3].ToString(),
                    int.Parse(fila.ItemArray[4].ToString())

                ));
            }

            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }


            return lista;
        }

        public Curso GetById(int idCurso)
        {
            Curso curso = new Curso();

            try
            {

            DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_select_cursos_id", new SPP[] { 
                new SPP("id_curso", idCurso.ToString())
            });

            curso = new Curso(
                int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                tablaResultado.Rows[0].ItemArray[1].ToString(),
                tablaResultado.Rows[0].ItemArray[2].ToString(),
                tablaResultado.Rows[0].ItemArray[3].ToString(),
                int.Parse(tablaResultado.Rows[0].ItemArray[4].ToString())
            );

            }

            catch (Exception ex)
            {
                throw new Exception(String.Format("SQL Error: {0}", ex.Message));
            }

            return curso;
        }

        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (_insertItems.Count > 0)
                    {
                        foreach (Curso Curso in _insertItems)
                        {
                            InsertCurso(Curso);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (Curso Curso in _updateItems)
                        {
                            UpdateCurso(Curso);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (Curso Curso in _deleteItems)
                        {
                            DeleteCurso(Curso);
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

        private void InsertCurso(Curso Curso)
        {
            
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_insert_curso", new SPP[] { 
                    new SPP("nombre", Curso.Nombre),
                    new SPP("codigo", Curso.Codigo),
                    new SPP("precio", Curso.Precio),
                    new SPP("cantidad_creditos", Curso.CantidadCreditos.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }

        }

        private void UpdateCurso(Curso Curso)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_update_curso", new SPP[] { 
                    new SPP("id_curso", Curso.Id.ToString()),
                    new SPP("nombre", Curso.Nombre),
                    new SPP("codigo", Curso.Codigo),
                    new SPP("precio", Curso.Precio),
                    new SPP("cantidad_creditos", Curso.CantidadCreditos.ToString())
                });
            }
            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        private void DeleteCurso(Curso Curso)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_delete_curso", new SPP[] { 
                    new SPP("id_curso", Curso.Id.ToString()),
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
