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
using System.Globalization;

namespace Servicios.ModuloBecas
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiciosAprobaciones
    {
        private GestorAprobacion gestorAprobacion;

        /// <summary>
        /// Crea una instancia al gestor aprobaciones
        /// </summary>
        public ServiciosAprobaciones()
        {
            gestorAprobacion = new GestorAprobacion();
        }

        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Aprobacion> ListarAprobaciones()
        {
            IEnumerable<Aprobacion> lstAprobaciones = gestorAprobacion.consultarAprobaciones();
            return lstAprobaciones;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Aprobacion InformacionDeSolicitud(string id)
        {
            Aprobacion aprobacion = gestorAprobacion.consultarAprobacionById(int.Parse(id));

            if (aprobacion == null)
            {
                aprobacion = new Aprobacion();
            }
            return aprobacion;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/crear?idSolicitud={idSolicitud}&idUsuario={idUsuario}&comentario={comentario}&aprobado={aprobado}", ResponseFormat = WebMessageFormat.Json)]
        public bool CrearSolicitud(string idSolicitud, string idUsuario, string comentario, string aprobado)
        {
            IEnumerable<Aprobacion> listaVieja = gestorAprobacion.consultarAprobaciones();

            DateTime fecha = DateTime.Now;

            gestorAprobacion.agregarAprobacion(int.Parse(idSolicitud), int.Parse(idUsuario), fecha, comentario, bool.Parse(aprobado));

            IEnumerable<Aprobacion> listaNueva = gestorAprobacion.consultarAprobaciones();

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/actualizar?id={id}&idSolicitud={idSolicitud}&idUsuario={idUsuario}&fecha={fecha}&comentario={comentario}&aprobado={aprobado}", ResponseFormat = WebMessageFormat.Json)]
        public bool ModificarTipoBeca(string id, string idSolicitud, string idUsuario, string fecha, string comentario, string aprobado)
        {
            Aprobacion solicitudViejo = gestorAprobacion.consultarAprobacionById(int.Parse(id));

            gestorAprobacion.editarAprobacion(int.Parse(id), int.Parse(idSolicitud), int.Parse(idUsuario), DateTime.ParseExact(fecha, "yyyy-MM-dd", CultureInfo.InvariantCulture), comentario, bool.Parse(aprobado));

            Aprobacion SolicitudNuevo = gestorAprobacion.consultarAprobacionById(int.Parse(id));

            if (solicitudViejo.IdUsuario != SolicitudNuevo.IdUsuario || solicitudViejo.IdSolicitud != SolicitudNuevo.IdSolicitud || solicitudViejo.Fecha != SolicitudNuevo.Fecha || solicitudViejo.Comentario != SolicitudNuevo.Comentario || solicitudViejo.Aprobado != SolicitudNuevo.Aprobado)
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/borrar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarSolicitud(string id)
        {
            IEnumerable<Aprobacion> listaVieja = gestorAprobacion.consultarAprobaciones();

            gestorAprobacion.eliminarAprobacion(int.Parse(id));

            IEnumerable<Aprobacion> listaNueva = gestorAprobacion.consultarAprobaciones();

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }
    }
}
