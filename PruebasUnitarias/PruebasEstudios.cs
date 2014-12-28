using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Collections;
using BLL;
using EntitiesLayer;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasEstudios
    {
        [TestMethod]
        public void ListarEstudios()
        {
            GestorEstudios _gestor = new GestorEstudios();

            try {
                _gestor.consultarEstudios();
            } 
            catch(SqlException ex)
            {
                Assert.Fail("Fallo con la base de datos " +ex);
            }
            catch(Exception ex)
            {
                Assert.Fail("Fallo con el listar estudios " + ex);
            }

            Assert.IsTrue(true, "Listar funciona correctamente");

        }

        [TestMethod]
        public void DetallarEstudio()
        {

            GestorEstudios _gestor = new GestorEstudios();

            try
            {
                _gestor.consultarEstudio(2);
            }
            catch (SqlException ex)
            {
                Assert.Fail("Fallo con la base de datos " + ex);
            }
            catch (Exception ex)
            {
                Assert.Fail("Fallo con el listar estudios " + ex);
            }

            Assert.IsTrue(true, "Listar funciona correctamente");

        }

        [TestMethod]
        public void EliminarEstudio()
        {
            GestorEstudios _gestor = new GestorEstudios();

            try
            {
                _gestor.eliminarEstudio(6);
            }
            catch (SqlException ex)
            {
                Assert.Fail("Fallo con la base de datos " + ex);
            }
            catch (Exception ex)
            {
                Assert.Fail("Fallo con el listar estudios " + ex);
            }

            Assert.IsTrue(true, "Listar funciona correctamente");
        }

        [TestMethod]
        public void AgregarEstudio()
        {
            GestorEstudios _gestor = new GestorEstudios();

            try
            {
                _gestor.agregarEstudio(6,"2014-12-10", "Estudio realizado por el TestMethod", false);
            }
            catch (SqlException ex)
            {
                Assert.Fail("Fallo con la base de datos " + ex);
            }
            catch (Exception ex)
            {
                Assert.Fail("Fallo con el listar estudios " + ex);
            }

            Assert.IsTrue(true, "Listar funciona correctamente");
        }

        [TestMethod]
        public void ActualizarEstudio()
        {
            GestorEstudios _gestor = new GestorEstudios();

            try
            {
                _gestor.editarEstudio(5, 6, "2014-12-13", "Este estudio fue actualizado por el testMethod", true);
            }
            catch (SqlException ex)
            {
                Assert.Fail("Fallo con la base de datos " + ex);
            }
            catch (Exception ex)
            {
                Assert.Fail("Fallo con el listar estudios " + ex);
            }

            Assert.IsTrue(true, "Listar funciona correctamente");
        }

    }
}
