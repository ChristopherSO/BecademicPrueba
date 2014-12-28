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


namespace Servicios.ModuloAcademico
{
    [ServiceContract(Namespace = "Servicios.ModuloAcademico")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiciosCurso
    {
        private GestorCursos gestor;

        public ServiciosCurso()
        {
            gestor = new GestorCursos();
        }

        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Curso> ListarCurso()
        {
            IEnumerable<Curso> lista = gestor.consultarCursos();
            return lista;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Curso InformacionCurso(string id)
        {
            Curso lista = gestor.consultarCurso(int.Parse(id));

            if (lista == null)
            {
                lista = new Curso();
            }

            return lista;
        }


        [OperationContract]
        [WebGet(UriTemplate = "/crear?nombre={nombre}&codigo={codigo}&precio={precio}&cantidad_creditos={cantidad_creditos}", ResponseFormat = WebMessageFormat.Json)]
        public bool CrearCurso(string nombre, string codigo, string precio, string cantidad_creditos)
        {
            IEnumerable<Curso> listaVieja = gestor.consultarCursos();

            gestor.agregarCurso(nombre, codigo, precio, int.Parse(cantidad_creditos));

            IEnumerable<Curso> listaNueva = gestor.consultarCursos();

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }


        [OperationContract]
        [WebGet(UriTemplate = "/actualizar?id={id}&nombre={nombre}&codigo={codigo}&precio={precio}&cantidad_creditos={cantidad_creditos}", ResponseFormat = WebMessageFormat.Json)]
        public bool ModificarCurso(string id, string nombre, string codigo, string precio, string cantidad_creditos)
        {
            Curso cursoViejo = gestor.consultarCurso(int.Parse(id));

            gestor.editarCurso(int.Parse(id), nombre, codigo, precio, int.Parse(cantidad_creditos));

            Curso cursoNuevo = gestor.consultarCurso(int.Parse(id));

            if (cursoViejo.Nombre != cursoNuevo.Nombre || cursoViejo.Codigo != cursoNuevo.Codigo || cursoViejo.Precio != cursoNuevo.Precio || cursoViejo.CantidadCreditos != cursoNuevo.CantidadCreditos)
            {
                return true;
            }
            return false;
        }


        [OperationContract]
        [WebGet(UriTemplate = "/borrar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarCurso(string id)
        {
            IEnumerable<Curso> listaVieja = gestor.consultarCursos();

            gestor.eliminarCurso(int.Parse(id));

            IEnumerable<Curso> listaNueva = gestor.consultarCursos();

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }

    }
}
