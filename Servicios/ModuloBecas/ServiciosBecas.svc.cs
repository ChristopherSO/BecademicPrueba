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
    [ServiceContract(Namespace = "Servicios.ModuloBecas")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiciosBecas
    {
        private GestorBecas gestorBecas;

        public ServiciosBecas()
        {
            gestorBecas = new GestorBecas();
        }

        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Beca> ListarBecas()
        {
            IEnumerable<Beca> lista = gestorBecas.consultarBecas();
            return lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Beca InformacionDeBeca(string id)
        {
            Beca beca = gestorBecas.consultarBecaPorID(int.Parse(id));

            if (beca == null)
            {
                beca = new Beca();
            }

            return beca;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/crear?id_carrera={id_carrera}&fecha_aprobacion={fecha_aprobacion}&id_usuario={id_usuario}&id_tipo_beca={id_tipo_beca}&estado={estado}&comentario={comentario}",
            ResponseFormat = WebMessageFormat.Json)]
        public bool CrearBeca(string id_carrera, string fecha_aprobacion, string id_usuario, string id_tipo_beca, string estado, string comentario)
        {
            IEnumerable<Beca> listaVieja = gestorBecas.consultarBecas();

            gestorBecas.agregarBeca(int.Parse(id_carrera), DateTime.ParseExact(fecha_aprobacion, "yyyy-MM-dd", CultureInfo.InvariantCulture), int.Parse(id_usuario), int.Parse(id_tipo_beca), bool.Parse(estado), comentario);

            IEnumerable<Beca> listaNueva = gestorBecas.consultarBecas();

            if (listaNueva.Count() > listaVieja.Count())
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/actualizar?id={id}&id_carrera={id_carrera}&fecha_aprobacion={fecha_aprobacion}&id_usuario={id_usuario}&id_tipo_beca={id_tipo_beca}&estado={estado}&comentario={comentario}",
            ResponseFormat = WebMessageFormat.Json)]
        public bool ActualizarBeca(string id, string id_carrera, string fecha_aprobacion, string id_usuario, string id_tipo_beca, string estado, string comentario)
        {
            Beca becaViejo = gestorBecas.consultarBecaPorID(int.Parse(id));

            gestorBecas.editarBeca(int.Parse(id), int.Parse(id_carrera), DateTime.Parse(fecha_aprobacion), int.Parse(id_usuario), int.Parse(id_tipo_beca), bool.Parse(estado), comentario);

            Beca becaNuevo = gestorBecas.consultarBecaPorID(int.Parse(id));

            if (becaViejo.IdCarrera != becaNuevo.IdCarrera ||
                becaViejo.FechaAprobacion != becaNuevo.FechaAprobacion ||
                becaViejo.IdUsuario != becaNuevo.IdUsuario ||
                becaViejo.IdTipoBeca != becaNuevo.IdTipoBeca ||
                becaViejo.Estado != becaNuevo.Estado ||
                becaViejo.Comentario != becaNuevo.Comentario)
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/borrar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarBeca(string id)
        {
            IEnumerable<Beca> listaVieja = gestorBecas.consultarBecas();

            gestorBecas.eliminarBeca(int.Parse(id));

            IEnumerable<Beca> listaNueva = gestorBecas.consultarBecas();

            if (listaNueva.Count() < listaVieja.Count())
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/carrera?idBeca={idBeca}", ResponseFormat = WebMessageFormat.Json)]
        public Carrera InformacionDeCarrera(string idBeca)
        {
            Carrera carrera = gestorBecas.consultarBecaPorID(int.Parse(idBeca)).Carrera;

            if (carrera == null)
            {
                carrera = new Carrera();
            }

            return carrera;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/usuario?idBeca={idBeca}", ResponseFormat = WebMessageFormat.Json)]
        public Usuario InformacionDeUsuario(string idBeca)
        {
            Usuario usuario = gestorBecas.consultarBecaPorID(int.Parse(idBeca)).Usuario;

            if (usuario == null)
            {
                usuario = new Usuario();
            }

            return usuario;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/tipoBeca?idBeca={idBeca}", ResponseFormat = WebMessageFormat.Json)]
        public TipoBeca InformacionDeTipoBeca(string idBeca)
        {
            TipoBeca tipoBeca = gestorBecas.consultarBecaPorID(int.Parse(idBeca)).TipoBeca;

            if (tipoBeca == null)
            {
                tipoBeca = new TipoBeca();
            }

            return tipoBeca;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/validarBeca?idUsuario={idUsuario}&idCarrera={idCarrera}",
            ResponseFormat = WebMessageFormat.Json)]
        public string ValidarBeca(string idUsuario, string idCarrera)
        {
            GestorBecas gestorBecas = new GestorBecas();
            string mensaje = gestorBecas.validarEstadoBeca(int.Parse(idUsuario), int.Parse(idCarrera));

            return mensaje;
        }


    }
}