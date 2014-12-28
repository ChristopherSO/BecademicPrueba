using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using EntitiesLayer;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasSolicitudes
    {
        [TestMethod]
        public void SolicitarUnaBeca()
        {

            GestorSolicitudes _gestor = new GestorSolicitudes();

            try 
            {
                _gestor.agregarSolicitud(6, 30, 2, -1, "2014-12-10");
            }
            catch(Exception ex)
            {
                Assert.IsTrue(false, "Error al procesar la prueba " + ex);
            }

            Assert.IsTrue(true, "La prueba fue realizada exitosamente");

        }

        [TestMethod]
        public void DetallesDeSolicitud()
        {
            GestorSolicitudes _gestor = new GestorSolicitudes();
            Solicitud _solicitud = new Solicitud();

            try 
            {
               _solicitud = _gestor.consultarSolicitud(8);
            }
            catch(Exception ex)
            {
                Assert.Fail("Fallo al momento de detallar la solicitud " + ex);
            }

            Assert.IsTrue(true, "Detalles de la solicitud " + _solicitud.Id + " " + _solicitud.idUsuario + " " + _solicitud.idCarrera + " " + _solicitud.idTipoBeca + " " + _solicitud.idEstudio + " " + _solicitud.fecha);

        }

        [TestMethod]
        public void ListarSolicitudes()
        {
            GestorSolicitudes _gestor = new GestorSolicitudes();
            Solicitud solicitud = new Solicitud();

            bool resultado = false;

            IEnumerable<Solicitud> lstSolicitud = _gestor.consultarSolicitudes();

            if (lstSolicitud != null)
            {
                //foreach (int solicitud.Id in lstSolicitud)
                //{
                //    // do stuff here
                //}

                resultado = true;
            }

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void EliminarSolicitud()
        {
            GestorSolicitudes _gestor = new GestorSolicitudes();

            try
            {
                _gestor.eliminarSolicitud(12);
            }
            catch (SqlException ex)
            {
                Assert.Fail("Fallo en la base de datos al eliminar la solicitud " + ex);
            }

            Assert.IsTrue(true, "Solicitudes eliminada correctamente");
        }

        [TestMethod]
        public void ActualizarSolicitud()
        {
            GestorSolicitudes _gestor = new GestorSolicitudes();

            try
            {
                _gestor.editarSolicitud(13, 1, 23, 17, -1, "2015-01-10");
            }
            catch (SqlException ex)
            {
                Assert.Fail("Fallo en la base de datos al editar la solicitud " + ex);
            }

            Assert.IsTrue(true, "Solicitudes actualizada correctamente");

        }


    }
}
