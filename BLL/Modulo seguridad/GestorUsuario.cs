using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using EntitiesLayer;
using DAL;
using TIL.CustomExceptions;
using System.Security.Cryptography;

/**
 * Gestor de usuarios
 * Controla la comunicacion entre las interfaces de usuario y los objetos.
 **/

namespace BLL {

    public class GestorUsuario {

        /**
         * Constructor Singleton del GestorUsuario
         ***/
        public GestorUsuario() { }
        
        /**
         * Agregar Usuario
         * Metodo que permite construir un objeto tipo Usuario mediante el repositorio encargado.
         **/
        public void agregarUsuario(String pnombre, String papellido1, String pgenero, String pcorreo, String pcontra,
                        int pcedula, int pestado, String nombre_2 = "N/A", String papellido2 = "N/A", String ptelefono = "N/A", String pnombreRol = "", String pnombreEstado = "") {
            try
            {
                 Usuario Usuario = new Usuario(pnombre, papellido1,pgenero,pcorreo, pcontra, pcedula,
                                              pestado, nombre_2, papellido2,  ptelefono);

                if (Usuario.IsValid) {

                UsuarioRepository.Instance.Insert(Usuario);
                UsuarioRepository.Instance.Save();

                }

                else {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in Usuario.GetRuleViolations())
                    {
                        sb.AppendLine(rv.ErrorMessage);
                    }
                    throw new ApplicationException(sb.ToString());
                }
                
            }
            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }        
        

        /**
         * Agregar Usuario
         * Metodo que permite modificar un objeto tipo Usuario mediante el repositorio encargado.
         **/

      
        public void editarUsuario(int idUsuario, String pnombre, String papellido1, String pgenero, String pcorreo,
                        int pcedula, int pestado, String nombre2 = "", String papellido2 = "", String ptelefono = "")
        {

            try {

            Usuario Usuario = UsuarioRepository.Instance.GetById(idUsuario);

            Usuario.Nombre = pnombre;
            Usuario.SegundoNombre = nombre2;
            Usuario.PrimerApellido = papellido1;
            Usuario.SegundoApellido = papellido2;
            Usuario.Genero = pgenero;
            Usuario.Correo = pcorreo;
            Usuario.Cedula = pcedula;
            Usuario.Telefono = ptelefono;
            Usuario.Estado = pestado; 

            UsuarioRepository.Instance.Update(Usuario);
            UsuarioRepository.Instance.Save();
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
          }
        }

        /**
        * Eliminar Usuario
        * Metodo que permite eliminar un objeto tipo Usuario mediante el repositorio encargado.
        **/
        public void eliminarUsuario(int idUsuario) {

           try {

           Usuario Usuario = UsuarioRepository.Instance.GetById(idUsuario);
           UsuarioRepository.Instance.Delete(Usuario);
           UsuarioRepository.Instance.Save();
           }

           catch (DataAccessException ex)
           {
               throw ex;
           }
           catch (Exception ex)
           {
               throw new Exception(String.Format("Error: {0}", ex.Message));
           }
        }


        /**
        * Consultar Usuario
        * Metodo que permite traer una lista de todos los Usuario existentes en el sistema.
        **/

        public IEnumerable<Usuario> consultarUsuario()
        {
            try {

            return UsuarioRepository.Instance.GetAll();
           }

            catch (DataAccessException ex) {
                throw ex;
            }
            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        /**
        * Consultar Usuario
        * Metodo que permite leer un solo Usuario de existente en el sistema.
        **/
        public Usuario consultarUsuario(int idUsuario)
        {
            try {

            return UsuarioRepository.Instance.GetById(idUsuario);
           }

            catch (DataAccessException ex) {
                throw ex;
            }
            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }
        
        public Usuario consultarUsuarioPorCarnet(int carnet)
        {
            try
            {

                return UsuarioRepository.Instance.GetByCarnet(carnet);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Metodo que permite moificar la contrasena de un usuario
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="pcontra"></param>
        public void editarContraUsuario(int idUsuario, String pcontra)
        {
            try {

            UsuarioRepository.Instance.cambiarPass(idUsuario, pcontra);
            UsuarioRepository.Instance.Save();
           }

            catch (DataAccessException ex) {
                throw ex;
            }
            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Metodo que permite a un usuario modificar su propia contrasena
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="poldPass"></param>
        /// <param name="pnewPass"></param>
        /// <returns></returns>
        public int cambiarPropiaContra(int idUsuario, String poldPass, String pnewPass)
        {
            try
            {

                return UsuarioRepository.Instance.cambiarPropiaContra(idUsuario, poldPass, pnewPass);

            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        /// <summary>
        /// Metodo que permite recuperar la contrasena de un usuario por medio de su correo
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="contra"></param>
        
        public void editarContraCorreo(String correo, String contra)
        {
            try
            {

                UsuarioRepository.Instance.recuperarPass(correo, contra);
                UsuarioRepository.Instance.Save();
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        public DataTable consultarEstados()
        {
            try
            {

            DataTable tbl = UsuarioRepository.Instance.GetEstados();
            return tbl;
           }

            catch (DataAccessException ex) {
                throw ex;
            }
            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }


    } //Fin clase GestorUsuario

}//Fin Namespace
