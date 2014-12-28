using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System.Collections;
using EntitiesLayer;
using Servicios.ModuloBecas;

namespace PruebasUnitarias
{
    [TestClass]
    public class tipoBecaTesting
    {

        ServicioTipoBeca servicios = new ServicioTipoBeca();

        [TestMethod]
        public void asignarBeneficioTest()
        {

            GestorTipoBeca gestor = new GestorTipoBeca();
            int idTipoBeca = 17;
            int idBeneficio = 3;

            bool resultado = false;

            try
            {
                gestor.asignarBeneficio(idTipoBeca, idBeneficio);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void asignarBeneficioServiceTest()
        {

            string idTipoBeca = "17";
            string idBeneficio = "4";
            
            bool resultado = false;

            try
            {
                servicios.AsignarBeneficioBeca(idTipoBeca, idBeneficio);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void asignarBeneficioServiceTestFail()
        {

            string idTipoBeca = "17";
            string idBeneficio = "4";

            bool resultado = false;

            try
            {
                servicios.AsignarBeneficioBeca(idTipoBeca, idBeneficio);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void asignarBeneficioTestFail()
        {

            GestorTipoBeca gestor = new GestorTipoBeca();
            int idTipoBeca = 17;
            int idBeneficio = 3;

            bool resultado = false;

            try
            {
                gestor.asignarBeneficio(idTipoBeca, idBeneficio);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void asignaCarreraServiceTestFail()
        {

            string idTipoBeca = "17";
            string idCarrera = "27";

            bool resultado = false;

            try
            {
                servicios.AsignarCarreraBeca(idTipoBeca, idCarrera);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void asignaCarreraServiceTest()
        {

            string idTipoBeca = "17";
            string idCarrera = "28";

            bool resultado = false;

            try
            {
                servicios.AsignarCarreraBeca(idTipoBeca, idCarrera);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void asignarCarreraTest()
        {

            GestorTipoBeca gestor = new GestorTipoBeca();
            int idTipoBeca = 17;
            int idCarrera = 27;

            bool resultado = false;

            try
            {
                gestor.asignarCarrera(idTipoBeca, idCarrera);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void asignarCarreraTestFail()
        {

            GestorTipoBeca gestor = new GestorTipoBeca();
            int idTipoBeca = 17;
            int idCarrera = 3;

            bool resultado = false;

            try
            {
                gestor.asignarCarrera(idTipoBeca, idCarrera);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void asignarRequisitoTestFail()
        {

            GestorTipoBeca gestor = new GestorTipoBeca();
            int idTipoBeca = 17;
            int idRequisito = 3;

            bool resultado = false;

            try
            {
                gestor.asignarRequisito(idTipoBeca, idRequisito);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void asignarRequisitoTest()
        {

            GestorTipoBeca gestor = new GestorTipoBeca();
            int idTipoBeca = 17;
            int idRequisito = 3;

            bool resultado = false;

            try
            {
                gestor.asignarRequisito(idTipoBeca, idRequisito);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsTrue(resultado);
        }

        [TestMethod]
        public void asignaRequisitoServiceTest()
        {

            string idTipoBeca = "17";
            string idRequisito = "4";

            bool resultado = false;

            try
            {
                servicios.AsignarRequisitoBeca(idTipoBeca, idRequisito);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void asignaRequisitoServiceTestFail()
        {

            string idTipoBeca = "17";
            string idRequisito = "3";

            bool resultado = false;

            try
            {
                servicios.AsignarRequisitoBeca(idTipoBeca, idRequisito);
                resultado = true;
            }
            catch (Exception e)
            {
                resultado = false;
            }

            Assert.IsFalse(resultado);

        }
    }
}
