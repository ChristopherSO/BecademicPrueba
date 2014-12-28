using System;
using EntitiesLayer;
using BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Servicios.ModuloSeguridad;

namespace UnitTests
{

    [TestClass]
    public class PruebaUsuarios
    {

        GestorUsuario gestor = new GestorUsuario();
        ServiciosUsuario servicio = new ServiciosUsuario();

        [TestMethod]
        public void ReconoceUsuariosDiferentes()
        {


            Usuario usuarioViejo = new Usuario(-1, "Jean", "Paul", "Maradiaga");
            Usuario usuarioNuevo = new Usuario(-2, "Jean", "Paul", "Berlitz");

            bool resultado = false;

            if (ObjectUtils.IsALike(usuarioViejo, usuarioNuevo))
            {
                resultado = true;
            }

            Assert.IsFalse(resultado);

        }

        [TestMethod]
        public void UsuariosIguales()
        {

            Usuario usuarioViejo = new Usuario(-1, "Jean", "Paul", "Maradiaga");
            Usuario usuarioNuevo = new Usuario(-1, "Jean", "Paul", "Maradiaga");

            bool resultado = false;

            if (ObjectUtils.IsALike(usuarioViejo, usuarioNuevo))
            {
                resultado = true;
            }

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void ListaValida()
        {

            bool resultado = false;

            IEnumerable<Usuario> lstUsuario = gestor.consultarUsuario();

            if (lstUsuario != null)
            {
                resultado = true;
            }

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void ListarDetalles()
        {

            Usuario usuario = servicio.InformacionDeUsuario("1");

            Assert.IsNotNull(usuario);

        }


        [TestMethod]
        public void ServicioAgregar()
        {

            bool resultado = false;

            resultado = servicio.AgregarUsuario("Jean", "Berlitz", "M", "jberlitz@ucenfotec.ac.cr", "1165461",
                                      "1");

            Assert.IsTrue(resultado);

        }

        [TestMethod]
        public void ServicioModificar()
        {

            bool resultado = false;

            resultado = servicio.ModificarUsuario("1", "Johan", "Berlitz", "M", "jberlitz@ucenfotec.ac.cr", "1165461",
                                      "1", "N/A", "Limantour");

            Assert.IsTrue(resultado);

        }


        [TestMethod]
        public void ServicioEliminar()
        {

            bool resultado = false;

            resultado = servicio.EliminarUsuario("6");

            Assert.IsTrue(resultado);

        }

    } //Fin pruebaUsuario

}//Fin Namespace UnitTests