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

namespace Servicios.ModuloBecas
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiciosSolicitudes
    {
        private GestorSolicitudes _gestor;

        public ServiciosSolicitudes()
        {
            _gestor = new GestorSolicitudes();
        }

        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Solicitud> ListarBeneficios()
        {
            IEnumerable<Solicitud> _lista = _gestor.consultarSolicitudes();
            return _lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/fase/{intervencion}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Solicitud> ListarSolicitudesFase(string intervencion)
        {
            int numFase;

            switch (int.Parse(intervencion))
            {
                case 1:
                    numFase = 1;
                    break;
                case 2:
                    numFase = 2;
                    break;
                case 3:
                    numFase = 4;
                    break;
                case 4:
                    numFase = 3;
                    break;
                default:
                    numFase = 0;
                    break;
            }
            IEnumerable<Solicitud> _lista = _gestor.consultarBecaPorFase(numFase);
            return _lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Solicitud VerDetallesDeSolicitud(string id)
        {
            Solicitud _solicitud = _gestor.consultarSolicitud(int.Parse(id));
            _solicitud.EstudioSocioEconomico = new Estudio();
            return _solicitud;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/productos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<TipoBeca> ListarTiposDeBecas()
        {
            GestorTipoBeca _gestorTiposDeBeca = new GestorTipoBeca();
            IEnumerable<TipoBeca> _lista = _gestorTiposDeBeca.consultarTipoBecas();
            return _lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/postulantes", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Usuario> ListarUsuarios()
        {
            GestorUsuario _usuarios = new GestorUsuario();
            IEnumerable<Usuario> lstUsuario = _usuarios.consultarUsuario();
            return lstUsuario;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/crear?id_usuario={id_usuario}&id_carrera={id_carrera}&id_tipo_beca={id_tipo_beca}&id_estudio={id_estudio}&fecha={fecha}", ResponseFormat = WebMessageFormat.Json)]
        public Boolean SolicitarUnaNuevaBeca(int id_usuario, int id_carrera, int id_tipo_beca, int id_estudio, string fecha)
        {

            IEnumerable<Solicitud> _listaVieja = _gestor.consultarSolicitudes();

            _gestor.agregarSolicitud(id_usuario, id_carrera, id_tipo_beca, id_estudio, fecha);

            IEnumerable<Solicitud> _listaNueva = _gestor.consultarSolicitudes();

            if (_listaVieja.Count() < _listaNueva.Count())
            {
                return true;
            }
            return false;

        }

        [OperationContract]
        [WebGet(UriTemplate = "/editar?id_solicitud={id_solicitud}&id_usuario={id_usuario}&id_carrera={id_carrera}&id_tipo_beca={id_tipo_beca}&id_estudio={id_estudio}&fecha={fecha}", ResponseFormat = WebMessageFormat.Json)]
        public Boolean EditarInformacionDeUnaSolicitud(int id_solicitud, int id_usuario, int id_carrera, int id_tipo_beca, int id_estudio, string fecha)
        {
            try
            {
                Solicitud _solicitudVieja = _gestor.consultarSolicitud(id_solicitud);

                _gestor.editarSolicitud(id_solicitud, id_usuario, id_carrera, id_tipo_beca, id_estudio, fecha);

                Solicitud _solicitudNueva = _gestor.consultarSolicitud(id_solicitud);

                if (!_solicitudVieja.Equals(_solicitudNueva))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return false;

        }

        [OperationContract]
        [WebGet(UriTemplate = "/eliminar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool EliminarUnSolicitud(string id)
        {

            IEnumerable<Solicitud> _listaVieja = _gestor.consultarSolicitudes();

            _gestor.eliminarSolicitud(int.Parse(id));

            IEnumerable<Solicitud> _listaNueva = _gestor.consultarSolicitudes();

            if (_listaVieja.Count() > _listaNueva.Count())
            {
                return true;
            }
            return false;
        }
    }
}