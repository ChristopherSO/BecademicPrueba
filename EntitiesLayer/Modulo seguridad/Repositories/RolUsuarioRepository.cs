using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Transactions;
using System.Data.SqlClient;
using System.Data;
using DAL;


namespace EntitiesLayer {

    /// <summary>
    /// Patron singleton
    /// </summary>
    public class RolUsuarioRepository : IRepository<RolUsuario>{
    
        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        private static RolUsuarioRepository instance;

        private RolUsuarioRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        public void Insert(RolUsuario entity)
        {
            _insertItems.Add(entity);
        }

        public void Delete(RolUsuario entity)
        {
            _deleteItems.Add(entity);
        }

        public void Update(RolUsuario entity)
        {
            _updateItems.Add(entity);
        }

        public static RolUsuarioRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RolUsuarioRepository();
                }
                return instance;
            }
        }

        /// <summary>
        /// Función que consige una lista de todos los permisos en el sistema
        /// No tiene parametros.
        /// <returns>Retorna una lista de roles.</returns>
        public IEnumerable<RolUsuario> GetAll()
        {
            List<RolUsuario> lista = new List<RolUsuario>();

            try{

            DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_rol_listar");
            foreach (DataRow fila in tablaResultado.Rows)
            {
                lista.Add(new RolUsuario(

                    int.Parse(fila.ItemArray[0].ToString()),
                    fila.ItemArray[1].ToString(),
                    fila.ItemArray[2].ToString(),
                    int.Parse(tablaResultado.Rows[0].ItemArray[3].ToString()),
                    fila.ItemArray[4].ToString()
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
        /// Retorna una lista de Roles asociadas a un usuario
        /// </summary>
        /// <param name="idUsuario">Id del usuario del cual se desea conocer los roles</param>
        /// <returns>Lista de roles de dicho usuario</returns>
        public IEnumerable<RolUsuario> GetRolesUsuario(int idUsuario)
        {
            Console.WriteLine(idUsuario);
            List<RolUsuario> lista = new List<RolUsuario>();

            try{

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_usuario_roles_buscar", new SPP[] { 

                new SPP("id_usuario", idUsuario.ToString())

            });


                foreach (DataRow fila in tablaResultado.Rows)

                {
                    lista.Add(new RolUsuario(

                        int.Parse(fila.ItemArray[0].ToString()),
                        fila.ItemArray[1].ToString(),
                        fila.ItemArray[2].ToString(),
                        int.Parse(fila.ItemArray[3].ToString())
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
        /// Retorna la inormación de un rol por ID .
        /// </summary>
        /// <param name="idRol">Id del rol a consultar</param>
        /// <returns>Información de este rol</returns>
        public RolUsuario GetById(int idRol)
        {
            RolUsuario rol = null;
            try {

            DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_rol_buscar_id", new SPP[] { 

                new SPP("id_rol", idRol.ToString()) 

            });

            if (tablaResultado.Rows.Count > 0)
            {
                rol = new RolUsuario(

                    int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                    tablaResultado.Rows[0].ItemArray[1].ToString(),
                    tablaResultado.Rows[0].ItemArray[2].ToString(),
                    int.Parse(tablaResultado.Rows[0].ItemArray[3].ToString()),
                    tablaResultado.Rows[0].ItemArray[4].ToString()
                );
            }
            else
            {
                rol = new RolUsuario();
            }

           

           return rol;

            }

             catch (System.Data.SqlClient.SqlException sqlException)
             {

                 throw sqlException;
            }

        }

        /// <summary>
        /// Retorna una lista de roles lista para insertar en un combobox
        /// </summary>
        /// <returns>Información de los roles en una lista para un combobox</returns>
        public DataTable GetInfo()
        {

            SqlCommand cmd = new SqlCommand();
            DataTable tbl = DataBaseAccess.poblarCmb(cmd, "pa_rol_listar");
            return tbl;
        }

        /// <summary>
        /// Hace los cambios en la base una vez que las acciones de un CRUD son completadas exitosamente.
        /// </summary>

        public void Save()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    if (_insertItems.Count > 0)
                    {
                        foreach (RolUsuario RolUsuario in _insertItems)
                        {
                            InsertRol(RolUsuario);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (RolUsuario RolUsuario in _updateItems)
                        {
                            UpdateRol(RolUsuario);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (RolUsuario RolUsuario in _deleteItems)
                        {
                            DeleteRol(RolUsuario);
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
        public void Clear()
        {
            _insertItems.Clear();
            _deleteItems.Clear();
            _updateItems.Clear();
        }

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos e instancia un objeto Rol
        /// </summary>
        /// <param name="RolUsuario">Objeto rol, contiene la información para el registro</param>
        private void InsertRol(RolUsuario RolUsuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_rol_agregar", new SPP[] { 

                new SPP("nombre", RolUsuario.Nombre),               //1
                new SPP("descripcion", RolUsuario.Descripcion),     //2
                new SPP("intervencion", RolUsuario.Intervencion.ToString() ),  //3

                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }

        /// <summary>
        /// Modifica un usuario en el sistema.
        /// </summary>
        /// <param name="RolUsuario">Objeto rol, contiene la información para la modificación</param>
        private void UpdateRol(RolUsuario RolUsuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_rol_modificar", new SPP[] { 

                new SPP("id_rol", RolUsuario.Id.ToString()),        //0
                new SPP("nombre", RolUsuario.Nombre),               //1
                new SPP("descripcion", RolUsuario.Descripcion),     //2
                new SPP("intervencion", RolUsuario.Intervencion.ToString() ),  //3
                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }

        /// <summary>
        /// Consigue una lista de las fases de intervención de un rol.
        /// </summary>
        /// <returns>Cantidad de intervenciones de cada rol</returns>

        public DataTable GetFases()
        {

            SqlCommand cmd = new SqlCommand();
            DataTable tbl = DataBaseAccess.poblarCmb(cmd, "pa_intervenciones_listar");
            return tbl;
        }

        /// <summary>
        /// Elimina un rol del sistema
        /// </summary>
        /// <param name="RolUsuario">Objeto rol, contiene la información para el delete</param>
        private void DeleteRol(RolUsuario RolUsuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_rol_eliminar", new SPP[] { 
                    new SPP("id_rol", RolUsuario.Id.ToString()),
                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }//Fin Metodo Delete

        /// <summary>
        /// Remueve la asociación de un rol con usuario 
        /// </summary>
        /// <param name="idRol">Identificador del rol</param>
        /// <param name="idUsuario">Identificador del usuario</param>
        public void RemoverRolesUsuario(int idRol, int idUsuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_usuario_roles_eliminar", new SPP[] { 
                    new SPP("id_rol", idRol.ToString()),
                    new SPP("id_usuario", idUsuario.ToString())
                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }//Fin Metodo remover


        /// <summary>
        /// Crea la asociación de un rol con usuario 
        /// </summary>
        /// <param name="idRol">Identificador del rol</param>
        /// <param name="idUsuario">Identificador del usuario</param>
        public void AsignarRolesUsuario(int idRol, int idUsuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_usuario_roles_asignar", new SPP[] { 

                new SPP("id_usuario", idUsuario.ToString()),    //1
                new SPP("id_rol", idRol.ToString())             //2
                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }//Fin clase asignar rol

    } //Fin clase RepoRol

}//Fin Namespace
