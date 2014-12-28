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
    public class ServiciosCalificacion
    {
        private GestorCalificaciones gestorCalificacion;

        /// <summary>
        /// Crea una instancia al gestor calificacion
        /// </summary>
        public ServiciosCalificacion()
        {
            gestorCalificacion = new GestorCalificaciones();
        }


        [OperationContract]
        [WebGet(UriTemplate = "/todos/{idUsuario}/{idCarrera}", ResponseFormat = WebMessageFormat.Json)]
        public IEnumerable<Calificacion> ListarCalificaciones(String idUsuario, String idCarrera)
        {
            IEnumerable<Calificacion> lstCalificaciones = gestorCalificacion.consultarCalificaciones(int.Parse(idUsuario), int.Parse(idCarrera));
            return lstCalificaciones;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/detalles/{id}", ResponseFormat = WebMessageFormat.Json)]
        public Calificacion InformacionCalificacion(string id)
        {
            Calificacion calificacion = gestorCalificacion.consultarCalificacionById(int.Parse(id));

            if (calificacion == null)
            {
                calificacion = new Calificacion();
            }

            return calificacion;
        }

        [OperationContract]
        [WebGet(UriTemplate = "/crear?idUsuario={idUsuario}&idCurso={idCurso}&nota={nota}&periodo={periodo}&annio={annio}&comentarios={comentarios}", ResponseFormat = WebMessageFormat.Json)]
        public void CrearCalificacion(string idUsuario, string idCurso, string nota, string periodo, string annio, string comentarios)
        {
            //IEnumerable<TipoBeca> listaVieja = gestorCalificacion.consultarCalificaciones(int.Parse();

            gestorCalificacion.agregarCalificacion(int.Parse(idUsuario), int.Parse(idCurso), int.Parse(nota), int.Parse(periodo), int.Parse(annio), comentarios);

            //IEnumerable<TipoBeca> listaNueva = gestorTipoBeca.consultarTipoBecas();

            //if (listaVieja.Count() < listaNueva.Count())
            //{
            //    return true;
            //}
            //return false;
        }

        [OperationContract]
        [WebGet(UriTemplate = "actualizar?idCalificacion={idCalificacion}&idCurso={idCurso}&nota={nota}&periodo={periodo}&annio={annio}", ResponseFormat = WebMessageFormat.Json)]
        public void ModificarCalificacion(string idCalificacion, string idCurso, string nota, string periodo, string annio)
        {

            gestorCalificacion.editarCalificacion(int.Parse(idCalificacion), int.Parse(idCurso), int.Parse(nota), int.Parse(periodo), int.Parse(annio));


        }

        [OperationContract]
        [WebGet(UriTemplate = "/borrar/{id}", ResponseFormat = WebMessageFormat.Json)]
        public void BorrarCalificacion(string id)
        {
            //IEnumerable<Calificacion> listaVieja = gestorCalificacion.consultarCalificaciones();

            gestorCalificacion.eliminarCalificacion(int.Parse(id));

            // IEnumerable<Calificacion> listaNueva = gestorCalificacion.consultarCalificaciones();

            //if (listaVieja.Count() > listaNueva.Count())
            //{
            //    return true;
            //}
            //return false;
        }
    }
}
