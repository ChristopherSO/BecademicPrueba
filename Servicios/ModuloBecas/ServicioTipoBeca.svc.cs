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
    public class ServicioTipoBeca
    {
        private GestorTipoBeca gestorTipoBeca;

        /// <summary>
        /// Crea una instancia al gestor tipo de beca
        /// </summary>
        public ServicioTipoBeca()
        {
            gestorTipoBeca = new GestorTipoBeca();
        }

        /// <summary>
        /// Llama al gestorTipoBeca para poder obtener la lista de todos los tipos de becas registrado y retornar en una cadena
        /// Json todos los datos hacia la web
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<TipoBeca> ListarTipoBecas()
        {
            IEnumerable<TipoBeca> lstTipoBeca = gestorTipoBeca.consultarTipoBecas();
            return lstTipoBeca;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public TipoBeca InformacionDeTipoBeca(string id)
        {
            TipoBeca tipoBeca = gestorTipoBeca.consultarTipoBecaById(int.Parse(id));

            if (tipoBeca == null)
            {
                tipoBeca = new TipoBeca();
            }
            return tipoBeca;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/crear?nombre={nombre}&descripcion={descripcion}&icono={icono}&color={color}&socioeconomico={socioeconomico}&cantidad={cantidad}", ResponseFormat = WebMessageFormat.Json)]
        public bool CrearTipoBeca(string nombre, string descripcion, string icono, string color, string socioeconomico, string cantidad)
        {
            IEnumerable<TipoBeca> listaVieja = gestorTipoBeca.consultarTipoBecas();

            gestorTipoBeca.agregarTipoBeca(nombre, descripcion, icono, color, bool.Parse(socioeconomico), int.Parse(cantidad));

            IEnumerable<TipoBeca> listaNueva = gestorTipoBeca.consultarTipoBecas();

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "actualizar?id={id}&nombre={nombre}&descripcion={descripcion}&icono={icono}&color={color}&socioeconomico={socioeconomico}&cantidad={cantidad}", ResponseFormat = WebMessageFormat.Json)]
        public bool ModificarTipoBeca(string id, string nombre, string descripcion, string icono, string color, string socioeconomico, string cantidad)
        {
            TipoBeca tipoBecaViejo = gestorTipoBeca.consultarTipoBecaById(int.Parse(id));

            gestorTipoBeca.editarTipoBeca(int.Parse(id), nombre, descripcion, icono, color, bool.Parse(socioeconomico), int.Parse(cantidad));

            TipoBeca tipoBecaNuevo = gestorTipoBeca.consultarTipoBecaById(int.Parse(id));

            if (tipoBecaViejo.Nombre != tipoBecaNuevo.Nombre || tipoBecaViejo.Descripcion != tipoBecaNuevo.Descripcion || tipoBecaViejo.Icono != tipoBecaNuevo.Icono || tipoBecaViejo.Color != tipoBecaNuevo.Color || tipoBecaViejo.Socioeconomico != tipoBecaNuevo.Socioeconomico || tipoBecaViejo.Cantidad != tipoBecaNuevo.Cantidad)
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/borrar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarTipoBeca(string id)
        {
            IEnumerable<TipoBeca> listaVieja = gestorTipoBeca.consultarTipoBecas();

            gestorTipoBeca.eliminarTipoBeca(int.Parse(id));

            IEnumerable<TipoBeca> listaNueva = gestorTipoBeca.consultarTipoBecas();

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/consultarBeneficiosBeca/{id}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Beneficio> ListarBeneficiosBecas(string id)
        {
            IEnumerable<Beneficio> listaBeneficiosBeca = gestorTipoBeca.consultarBeneficiosBeca(int.Parse(id));
            return listaBeneficiosBeca;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/consultarRequisitosBeca/{id}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Requisito> ListarRequisitosBecas(string id)
        {
            IEnumerable<Requisito> listaBeneficiosBeca = gestorTipoBeca.consultarRequisitosBeca(int.Parse(id));
            return listaBeneficiosBeca;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/consultarCarrerasBeca/{id}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Carrera> ListarCarrerasBecas(string id)
        {
            IEnumerable<Carrera> listaBeneficiosBeca = gestorTipoBeca.consultarCarrerasBeca(int.Parse(id));
            return listaBeneficiosBeca;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/asignarBeneficioBeca?idTipoBeca={idTipoBeca}&idBeneficio={idBeneficio}", ResponseFormat = WebMessageFormat.Json)]
        public bool AsignarBeneficioBeca(string idTipoBeca, string idBeneficio)
        {
            IEnumerable<Beneficio> listaVieja = gestorTipoBeca.consultarBeneficiosBeca(int.Parse(idTipoBeca));

            gestorTipoBeca.asignarBeneficio(int.Parse(idTipoBeca), int.Parse(idBeneficio));

            IEnumerable<Beneficio> listaNueva = gestorTipoBeca.consultarBeneficiosBeca(int.Parse(idTipoBeca));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/asignarRequisitoBeca?idTipoBeca={idTipoBeca}&idRequisito={idRequisito}", ResponseFormat = WebMessageFormat.Json)]
        public bool AsignarRequisitoBeca(string idTipoBeca, string idRequisito)
        {
            IEnumerable<Requisito> listaVieja = gestorTipoBeca.consultarRequisitosBeca(int.Parse(idTipoBeca));

            gestorTipoBeca.asignarRequisito(int.Parse(idTipoBeca), int.Parse(idRequisito));

            IEnumerable<Requisito> listaNueva = gestorTipoBeca.consultarRequisitosBeca(int.Parse(idTipoBeca));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/asignarCarreraBeca?idTipoBeca={idTipoBeca}&idCarrera={idCarrera}", ResponseFormat = WebMessageFormat.Json)]
        public bool AsignarCarreraBeca(string idTipoBeca, string idCarrera)
        {
            IEnumerable<Carrera> listaVieja = gestorTipoBeca.consultarCarrerasBeca(int.Parse(idTipoBeca));

            gestorTipoBeca.asignarCarrera(int.Parse(idTipoBeca), int.Parse(idCarrera));

            IEnumerable<Carrera> listaNueva = gestorTipoBeca.consultarCarrerasBeca(int.Parse(idTipoBeca));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/eliminarBeneficioBeca/{idTipoBeca}/{idBeneficio}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarBeneficioBeca(string idTipoBeca, string idBeneficio)
        {
            IEnumerable<Beneficio> listaVieja = gestorTipoBeca.consultarBeneficiosBeca(int.Parse(idTipoBeca));

            gestorTipoBeca.eliminarBeneficioBeca(int.Parse(idBeneficio), int.Parse(idTipoBeca));

            IEnumerable<Beneficio> listaNueva = gestorTipoBeca.consultarBeneficiosBeca(int.Parse(idTipoBeca));

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/eliminarRequisitoBeca/{idTipoBeca}/{idRequisito}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarRequisitoBeca(string idTipoBeca, string idRequisito)
        {
            IEnumerable<Requisito> listaVieja = gestorTipoBeca.consultarRequisitosBeca(int.Parse(idTipoBeca));

            gestorTipoBeca.eliminarBeneficioBeca(int.Parse(idRequisito), int.Parse(idTipoBeca));

            IEnumerable<Requisito> listaNueva = gestorTipoBeca.consultarRequisitosBeca(int.Parse(idTipoBeca));

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/eliminarCarreraBeca/{idTipoBeca}/{idCarrera}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarCarreraBeca(string idTipoBeca, string idCarrera)
        {
            IEnumerable<Carrera> listaVieja = gestorTipoBeca.consultarCarrerasBeca(int.Parse(idTipoBeca));

            gestorTipoBeca.eliminarBeneficioBeca(int.Parse(idCarrera), int.Parse(idTipoBeca));

            IEnumerable<Carrera> listaNueva = gestorTipoBeca.consultarCarrerasBeca(int.Parse(idTipoBeca));

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/beneficios", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Beneficio> ListarBeneficios()
        {
            IEnumerable<Beneficio> lista = gestorTipoBeca.getBeneficios();
            return lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/requisitos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Requisito> ListarRequisitos()
        {
            IEnumerable<Requisito> lista = gestorTipoBeca.getRequisitos();
            return lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/carreras", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Carrera> ListarCarreras()
        {
            IEnumerable<Carrera> lista = gestorTipoBeca.getCarreras();
            return lista;
        }
    }
}
