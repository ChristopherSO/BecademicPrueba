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
    public class ServiciosBeneficios
    {
        private GestorBeneficios gestorBeneficios;

        public ServiciosBeneficios()
        {
            gestorBeneficios = new GestorBeneficios();
        }

        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Beneficio> ListarBeneficios()
        {
            IEnumerable<Beneficio> lista = gestorBeneficios.consultarBeneficios();
            return lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Beneficio InformacionDeBeneficio(string id)
        {
            Beneficio beneficio = gestorBeneficios.consultarBeneficioPorID(int.Parse(id));

            if (beneficio == null)
            {
                beneficio = new Beneficio();
            }

            return beneficio;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/crear?id_tipo_beneficio={id_tipo_beneficio}&nombre={nombre}&descripcion={descripcion}&valor={valor}",
            ResponseFormat = WebMessageFormat.Json)]
        public bool CrearBeneficio(string id_tipo_beneficio, string nombre, string descripcion, string valor)
        {
            IEnumerable<Beneficio> listaVieja = gestorBeneficios.consultarBeneficios();

            gestorBeneficios.agregarBeneficio(int.Parse(id_tipo_beneficio), nombre, descripcion, valor);

            IEnumerable<Beneficio> listaNueva = gestorBeneficios.consultarBeneficios();

            if (listaNueva.Count() > listaVieja.Count())
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/actualizar?id={id}&id_tipo_beneficio={id_tipo_beneficio}&nombre={nombre}&descripcion={descripcion}&valor={valor}",
            ResponseFormat = WebMessageFormat.Json)]
        public bool ActualizarBeneficio(string id, string id_tipo_beneficio, string nombre, string descripcion, string valor)
        {
            Beneficio beneficioViejo = gestorBeneficios.consultarBeneficioPorID(int.Parse(id));

            gestorBeneficios.editarBeneficio(int.Parse(id), int.Parse(id_tipo_beneficio), nombre, descripcion, valor);

            Beneficio beneficioNuevo = gestorBeneficios.consultarBeneficioPorID(int.Parse(id));

            if (beneficioViejo.IdTipoBeneficio != beneficioNuevo.IdTipoBeneficio ||
                beneficioViejo.Nombre != beneficioNuevo.Nombre ||
                beneficioViejo.Descripcion != beneficioNuevo.Descripcion ||
                beneficioViejo.Valor != beneficioNuevo.Valor)
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/borrar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarBeneficio(string id)
        {
            IEnumerable<Beneficio> listaVieja = gestorBeneficios.consultarBeneficios();

            gestorBeneficios.eliminarBeneficio(int.Parse(id));

            IEnumerable<Beneficio> listaNueva = gestorBeneficios.consultarBeneficios();

            if (listaNueva.Count() < listaVieja.Count())
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/tipos_de_beneficios", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<TipoBeneficio> ListarTiposBeneficios()
        {
            IEnumerable<TipoBeneficio> lista = gestorBeneficios.buscarTiposDeBeneficios();
            return lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/tipo_beneficio?idBeneficio={idBeneficio}", ResponseFormat = WebMessageFormat.Json)]
        public TipoBeneficio InformacionDeTipoBeneficio(string idBeneficio)
        {
            TipoBeneficio tipoBeneficio = gestorBeneficios.consultarBeneficioPorID(int.Parse(idBeneficio)).TipoBeneficio;

            if (tipoBeneficio == null)
            {
                tipoBeneficio = new TipoBeneficio();
            }

            return tipoBeneficio;
        }


    }
}
