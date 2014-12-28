using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Transactions;
using System.Data.SqlClient;
using System.Data;
using DAL;

/**
 * Repositorio de Usuario
 * Objeto encargado de levantar objetos de tipo Usuario bajo demanda del gestor.
 * Permite la comunicacion entre el gestor y los datos mediante objetos.
 **/
namespace EntitiesLayer
{
    /// <summary>
    /// Patron singleton
    /// </summary>
    public class UsuarioRepository : IRepository<Usuario>
    {
        private List<IEntity> _insertItems;
        private List<IEntity> _deleteItems;
        private List<IEntity> _updateItems;

        private static UsuarioRepository instance;

        private UsuarioRepository()
        {
            _insertItems = new List<IEntity>();
            _deleteItems = new List<IEntity>();
            _updateItems = new List<IEntity>();
        }

        public void Insert(Usuario entity)
        {
            _insertItems.Add(entity);
        }

        public void Delete(Usuario entity)
        {
            _deleteItems.Add(entity);
        }

        public void Update(Usuario entity)
        {
            _updateItems.Add(entity);
        }

        public static UsuarioRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UsuarioRepository();
                }
                return instance;
            }
        }

        /// <summary>
        /// Función que consige una lista de todos los permisos en el sistema
        /// No tiene parametros.
        /// </summary>
        /// <returns>Retorna una lista de Usuarios</returns>
        /// 
        public IEnumerable<Usuario> GetAll()
        {

           List<Usuario> lista = new List<Usuario>();

           try {


            DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_usuario_listar");
            foreach (DataRow fila in tablaResultado.Rows){


                lista.Add(new Usuario(
                    int.Parse(fila.ItemArray[0].ToString()),
                    fila.ItemArray[1].ToString(),
                    fila.ItemArray[2].ToString(),
                    fila.ItemArray[3].ToString(),
                    fila.ItemArray[4].ToString(),
                    fila.ItemArray[5].ToString(),
                    fila.ItemArray[6].ToString(),
                    int.Parse(fila.ItemArray[7].ToString()),
                    fila.ItemArray[8].ToString(),
                    fila.ItemArray[9].ToString()
                ));
            }

            return lista;

           }

           catch (Exception ex)
           {

               throw new Exception(String.Format("Error: {0}", ex.Message));

           }

        }

        /// <summary>
        /// Metodo que retorna la información de un usuario usando el correo y contrasena
        /// usados para el login
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="contrasena"></param>
        /// <returns>Retorna un usuario</returns>

        public Usuario GetByCorreoYContrasena(string correo, string contrasena)
        {

            Usuario usuario = new Usuario();

            try {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_usuarios_validar", new SPP[] { 
                    new SPP("correo", correo),
                    new SPP("contrasena", contrasena),
                });

                if(tablaResultado.Rows.Count > 0)
                {
                    if (tablaResultado.Rows[0] != null)
                    {
                        usuario = new Usuario(

                            int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                            tablaResultado.Rows[0].ItemArray[1].ToString(),
                            tablaResultado.Rows[0].ItemArray[2].ToString(),
                            tablaResultado.Rows[0].ItemArray[3].ToString(),
                            tablaResultado.Rows[0].ItemArray[4].ToString(),
                            tablaResultado.Rows[0].ItemArray[5].ToString(),
                            tablaResultado.Rows[0].ItemArray[6].ToString(),
                            int.Parse(tablaResultado.Rows[0].ItemArray[7].ToString()),
                            tablaResultado.Rows[0].ItemArray[8].ToString(),
                            tablaResultado.Rows[0].ItemArray[9].ToString(),
                            int.Parse(tablaResultado.Rows[0].ItemArray[10].ToString())
                        );
                    }
                }
            
                return usuario;

            }
            catch (Exception ex)
            {

                throw new Exception(String.Format("Error. No hay conexión a la base de datos. Revise su conexión a internet o el correcto estado de su archivo de configuración.", ex.Message));

            }

        }

        /// <summary>
        /// Metodo que retorna la información de un usuario consegida usando un ID.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns>Información de un Usuario</returns>
        public Usuario GetById(int idUsuario)
        {

             try {

            DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_usuario_buscar_id", new SPP[] { 

                new SPP("id_usuario", idUsuario.ToString()) 

            });

            Usuario usuario = new Usuario(

                int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                tablaResultado.Rows[0].ItemArray[1].ToString(),
                tablaResultado.Rows[0].ItemArray[2].ToString(),
                tablaResultado.Rows[0].ItemArray[3].ToString(), 
                tablaResultado.Rows[0].ItemArray[4].ToString(),
                tablaResultado.Rows[0].ItemArray[5].ToString(),
                tablaResultado.Rows[0].ItemArray[6].ToString(),
                int.Parse(tablaResultado.Rows[0].ItemArray[7].ToString()),
                tablaResultado.Rows[0].ItemArray[8].ToString(),
                tablaResultado.Rows[0].ItemArray[9].ToString(),
                int.Parse(tablaResultado.Rows[0].ItemArray[10].ToString())
            );

            return usuario;

            }

            catch (Exception ex){

                throw new Exception(String.Format("Error: {0}", ex.Message));
 
            }

        }

        /// <summary>
        /// Metodo que retorna la información de un usuario consegida usando un Carnet.
        /// </summary>
        /// <param name="carnet"></param>
        /// <returns>Usuario</returns>
        public Usuario GetByCarnet(int carnet)
        {
            Usuario usuario = null;
            try
            {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_usuario_buscar_carnet", new SPP[] {

                new SPP("id_carnet", carnet.ToString()) 

            });
                if (tablaResultado.Rows.Count > 0)
                {
                    usuario = new Usuario(

                        int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()),
                        tablaResultado.Rows[0].ItemArray[1].ToString(),
                        tablaResultado.Rows[0].ItemArray[2].ToString(),
                        tablaResultado.Rows[0].ItemArray[3].ToString(),
                        tablaResultado.Rows[0].ItemArray[4].ToString(),
                        tablaResultado.Rows[0].ItemArray[5].ToString(),
                        tablaResultado.Rows[0].ItemArray[6].ToString(),
                        int.Parse(tablaResultado.Rows[0].ItemArray[7].ToString()),
                        tablaResultado.Rows[0].ItemArray[8].ToString(),
                        tablaResultado.Rows[0].ItemArray[9].ToString(),
                        int.Parse(tablaResultado.Rows[0].ItemArray[10].ToString())
                    );
                }
                else
                {
                    usuario = new Usuario();
                }
                

                return usuario;

            }

            catch (Exception ex)
            {

                throw new Exception(String.Format("Error: {0}", ex.Message));

            }

        }

        /// <summary>
        /// Metodo que modifica la contrasena de un Usuario usando su ID.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="pcontra">Contrasena generada por el sistema y encriptada con MD5 posteriormente.</param>
        /// 
        public void cambiarPass(int idUsuario, String pcontra)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_usuario_modificar_contra", new SPP[] { 

                new SPP("id_usuario", idUsuario.ToString()),   //0
                new SPP("contrasena", pcontra)                     //1

                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

        }

        /// <summary>
        /// Metodo que modifica la contrasena de un usuario por una elegida por dicho usuario.
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="old_pass">Contrasena actual</param>
        /// <param name="new_pass">Contrasena elegida por el usuario</param>
        /// <returns>Mensaje de confirmacion, 0 para exitoso y -1 para error</returns>

        public int cambiarPropiaContra(int idUsuario, String old_pass, String new_pass) {

            int result = -1;

            try {

                DataTable tablaResultado = DataBaseAccess.advanceStoredProcedureRequest("pa_usuario_cambiar_propia_contra", new SPP[] { 

                new SPP("id_usuario", idUsuario.ToString()),
                new SPP("old_pass", old_pass.ToString()),
                new SPP("new_pass", new_pass.ToString()),
            });

                if (tablaResultado.Rows.Count > 0) {
                    if (tablaResultado.Rows[0] != null) {

                        result = (int.Parse(tablaResultado.Rows[0].ItemArray[0].ToString()));

                    }

                }            
                
                return result;
            }

            catch (System.Data.SqlClient.SqlException sqlException)
            {

                throw sqlException;


            }

        }

        /// <summary>
        /// Metodo que cambia la nueva contrasena en la base de datos
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="contra"></param>
        public void recuperarPass(String correo, String contra)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_usuarios_recuperar_contra", new SPP[] { 

                new SPP("correo", correo),   //0
                new SPP("contrasena", contra)                     //1

                });
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {

                System.Diagnostics.Debug.Write(sqlException.Message);

            }

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
                        foreach (Usuario Usuario in _insertItems)
                        {
                            InsertUsuario(Usuario);
                        }
                    }

                    if (_updateItems.Count > 0)
                    {
                        foreach (Usuario Usuario in _updateItems)
                        {
                            UpdateUsuario(Usuario);
                        }
                    }

                    if (_deleteItems.Count > 0)
                    {
                        foreach (Usuario Usuario in _deleteItems)
                        {
                            DeleteUsuario(Usuario);
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

        /// <summary>
        /// Inserta un nuevo usuario en la base de datos e instancia un objeto Usuario
        /// </summary>
        /// <param name="Usuario">Objeto usuario, contiene la información para el registro</param>
        private void InsertUsuario(Usuario Usuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_usuario_agregar", new SPP[] { 

                new SPP("nombre_1", Usuario.Nombre),            //1
                new SPP("nombre_2", Usuario.SegundoNombre),     //2
                new SPP("apellido_1", Usuario.PrimerApellido),  //3
                new SPP("apellido_2", Usuario.SegundoApellido), //4
                new SPP("genero", Usuario.Genero),              //5
                new SPP("correo", Usuario.Correo),              //6
                new SPP("contrasena", Usuario.Password),        //7
                new SPP("cedula", Usuario.Cedula.ToString()),   //8
                new SPP("telefono", Usuario.Telefono),          //9
                new SPP("estado", Usuario.Estado.ToString())    //10
                });
            }
            catch (Exception ex)
            {

                throw new Exception(String.Format("Error: {0}", ex.Message));

            }

        }

        /// <summary>
        /// Consige una lista de los estados en el sistema
        /// </summary>
        /// <returns>Lista de estados</returns>
        public DataTable GetEstados()
        {

            SqlCommand cmd = new SqlCommand();
            DataTable tbl = DataBaseAccess.poblarCmb(cmd, "pa_estado_listar");
            return tbl;
        }

        /// <summary>
        /// Modifica un usuario en el sistema.
        /// </summary>
        /// <param name="Usuario">Objeto usuario, contiene la información para la modificación</param>
        private void UpdateUsuario(Usuario Usuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_usuario_modificar", new SPP[] { 

                new SPP("id_usuario", Usuario.Id.ToString()),   //0
                new SPP("nombre_1", Usuario.Nombre),            //1
                new SPP("nombre_2", Usuario.SegundoNombre),     //2
                new SPP("apellido_1", Usuario.PrimerApellido),  //3
                new SPP("apellido_2", Usuario.SegundoApellido), //4
                new SPP("genero", Usuario.Genero),              //5
                new SPP("correo", Usuario.Correo),              //6
                new SPP("cedula", Usuario.Cedula.ToString()),   //7
                new SPP("telefono", Usuario.Telefono),          //8
                new SPP("estado", Usuario.Estado.ToString())    //9
                });
            }
            catch (Exception ex)
            {

                throw new Exception(String.Format("Error: {0}", ex.Message));

            }

        }

        /// <summary>
        /// Elimina un usuario del sistema
        /// </summary>
        /// <param name="Usuario">Objeto usuario, contiene la información para el delete</param>

        private void DeleteUsuario(Usuario Usuario)
        {
            try
            {
                DataBaseAccess.simpleStoredProcedureRequest("pa_usuario_eliminar", new SPP[] { 
                    new SPP("id_usuario", Usuario.Id.ToString()),
                });
            }
            catch (Exception ex)
            {

                throw new Exception(String.Format("Error: {0}", ex.Message));

            }

        }//Fin Metodo Delete

    }//Fin Clase UsuarioRepositorio

}//Fin Namespace
