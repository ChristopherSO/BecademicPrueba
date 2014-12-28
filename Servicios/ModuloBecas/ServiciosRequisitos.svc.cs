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
    [ServiceContract(Namespace = "Servicios.ModuloBecas")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiciosRequisitos
    {
        private GestorRequisito gestorRequisito;

        /// <summary>
        /// Crea una instancia al gestor tipo de beca
        /// </summary>
        public ServiciosRequisitos()
        {
            gestorRequisito = new GestorRequisito();
        }

        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Requisito> ListarRequisitos()
        {
            IEnumerable<Requisito> lstRequisito = gestorRequisito.consultarRequisitos();
            return lstRequisito;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Requisito InformacionDeRequisito(string id)
        {
            Requisito requisito = gestorRequisito.consultarRequisitoXID(int.Parse(id));

            if (requisito == null)
            {
                requisito = new Requisito();
            }

            return requisito;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/crear?nombre={nombre}&tipoRequisito={tipoRequisito}&descripcion={descripcion}", ResponseFormat = WebMessageFormat.Json)]
        public bool CrearRequisito(string nombre, string tipoRequisito, string descripcion)
        {
            IEnumerable<Requisito> listaVieja = gestorRequisito.consultarRequisitos();

            gestorRequisito.agregarRequisito(nombre, int.Parse(tipoRequisito), descripcion);

            IEnumerable<Requisito> listaNueva = gestorRequisito.consultarRequisitos();

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "actualizar?id={id}&nombre={nombre}&tipoRequisito={tipoRequisito}&descripcion={descripcion}", ResponseFormat = WebMessageFormat.Json)]
        public bool ModificarTipoBeca(string id, string nombre, string tipoRequisito, string descripcion)
        {
            Requisito requisitoViejo = gestorRequisito.consultarRequisitoXID(int.Parse(id));

            gestorRequisito.editarRequisito(int.Parse(id), nombre, int.Parse(tipoRequisito), descripcion);

            Requisito requisitoNuevo = gestorRequisito.consultarRequisitoXID(int.Parse(id));

            if (requisitoViejo.Nombre != requisitoNuevo.Nombre || requisitoViejo.IdTipoRequisito != requisitoNuevo.IdTipoRequisito || requisitoViejo.Descripcion != requisitoNuevo.Descripcion)
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/borrar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarTipoBeca(string id)
        {
            IEnumerable<Requisito> listaVieja = gestorRequisito.consultarRequisitos();

            gestorRequisito.eliminarRequisito(int.Parse(id));

            IEnumerable<Requisito> listaNueva = gestorRequisito.consultarRequisitos();

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/tipos_de_Requisitos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<TipoRequisito> ListarTiposRequisitos()
        {
            IEnumerable<TipoRequisito> lista = gestorRequisito.listarTipoRequisitos();
            return lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/tipo_requisito?idRequisito={idRequisito}", ResponseFormat = WebMessageFormat.Json)]
        public TipoRequisito InformacionDeTipoRequisito(string idRequisito)
        {
            TipoRequisito tipoRequisito = gestorRequisito.consultarRequisitoXID(int.Parse(idRequisito)).TipoRequisito;

            if (tipoRequisito == null)
            {
                tipoRequisito = new TipoRequisito();
            }

            return tipoRequisito;
        }
    }
}
