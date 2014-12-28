using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Transactions;
using DAL;
using TIL.CustomExceptions;
namespace EntitiesLayer
{
    public class CarreraRepository : IRepository<Carrera>
    {
        private static CarreraRepository instance;

        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        public CarreraRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();

        }
        public static CarreraRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CarreraRepository();
                }
                return instance;
            }
        }

        public void Insert(Carrera entity)
        {
            _insertItems.Add(entity);
        }

        public void Delete(Carrera entity)
        {
            _deleteItems.Add(entity);
        }

        public void Update(Carrera entity)
        {
            _updateItems.Add(entity);
        }

        public IEnumerable<Carrera> GetAll()
        {
            List<Carrera> lstCarrera = null;

            try
            {

                DataTable dt = DataBaseAccess.advanceStoredProcedureRequest("pa_carrera_listar");

                lstCarrera = new List<Carrera>();
                foreach (DataRow dr in dt.Rows)
                {
                    lstCarrera.Add(new Carrera
                    {
                        Id = Convert.ToInt32(dr["id_carrera"]),
                        Nombre = dr["nombre"].ToString(),
                        Descripcion = dr["descripcion"].ToString(),
                        Icono = dr["icono"].ToString(),
                        Color = dr["color"].ToString()
                    });
                }
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }

            return lstCarrera;
        }

        public Carrera GetById(int idCarrera)
        {

            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_carrera_buscar_id", new SPP[] { 
                new SPP("id_carrera",idCarrera.ToString())
            });

                Carrera carrera = new Carrera(
                int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                tablaResultado.Rows[0].ItemArray[1].ToString(),
                tablaResultado.Rows[0].ItemArray[2].ToString(),
                tablaResultado.Rows[0].ItemArray[3].ToString(),
                tablaResultado.Rows[0].ItemArray[4].ToString()

                );

                return carrera;
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
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
                        foreach (Carrera carrera in _insertItems)
                        {
                            InsertCarrera(carrera);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (Carrera carrera in _updateItems)
                        {
                            UpdateCarrera(carrera);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (Carrera carrera in _deleteItems)
                        {
                            DeleteCarrera(carrera);
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

        private void InsertCarrera(Carrera carrera)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_agregar", new SPP[] { 
                    new SPP("nombre", carrera.Nombre),
                    new SPP("descripcion", carrera.Descripcion),
                    new SPP("icono", carrera.Icono),
                    new SPP("color", carrera.Color)
                });
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }

        }

        private void UpdateCarrera(Carrera carrera)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_modificar", new SPP[] { 
                    new SPP("id_carrera", carrera.Id.ToString()),
                    new SPP("nombre", carrera.Nombre),
                    new SPP("descripcion", carrera.Descripcion),
                    new SPP("icono", carrera.Icono),
                    new SPP("color", carrera.Color)
                });
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        private void DeleteCarrera(Carrera carrera)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_eliminar", new SPP[] { 
                    new SPP("id_carrera", carrera.Id.ToString())
                });
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }



        public void AsignarCursoCarrera(Curso curso, Carrera carrera, int pidPeriodo)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_curso_asignar", new SPP[] { 
                    new SPP("id_curso", curso.Id.ToString()),
                    new SPP("id_carrera", carrera.Id.ToString()),
                    new SPP("periodo", pidPeriodo.ToString())
                });
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        public void DeleteCarreraDirector(int pidUsuario, int pidCarrera)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_director_eliminar", new SPP[] { 
                    new SPP("id_usuario", pidUsuario.ToString()),
                    new SPP("id_carrera", pidCarrera.ToString())
                });
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        public IEnumerable<Curso> listarCursosPorCarrera(int idCarrera)
        {

            List<Curso> lstCurso = null;
            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_carrera_cursos_buscar", new SPP[] { 
                new SPP("id_carrera",idCarrera.ToString())
            });

                lstCurso = new List<Curso>();
                foreach (DataRow dr in tablaResultado.Rows)
                {
                    lstCurso.Add(new Curso
                    {
                        Id = Convert.ToInt32(dr["id_curso"]),
                        Nombre = dr["nombre"].ToString(),
                        Codigo = dr["codigo"].ToString(),
                        Precio = dr["precio"].ToString(),
                        CantidadCreditos = Convert.ToInt32(dr["cantidad_creditos"].ToString())
                    });

                }

                return lstCurso;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCarreraCurso(Carrera carrera, Curso curso)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_curso_eliminar", new SPP[] { 
                    new SPP("id_carrera", carrera.Id.ToString()),
                    new SPP("id_curso", curso.Id.ToString())
                });
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        public void AsignarDirectorCarrera(Usuario usuario, Carrera carrera)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_director_asignar", new SPP[] { 
                    new SPP("id_usuario", usuario.Id.ToString()),
                    new SPP("id_carrera", carrera.Id.ToString())
                });
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        public void DeleteCarreraDirector(Carrera carrera, Usuario usuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_director_eliminar", new SPP[] { 
                    new SPP("id_carrera", carrera.Id.ToString()),
                    new SPP("id_usuario", usuario.Id.ToString())
                });
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        // lista todos los directores academicos de una carrera en especifico
        public IEnumerable<Usuario> listarDirectoresPorCarrera(int idCarrera)
        {

            List<Usuario> lstUsuario = null;
            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_carrera_directores_id_buscar", new SPP[] { 
                new SPP("id_carrera",idCarrera.ToString())
            });

                lstUsuario = new List<Usuario>();
                foreach (DataRow dr in tablaResultado.Rows)
                {
                    lstUsuario.Add(new Usuario
                    {
                        Id = Convert.ToInt32(dr["id_usuario"]),
                        Nombre = dr["nombre_1"].ToString(),
                        PrimerApellido = dr["apellido_1"].ToString(),
                        //Cedula = Convert.ToInt32(dr["cedula"].ToString())
                    });

                }

                return lstUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //lista todos los usuario con rol de director academicos

        public IEnumerable<Usuario> listarDirectoresAcademicos()
        {
            List<Usuario> lstDirectores = null;

            try
            {

                DataTable dt = DataBaseAccess.advanceStoredProcedureRequest("pa_carrera_directores_listar");

                lstDirectores = new List<Usuario>();
                foreach (DataRow dr in dt.Rows)
                {
                    lstDirectores.Add(new Usuario
                    {
                        Id = Convert.ToInt32(dr["id_usuario"]),
                        Nombre = dr["nombre_1"].ToString()
                    });
                }
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }

            return lstDirectores;
        }

        public void asignarEstudianteCarrera(Usuario usuario, Carrera carrera)
        {

            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_estudiante_asignar", new SPP[] { 
                    new SPP("id_usuario", usuario.Id.ToString()),
                    new SPP("id_carrera", carrera.Id.ToString())
                });
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        public void DeleteEstudianteDeCarrera(Carrera carrera, Usuario usuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_carrera_estudiante_eliminar", new SPP[] { 
                    new SPP("id_carrera", carrera.Id.ToString()),
                    new SPP("id_usuario", usuario.Id.ToString())
                });
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }
        }

        public IEnumerable<Usuario> listarEstudiantes()
        {
            List<Usuario> lstEstudiantes = null;

            try
            {

                DataTable dt = DataBaseAccess.advanceStoredProcedureRequest("pa_carrera_estudiantes_listar");

                lstEstudiantes = new List<Usuario>();
                foreach (DataRow dr in dt.Rows)
                {
                    lstEstudiantes.Add(new Usuario
                    {
                        Id = Convert.ToInt32(dr["id_usuario"]),
                        Nombre = dr["nombre_1"].ToString()
                    });
                }
            }

            catch (Exception ex)
            {
                throw new DataAccessException(String.Format("SQL Error: {0}", ex.Message));
            }

            return lstEstudiantes;
        }

        public IEnumerable<Usuario> listarEstudiantesPorCarrera(int idCarrera)
        {

            List<Usuario> lstUsuario = null;
            try
            {
                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_carrera_estudiantes_id_buscar", new SPP[] { 
                new SPP("id_carrera",idCarrera.ToString())
            });

                lstUsuario = new List<Usuario>();
                foreach (DataRow dr in tablaResultado.Rows)
                {
                    lstUsuario.Add(new Usuario
                    {
                        Id = Convert.ToInt32(dr["id_usuario"]),
                        Nombre = dr["nombre_1"].ToString(),
                        PrimerApellido = dr["apellido_1"].ToString(),
                        //Cedula = Convert.ToInt32(dr["cedula"].ToString())
                    });

                }

                return lstUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
