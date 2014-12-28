using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntitiesLayer;
using BLL;
using System.Collections.Generic;
using Servicios.ModuloBecas;

namespace PruebasUnitarias
{
    [TestClass]
    public class PruebasBecas
    {
        GestorBecas gestorBecas = new GestorBecas();
        GestorUsuario gestorUsuario = new GestorUsuario();
        ServiciosBecas servicio = new ServiciosBecas();

        [TestMethod]
        public void obtenerUsuarioPorIdBeca()
        {
            // Arrange
            Usuario usuarioEsperado = gestorUsuario.consultarUsuario(6);

            // Act
            Usuario usuarioObtenido = gestorBecas.consultarBecaPorID(3).Usuario;

            // Asert
            Assert.AreEqual(usuarioEsperado.Nombre, usuarioObtenido.Nombre);

        }
    }
}
