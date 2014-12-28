
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Transactions;
using System.Data.SqlClient;
using System.Data;
using DAL;


namespace EntitiesLayer
{
    /// <summary>
    /// Patron singleton
    /// </summary>
    public class PermisoRepositorio : IRepository<PermisoRol>
    {

        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        private static PermisoRepositorio instance;

        private PermisoRepositorio()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        public void Insert(PermisoRol entity)
        {
            _insertItems.Add(entity);
        }

        public void Delete(PermisoRol entity)
        {
            _deleteItems.Add(entity);
        }

        public void Update(PermisoRol entity)
        {
            _updateItems.Add(entity);
        }

        public static PermisoRepositorio Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PermisoRepositorio();
                }
                return instance;
            }
        }

        /// <summary>
        /// Función que consige una lista de todos los permisos en el sistema
        /// No tiene parametros.
        /// </summary>
        /// <returns>Retorna una lista de tipo PermisoRol</returns>

        public IEnumerable<PermisoRol> GetAll()
        {
            List<PermisoRol> lista = new List<PermisoRol>();

            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_permiso_listar");
                foreach (DataRow fila in tablaResultado.Rows)
                {
                    lista.Add(new PermisoRol(

                        int.Parse(fila.ItemArray[0].ToString()),
                        fila.ItemArray[1].ToString(),
                        fila.ItemArray[2].ToString(),
                        fila.ItemArray[3].ToString()
                    ));
                }

                return lista;

            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);
                return lista;
            }

        }

        /// <summary>
        /// Consigue la lista de permisos asociados a un rol.
        /// </summary>
        /// <param name="idRol">Identificaor del rol</param>
        /// <returns>Lisa de permisos de un rol</returns>
        public IEnumerable<PermisoRol> GetPermisosRoles(int idRol)
        {
            Console.WriteLine(idRol);
            List<PermisoRol> lista = new List<PermisoRol>();

            try{

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_permiso_roles_buscar", new SPP[] { 

                new SPP("id_rol", idRol.ToString())

            });


                foreach (DataRow fila in tablaResultado.Rows)

                {
                    lista.Add(new PermisoRol(

                        int.Parse(fila.ItemArray[0].ToString()),
                        fila.ItemArray[1].ToString(),
                        fila.ItemArray[2].ToString(),
                        fila.ItemArray[3].ToString()
                    ));
                }

                return lista;

            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);
                return lista;
            }

        }
        /// <summary>
        /// Consigue una lista de los permisos en el sistema
        /// </summary>
        /// <returns>Lista permisos</returns>
        public DataTable GetInfo()
        {

            SqlCommand cmd = new SqlCommand();
            DataTable tbl = DataBaseAccess.poblarCmb(cmd, "pa_permiso_listar");
            return tbl;
        }
        
        /// <summary>
        /// Retorna la información de un permiso
        /// </summary>
        /// <param name="idPermiso">Identificador del permiso</param>
        /// <returns>Información de un permiso</returns>
        public PermisoRol GetById(int idPermiso)
        {

            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_permiso_buscar_id", new SPP[] { 

                new SPP("id_permiso", idPermiso.ToString()) 

            });

                PermisoRol Permiso = new PermisoRol(

                     int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                     tablaResultado.Rows[0].ItemArray[1].ToString(),
                     tablaResultado.Rows[0].ItemArray[2].ToString(),
                     tablaResultado.Rows[0].ItemArray[3].ToString()
                 );

                return Permiso;

            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {

                throw sqlException;
            }

        }

        /// <summary>
        /// Hace los cambios en la base una vez que las acciones de un CRUD son completadas exitosamente.
        /// </summary>
        /// 
        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (_insertItems.Count > 0)
                    {
                        foreach (PermisoRol PermisoRol in _insertItems)
                        {
                            InsertPermiso(PermisoRol);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (PermisoRol PermisoRol in _updateItems)
                        {
                            UpdatePermiso(PermisoRol);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (PermisoRol PermisoRol in _deleteItems)
                        {
                            DeletePermiso(PermisoRol);
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

        /// <summary>
        /// Limpia los metodos del CRUD
        /// </summary>
        /// 
        public void Clear()
        {
            _insertItems.Clear();
            _deleteItems.Clear();
            _updateItems.Clear();
        }

        private void InsertPermiso(PermisoRol PermisoRol)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_permiso_agregar", new SPP[] { 

                new SPP("nombre", PermisoRol.Nombre),               //1
                new SPP("categoria", PermisoRol.Categoria),         //2
                new SPP("descripcion", PermisoRol.Descripcion)      //3

                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }

        private void UpdatePermiso(PermisoRol PermisoRol)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_permiso_modificar", new SPP[] { 

                new SPP("id_permiso", PermisoRol.Id.ToString()),     //0
                new SPP("nombre", PermisoRol.Nombre),               //1
                new SPP("categoria", PermisoRol.Categoria),         //2
                new SPP("descripcion", PermisoRol.Descripcion)      //3

                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }

        private void DeletePermiso(PermisoRol PermisoRol)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_permiso_eliminar", new SPP[] { 
                    new SPP("id_permiso", PermisoRol.Id.ToString()),
                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }//Fin Metodo Delete


        public void RemoverPermisoRol(int idPermiso, int idRol)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_rol_permiso_remover", new SPP[] { 
                    new SPP("id_permiso", idPermiso.ToString()),
                    new SPP("id_rol", idRol.ToString())
                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }//Fin Metodo remover

        public void AsignarPermisoRol(int idPermiso, int idRol)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_rol_permiso_asignar", new SPP[] { 

                new SPP("id_permiso", idPermiso.ToString()),                //1
                new SPP("id_rol", idRol.ToString())             //2
                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }//Fin clase asignar Permiso

    } //Fin clase RepoPermiso

}//Fin Namespace