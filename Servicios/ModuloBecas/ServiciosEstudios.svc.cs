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

namespace Servicios.ModuloBecas
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiciosEstudios
    {
        private GestorEstudios _gestor;

        public ServiciosEstudios()
        {
            _gestor = new GestorEstudios();
        }

        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Estudio> ListarTodosLosEstudios()
        {
            IEnumerable<Estudio> _lista = _gestor.consultarEstudios();
            return _lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Estudio DetallesDeUnEstudio(string id)
        {
            Estudio _estudio = _gestor.consultarEstudio(int.Parse(id));
            return _estudio;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/crear?id_funcionario={id_funcionario}&id_solicitud={id_solicitud}&es_elegible={es_elegible}&fecha={fecha}&resumen={resumen}", ResponseFormat = WebMessageFormat.Json)]
        public bool CrearNuevoEstudio(int id_funcionario, int id_solicitud, bool es_elegible, string fecha, string resumen)
        {
            IEnumerable<Estudio> _listaVieja = _gestor.consultarEstudios();

            _gestor.agregarEstudio(id_funcionario, fecha, resumen, es_elegible);

            IEnumerable<Estudio> _listaNueva = _gestor.consultarEstudios();

            Estudio _nuevoEstudio = new Estudio();

            if (_listaVieja.Count() < _listaNueva.Count())
            {

                foreach (Estudio es in _listaNueva)
                {
                    if (es.idUsuarioFuncionario == id_funcionario && es.fecha == fecha && es.resumenEstudio == resumen && es.esElegible == es_elegible)
                    {
                        _nuevoEstudio = es;
                    }
                }

                GestorSolicitudes _gestorSolicitudes = new GestorSolicitudes();

                Solicitud _solicitudTemp = _gestorSolicitudes.consultarSolicitud(id_solicitud);

                _gestorSolicitudes.editarSolicitud(_solicitudTemp.Id, _solicitudTemp.idUsuario, _solicitudTemp.idCarrera, _solicitudTemp.idTipoBeca, _nuevoEstudio.Id, _solicitudTemp.fecha);

                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/editar?id_estudio={id_estudio}&id_funcionario={id_funcionario}&es_elegible={es_elegible}&fecha={fecha}&resumen={resumen}", ResponseFormat = WebMessageFormat.Json)]
        public bool ActualizarEstudio(int id_estudio, int id_funcionario, bool es_elegible, string fecha, string resumen)
        {
            try
            {
                Estudio _estudioViejo = _gestor.consultarEstudio(id_estudio);

                _gestor.editarEstudio(id_estudio, id_funcionario, fecha, resumen, es_elegible);

                Estudio _estudioNuevo = _gestor.consultarEstudio(id_estudio);

                if (!_estudioViejo.Equals(_estudioNuevo))
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
        public bool EliminarEstudio(string id)
        {
            IEnumerable<Estudio> _listaVieja = _gestor.consultarEstudios();

            _gestor.eliminarEstudio(int.Parse(id));

            IEnumerable<Estudio> _listaNueva = _gestor.consultarEstudios();

            if (_listaVieja.Count() > _listaNueva.Count())
            {
                return true;
            }
            return false;
        }
    }
}
