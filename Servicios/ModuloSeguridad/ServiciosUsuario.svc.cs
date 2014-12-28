using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using BLL;
using UI;
using EntitiesLayer;

namespace Servicios.ModuloSeguridad
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]

    public class ServiciosUsuario
    {

        private GestorUsuario gestorUsuario;
        private GestorRol gestorRol;

        /// <summary>
        /// Crea una instancia al gestor usuario
        /// </summary>
        public ServiciosUsuario()
        {
            gestorUsuario = new GestorUsuario();
            gestorRol = new GestorRol(); 
        }

        [OperationContract]
        [WebGet(UriTemplate = "/logeo?correo={correo}&clave={clave}", ResponseFormat = WebMessageFormat.Json)]
        public Usuario logeoDeUsuarios(string correo, string clave)
        {
            Usuario _usuario = new Usuario();

            GestorAuth _auth = new GestorAuth();

            Encrypt contraSegura = new Encrypt();


            if(_auth.validarIngreso(correo, contraSegura.getSHA1Hash(clave)))
            {
                _usuario = _auth.UsuarioActual;
            }

            return _usuario;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/recuperar?correo={correo}", ResponseFormat = WebMessageFormat.Json)]
        public bool recuperarContrasena(string correo)
        {
            IEnumerable<Usuario> _usuarios = gestorUsuario.consultarUsuario();
            Usuario _usuarioExistente = new Usuario();

            bool exite = false;
            foreach(Usuario usr in _usuarios)
            {
                if(usr.Correo == correo)
                {
                    exite = true;
                    _usuarioExistente = usr;
                }
            }

            if(exite)
            {
                String contra = _usuarioExistente.randomPass(5).ToString();
                Encrypt encriptacion = new Encrypt();
                String contra_segura = encriptacion.getSHA1Hash(contra);
                gestorUsuario.editarContraCorreo(correo, contra_segura);
                GestorCorreo gestorCorreo = new GestorCorreo();
                gestorCorreo.enviarCorreo(correo, "BECADEMIC- Nueva Contraseña", "Su contraseña a sido cambiada a " + contra);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Consigue una lista de todos los usuarios en el sistema
        /// </summary>
        /// <returns>Lista Usuarios</returns>

        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Usuario> ListarUsuarios()
        {
            IEnumerable<Usuario> lstUsuario = gestorUsuario.consultarUsuario();
            return lstUsuario;
        }

        /// <summary>
        /// Consigue los detalles de un Usuario utilizando su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto usuario</returns>


        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Usuario InformacionDeUsuario(string id)
        {
            Usuario usuario = gestorUsuario.consultarUsuario(int.Parse(id));

            if (usuario == null)
            {
                usuario = new Usuario();
            }

            return usuario;
        }



        [OperationContract]
        [WebGet(UriTemplate = "/crear?nombre={nombre}&apellido={apellido1}&genero={genero}&correo={correo}&cedula={cedula}&estado={estado}&nombre2={nombre2}&apellido2={apellido2}&telefono={telefono}", ResponseFormat = WebMessageFormat.Json)]
        public bool AgregarUsuario(String nombre, String apellido1, String genero, String correo, String cedula, String estado,
                                 String nombre2 = "N/A", String apellido2 = "N/A", String telefono = "N/A")
        {

            IEnumerable<Usuario> listaVieja = gestorUsuario.consultarUsuario();

            Usuario usuario = new Usuario();

            String contra = usuario.randomPass(5).ToString();

            gestorUsuario.agregarUsuario(nombre, apellido1, genero, correo, contra, int.Parse(cedula),
                                              int.Parse(estado), nombre2, apellido2, telefono);

            IEnumerable<Usuario> listaNueva = gestorUsuario.consultarUsuario();

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/actualizar?id={id}&nombre={nombre}&apellido={apellido1}&genero={genero}&correo={correo}&cedula={cedula}&estado={estado}&nombre2={nombre2}&apellido2={apellido2}&telefono={telefono}",
        ResponseFormat = WebMessageFormat.Json)]


        public bool ModificarUsuario(String id, String nombre, String apellido1, String genero, String correo, String cedula, String estado,
                                 String nombre2 = "N/A", String apellido2 = "N/A", String telefono = "N/A")
        {

            Usuario usuarioViejo = gestorUsuario.consultarUsuario(int.Parse(id));

            gestorUsuario.editarUsuario(int.Parse(id), nombre, apellido1, genero, correo,
                                        int.Parse(cedula), int.Parse(estado), nombre2, apellido2, telefono);

            Usuario usuarioNuevo = gestorUsuario.consultarUsuario(int.Parse(id));

            if (ObjectUtils.IsALike(usuarioViejo, usuarioNuevo))
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/borrar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool EliminarUsuario(string id)
        {
            IEnumerable<Usuario> listaVieja = gestorUsuario.consultarUsuario();

            gestorUsuario.eliminarUsuario(int.Parse(id));

            IEnumerable<Usuario> listaNueva = gestorUsuario.consultarUsuario();

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/changepass/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool ModificarPassUsuario(string id)
        {
            Usuario usuario = new Usuario();
            GestorCorreo gestorCorreo = new GestorCorreo();
            String pass = usuario.randomPass(5);
            String secure_pass = encriptar(pass);

            try {
                usuario = gestorUsuario.consultarUsuario(int.Parse(id));
                gestorUsuario.editarContraUsuario(int.Parse(id), secure_pass);
                gestorCorreo.enviarCorreo(usuario.Correo, "BECADEMIC- Nueva Contraseña", "Su contraseña a sido cambiada a " + pass);
                return true;
            }
            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
                
            }

       }

        private String encriptar(String pass)
        {

        String secure_pass;
        Encrypt hash = new Encrypt();
        secure_pass = hash.getSHA1Hash(pass);

        return secure_pass;

        }

        /// <summary>
        /// Consigue una lista de todos los Roles de un usuario
        /// </summary>
        /// <returns>Lista Rols</returns>

        [OperationContract]
        [WebGet(UriTemplate = "/rolUser/{id}", ResponseFormat = WebMessageFormat.Json)]

        public IEnumerable<RolUsuario> RolesXUsuario(String id)
        {
            IEnumerable<RolUsuario> lstRol = gestorRol.consultarRolesUsuario(int.Parse(id));
            return lstRol;
        }

        /// <summary>
        /// Consigue una lista de los nombres de los roles para popular un dropdown
        /// </summary>
        /// <returns>Lista Rols</returns>

        [OperationContract]
        [WebGet(UriTemplate = "/rolesUsuario", ResponseFormat = WebMessageFormat.Json)]

        public IEnumerable<RolUsuario> NombreRoles()
        {
            IEnumerable<RolUsuario> lstRol = gestorRol.consultarRoles();
            return lstRol;
        }

        /// <summary>
        /// Asigna un rol a un usuario
        /// </summary>
        /// <returns>True</returns>

        [OperationContract]
        [WebGet(UriTemplate = "/asignarRol?idRol={idRol}&idUsuario={idUsuario}", ResponseFormat = WebMessageFormat.Json)]

        public bool AsignarRol(string idRol, string idUsuario)
        {
            IEnumerable<RolUsuario> listaVieja = gestorRol.consultarRolesUsuario(int.Parse(idUsuario));

            gestorRol.asignarRolUsuario(int.Parse(idRol), int.Parse(idUsuario));

            IEnumerable<RolUsuario> listaNueva = gestorRol.consultarRolesUsuario(int.Parse(idUsuario));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }


        /// <summary>
        /// Remueve un rol a un usuario
        /// </summary>
        /// <returns>True</returns>

        [OperationContract]
        [WebGet(UriTemplate = "/removerRol?idRol={idRol}&idUsuario={idUsuario}", ResponseFormat = WebMessageFormat.Json)]

        public bool RemoverRol(string idRol, string idUsuario)
        {
            IEnumerable<RolUsuario> listaVieja = gestorRol.consultarRolesUsuario(int.Parse(idUsuario));

            gestorRol.removerRolUsuario(int.Parse(idRol), int.Parse(idUsuario));

            IEnumerable<RolUsuario> listaNueva = gestorRol.consultarRolesUsuario(int.Parse(idUsuario));

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }


    } //Fin Servicio

} //Fin Namespace