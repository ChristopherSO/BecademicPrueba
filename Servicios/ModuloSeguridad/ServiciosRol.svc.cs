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

    public class ServiciosRol
    {

        private GestorRol gestorRol;
        private GestorPermiso gestorPermiso;

        /// <summary>
        /// Crea una instancia al gestor Rol
        /// </summary>
        public ServiciosRol()
        {
            gestorRol = new GestorRol();
            gestorPermiso = new GestorPermiso();
        }

        /// <summary>
        /// Consigue una lista de todos los Rols en el sistema
        /// </summary>
        /// <returns>Lista Rols</returns>

        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<RolUsuario> ListarRols()
        {
            IEnumerable<RolUsuario> lstRol = gestorRol.consultarRoles();
            return lstRol;
        }

        /// <summary>
        /// Consigue los detalles de un Rol utilizando su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objeto Rol</returns>


        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public RolUsuario InformacionDeRol(string id)
        {
            RolUsuario Rol = gestorRol.consultarRol(int.Parse(id));

            if (Rol == null)
            {
                Rol = new RolUsuario();
            }

            return Rol;
        }



        [OperationContract]
        [WebGet(UriTemplate = "/crear?nombre={nombre}&descripcion={descripcion}&fase={intervencion}", ResponseFormat = WebMessageFormat.Json)]
        public bool AgregarRol(String nombre, String descripcion, String intervencion)
        {

            IEnumerable<RolUsuario> listaVieja = gestorRol.consultarRoles();

            RolUsuario Rol = new RolUsuario();

            gestorRol.agregarRol(nombre, descripcion, int.Parse(intervencion));

            IEnumerable<RolUsuario> listaNueva = gestorRol.consultarRoles();

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/actualizar?id={id}&nombre={nombre}&descripcion={descripcion}&fase={intervencion}",
        ResponseFormat = WebMessageFormat.Json)]


        public bool ModificarRol(String id, String nombre, String descripcion, String intervencion)
        {

            RolUsuario RolViejo = gestorRol.consultarRol(int.Parse(id));

            gestorRol.editarRol(int.Parse(id),nombre, descripcion, int.Parse(intervencion));

            RolUsuario RolNuevo = gestorRol.consultarRol(int.Parse(id));

            if (ObjectUtils.IsALike(RolViejo, RolNuevo))
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/borrar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool EliminarRol(string id)
        {
            IEnumerable<RolUsuario> listaVieja = gestorRol.consultarRoles();

            gestorRol.eliminarRol(int.Parse(id));

            IEnumerable<RolUsuario> listaNueva = gestorRol.consultarRoles();

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lista todos los permisos que pueden ser asignados a un rol
        /// </summary>
        /// <returns>Lista Permisos</returns>

        [OperationContract]
        [WebGet(UriTemplate = "/permisos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<PermisoRol> ListarPermisos()
        {
            IEnumerable<PermisoRol> lstPermisos = gestorPermiso.consultarPermiso();
            return lstPermisos;
        }

        /// <summary>
        /// Retorna la lista de todos los Permiso existentes de un rol.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [OperationContract]
        [WebGet(UriTemplate = "/permisoRol/{id}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<PermisoRol> ListarPermisosRol(String id)
        {
            IEnumerable<PermisoRol> lstPermisos = gestorPermiso.consultarPermisoRol(int.Parse(id));
            return lstPermisos;

        }

        /// <summary>
        /// Asigna un permiso a un rol
        /// </summary>
        /// <param name="idPermiso"></param>
        /// <param name="idRol"></param>
        /// <returns>Retrna true en condicion de exito</returns>

        [OperationContract]
        [WebGet(UriTemplate = "/asignarPermiso?idPermiso={idPermiso}&idRol={idRol}", ResponseFormat = WebMessageFormat.Json)]

        public bool AsignarPermiso(string idPermiso, string idRol)
        {
            IEnumerable<PermisoRol> listaVieja = gestorPermiso.consultarPermisoRol(int.Parse(idRol));

            gestorPermiso.asignarPermisoRol(int.Parse(idPermiso), int.Parse(idRol));

            IEnumerable<PermisoRol> listaNueva = gestorPermiso.consultarPermisoRol(int.Parse(idRol));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPermiso"></param>
        /// <param name="idRol"></param>
        /// <returns></returns>

        [OperationContract]
        [WebGet(UriTemplate = "/removerPermiso?idPermiso={idPermiso}&idRol={idRol}", ResponseFormat = WebMessageFormat.Json)]

        public bool RemoverPermiso(string idPermiso, string idRol)
        {
            IEnumerable<PermisoRol> listaVieja = gestorPermiso.consultarPermisoRol(int.Parse(idRol));

            gestorPermiso.removerPermisoRol(int.Parse(idPermiso), int.Parse(idRol));

            IEnumerable<PermisoRol> listaNueva = gestorPermiso.consultarPermisoRol(int.Parse(idRol));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }


    } //Fin Servicio

} //Fin Namespace