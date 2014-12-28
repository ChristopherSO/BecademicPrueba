using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using BLL;
using EntitiesLayer;
using System.Globalization;

namespace Servicios.ModuloNotificaciones
{
    [ServiceContract(Namespace = "Servicios.ModuloNotificaciones")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiciosNotificaciones
    {
        private GestorNotificaciones gestorNotificaciones;

        /// <summary>
        /// Crea una instancia de gestor de notificaciones
        /// </summary>
        public ServiciosNotificaciones()
        {
            gestorNotificaciones = new GestorNotificaciones();
        }


        /// <summary>
        /// Llama al gestorNotificaciones para obtener la lista de todas las notificaciones registradas y retornar en una cadena
        /// JSON todos los datos hacia la web
        /// </summary>
        [OperationContract]
        [WebGet(UriTemplate = "/todas?id_usuario={id_usuario}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Notificacion> ListarNotificacionesTodas(string id_usuario)
        {
            IEnumerable<Notificacion> lista = gestorNotificaciones.consultarNotificacionesTodas(int.Parse(id_usuario));
            return lista;
        }


        /// <summary>
        /// Llama al gestorNotificaciones para obtener la lista de las notificaciones registradas que no han sido vistas y 
        /// retornar en una cadena JSON todos los datos hacia la web
        /// </summary>
        [OperationContract]
        [WebGet(UriTemplate = "/no_vistas?id_usuario={id_usuario}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Notificacion> ListarNotificacionesNoVistas(string id_usuario)
        {
            IEnumerable<Notificacion> lista = gestorNotificaciones.consultarNotificacionesNoVistas(int.Parse(id_usuario));
            return lista;
        }


        /// <summary>
        /// Llama al gestorNotificaciones para agregar una nueva notificación a un usuario
        /// </summary>
        [OperationContract]
        [WebGet(UriTemplate = "/crear?idUsuario={idUsuario}&idUsuarioAutor={idUsuarioAutor}&idTipoNotificacion={idTipoNotificacion}&mensaje={mensaje}",
            ResponseFormat = WebMessageFormat.Json)]
        public bool CrearNotificacionAUsuario(string idUsuario, string idUsuarioAutor, string idTipoNotificacion, string mensaje)
        {
            IEnumerable<Notificacion> listaVieja = gestorNotificaciones.consultarNotificacionesTodas(int.Parse(idUsuario));

            gestorNotificaciones.agregarNotificacionAUsuario(int.Parse(idUsuario), int.Parse(idUsuarioAutor), int.Parse(idTipoNotificacion), mensaje);

            IEnumerable<Notificacion> listaNueva = gestorNotificaciones.consultarNotificacionesTodas(int.Parse(idUsuario));

            if (listaNueva.Count() > listaVieja.Count())
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Llama al gestorNotificaciones para buscar al usuario autor que está relacionado con la notificación dada
        /// </summary>
        [OperationContract]
        [WebGet(UriTemplate = "/usuarioAutor?idNotificacion={idNotificacion}", ResponseFormat = WebMessageFormat.Json)]
        public Usuario InformacionDeUsuarioAutor(string idNotificacion)
        {
            Usuario usuarioAutor = gestorNotificaciones.consultarNotificacionPorID(int.Parse(idNotificacion)).UsuarioAutor;

            if (usuarioAutor == null)
            {
                usuarioAutor = new Usuario();
            }

            return usuarioAutor;
        }


        /// <summary>
        /// Llama al gestorNotificaciones para buscar tipo de notificación que está relacionado con la notificación dada
        /// </summary>
        [OperationContract]
        [WebGet(UriTemplate = "/tipoNotificacion?idNotificacion={idNotificacion}", ResponseFormat = WebMessageFormat.Json)]
        public TipoNotificacion InformacionDeTipoNotificacion(string idNotificacion)
        {
            TipoNotificacion tipoNotificacion = gestorNotificaciones.consultarNotificacionPorID(int.Parse(idNotificacion)).TipoNotificacion;

            if (tipoNotificacion == null)
            {
                tipoNotificacion = new TipoNotificacion();
            }

            return tipoNotificacion;
        }


        [OperationContract]
        [WebGet(UriTemplate = "/marcarComoVista?idNotificacion={idNotificacion}&idUsuario={idUsuario}",
            ResponseFormat = WebMessageFormat.Json)]
        public bool ActualizarNotificacion(string idNotificacion, string idUsuario)
        {
            gestorNotificaciones.marcarNotificacionComoVista(int.Parse(idNotificacion), int.Parse(idUsuario));

            return true;
        }



    }
}