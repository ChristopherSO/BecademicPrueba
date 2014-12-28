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

namespace Servicios.ModuloAcademico
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class ServiciosCarrera
    {
                private GestorCarrera gestorCarrera;
        private GestorCursos gestorCurso;

        public ServiciosCarrera()
        {
            gestorCarrera = new GestorCarrera();
            gestorCurso = new GestorCursos();
        }
        [OperationContract]
        public void dowork()
        {

        }

        [OperationContract]
        [WebGet(UriTemplate = "/todos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Carrera> ListarCarreras()
        {
            IEnumerable<Carrera> lstCarrera = gestorCarrera.consultarCarreras();
            return lstCarrera;
        }



        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Carrera InformacionCarrera(string id)
        {
            Carrera carrera = null;

            try
            {
                carrera = gestorCarrera.consultarCarrera(int.Parse(id));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return carrera;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/crear?nombre={nombre}&descripcion={descripcion}&icono={icono}&color={color}", ResponseFormat = WebMessageFormat.Json)]
        public bool CrearCarrera(string nombre, string descripcion, string icono, string color)
        {
            IEnumerable<Carrera> listaVieja = gestorCarrera.consultarCarreras();

            gestorCarrera.agregarCarrera(nombre, descripcion, icono, color);

            IEnumerable<Carrera> listaNueva = gestorCarrera.consultarCarreras();

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/actualizar?id={id}&nombre={nombre}&descripcion={descripcion}&icono={icono}&color={color}", ResponseFormat = WebMessageFormat.Json)]
        public bool ModificarCarrera(string id, string nombre, string descripcion, string icono, string color)
        {
            Carrera carreraVieja = gestorCarrera.consultarCarrera(int.Parse(id));

            gestorCarrera.editarCarrera(int.Parse(id), nombre, descripcion, icono, color);

            Carrera carreraNueva = gestorCarrera.consultarCarrera(int.Parse(id));

            if (carreraVieja.Nombre != carreraNueva.Nombre || carreraVieja.Descripcion != carreraNueva.Descripcion)
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/borrar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarCarrera(string id)
        {
            IEnumerable<Carrera> listaVieja = gestorCarrera.consultarCarreras();

            gestorCarrera.eliminarCarrera(int.Parse(id));

            IEnumerable<Carrera> listaNueva = gestorCarrera.consultarCarreras();

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }

            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/listarCursosCarrera/{id}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Curso> ListarCursosCarrera(string id)
        {
            IEnumerable<Curso> listaCursosCarrera = gestorCarrera.consultarCursosPorCarrera(int.Parse(id));
            return listaCursosCarrera;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/listarDirectorCarrera/{id}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Usuario> ListarDirectorCarrera(string id)
        {
            IEnumerable<Usuario> listaDirectorCarrera = gestorCarrera.consultarDirectoresPorCarrera(int.Parse(id));
            return listaDirectorCarrera;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/listarEstudianteCarrera/{id}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Usuario> ListarEstudiantesCarrera(string id)
        {
            IEnumerable<Usuario> listaEstudiantesCarrera = gestorCarrera.consultarEstudiantesPorCarrera(int.Parse(id));
            return listaEstudiantesCarrera;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/asignarCursoCarrera?idCurso={idCurso}&idCarrera={idCarrera}&periodo={periodo}", ResponseFormat = WebMessageFormat.Json)]
        public bool AsignarCursoCarrera(string idCurso, string idCarrera, string periodo)
        {
            IEnumerable<Curso> listaVieja = gestorCarrera.consultarCursosPorCarrera(int.Parse(idCarrera));

            gestorCarrera.agregarCursoACarrera(int.Parse(idCurso), int.Parse(idCarrera), int.Parse(periodo));

            IEnumerable<Curso> listaNueva = gestorCarrera.consultarCursosPorCarrera(int.Parse(idCarrera
                ));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/asignarDirectorCarrera?idDirector={idDirector}&idCarrera={idCarrera}", ResponseFormat = WebMessageFormat.Json)]
        public bool AsignarDirectorCarrera(string idDirector, string idCarrera)
        {
            IEnumerable<Usuario> listaVieja = gestorCarrera.consultarDirectoresPorCarrera(int.Parse(idCarrera));

            gestorCarrera.agregarDirectorACarrera(int.Parse(idDirector), int.Parse(idCarrera));

            IEnumerable<Usuario> listaNueva = gestorCarrera.consultarDirectoresPorCarrera(int.Parse(idCarrera));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/asignarEstudianteCarrera?idEstudiante={idEstudiante}&idCarrera={idCarrera}", ResponseFormat = WebMessageFormat.Json)]
        public bool AsignarEstudianteCarrera(string idEstudiante, string idCarrera)
        {
            IEnumerable<Usuario> listaVieja = gestorCarrera.consultarEstudiantesPorCarrera(int.Parse(idCarrera));

            gestorCarrera.agregarEstudianteACarrera(int.Parse(idEstudiante), int.Parse(idCarrera));

            IEnumerable<Usuario> listaNueva = gestorCarrera.consultarEstudiantesPorCarrera(int.Parse(idCarrera));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }


        [OperationContract]
        [WebGet(UriTemplate = "/borrarCursoCarrera/{idCurso}/{idCarrera}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarCursoCarrera(string idCurso, string idCarrera)
        {
            IEnumerable<Curso> listaVieja = gestorCarrera.consultarCursosPorCarrera(int.Parse(idCarrera));

            gestorCarrera.eliminarCursoDeCarrera(int.Parse(idCurso), int.Parse(idCarrera));

            IEnumerable<Curso> listaNueva = gestorCarrera.consultarCursosPorCarrera(int.Parse(idCarrera
                ));

            if (listaVieja.Count() > listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/borrarDirectorCarrera/{idUsuario}/{idCarrera}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarDirectorCarrera(string idUsuario, string idCarrera)
        {
            IEnumerable<Usuario> listaVieja = gestorCarrera.consultarDirectoresPorCarrera(int.Parse(idCarrera));

            gestorCarrera.eliminarDirectorDeCarrera(int.Parse(idCarrera), int.Parse(idUsuario));

            IEnumerable<Usuario> listaNueva = gestorCarrera.consultarDirectoresPorCarrera(int.Parse(idCarrera));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }


        [OperationContract]
        [WebGet(UriTemplate = "/borrarEstudianteCarrera/{idUsuario}/{idCarrera}", ResponseFormat = WebMessageFormat.Json)]
        public bool BorrarEstudianteCarrera(string idUsuario, string idCarrera)
        {
            IEnumerable<Usuario> listaVieja = gestorCarrera.consultarEstudiantesPorCarrera(int.Parse(idCarrera));

            gestorCarrera.eliminarEstudianteDeCarrera(int.Parse(idCarrera), int.Parse(idUsuario));

            IEnumerable<Usuario> listaNueva = gestorCarrera.consultarEstudiantesPorCarrera(int.Parse(idCarrera));

            if (listaVieja.Count() < listaNueva.Count())
            {
                return true;
            }
            return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/cursos", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Curso> ListarCursos()
        {
            IEnumerable<Curso> lista = gestorCurso.consultarCursos();
            return lista;
        }


        [OperationContract]
        [WebGet(UriTemplate = "/directores", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Usuario> ListarDirectoresAcademicos()
        {
            IEnumerable<Usuario> lista = gestorCarrera.consultarDirectoresAcademicos();
            return lista;
        }


        [OperationContract]
        [WebGet(UriTemplate = "/estudiantes", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Usuario> ListarEstudiantes()
        {
            IEnumerable<Usuario> lista = gestorCarrera.consultarEstudiantes();
            return lista;
        }
    }
}
