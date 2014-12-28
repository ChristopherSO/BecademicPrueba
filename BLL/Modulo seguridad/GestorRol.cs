using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using EntitiesLayer;
using DAL;
using TIL.CustomExceptions;

/**
 * Gestor de rol
 * Controla la comunicacion entre las interfaces de usuario y los objetos.
 **/
namespace BLL {

    public class GestorRol{

         /**
         * Constructor Singleton del GestorRol
         ***/
        public GestorRol() { }
        
        /**
         * Agregar Rol
         * Metodo que permite construir un objeto tipo Rol mediante el repositorio encargado.
         **/
        public void agregarRol(String pnombre, String pdescripcion, int pintervencion)

        {
            try
            {
                 RolUsuario Rol = new RolUsuario(-1, pnombre, pdescripcion,pintervencion);

                if (Rol.IsValid)
                {
                RolUsuarioRepository.Instance.Insert(Rol);
                RolUsuarioRepository.Instance.Save();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in Rol.GetRuleViolations())
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
         * Agregar Rol
         * Metodo que permite modificar un objeto tipo Rol mediante el repositorio encargado.
         **/
        public void editarRol(int idRol, String pnombre, String pdescripcion, int pintervencion)
        {
            try
            {

            RolUsuario Rol = RolUsuarioRepository.Instance.GetById(idRol);

            Rol.Nombre = pnombre;
            Rol.Descripcion = pdescripcion;
            Rol.Intervencion = pintervencion;

            RolUsuarioRepository.Instance.Update(Rol);
            RolUsuarioRepository.Instance.Save();
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
        * Eliminar Rol
        * Metodo que permite eliminar un objeto tipo Rol mediante el repositorio encargado.
        **/
        public void eliminarRol(int idRol) {

            try {

           RolUsuario Rol = RolUsuarioRepository.Instance.GetById(idRol);
           RolUsuarioRepository.Instance.Delete(Rol);
           RolUsuarioRepository.Instance.Save();

           }

            catch (DataAccessException ex) {
                throw ex;
            }
            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        /**
        * Consultar Rol
        * Metodo que permite traer una lista de todos los rol existentes en el sistema.
        **/
        public IEnumerable<RolUsuario> consultarRoles() {

            try{

            return RolUsuarioRepository.Instance.GetAll();

            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        /**
        * Consultar Rol de Usuario
        * Metodo que permite traer una lista de todos los rol existentes de un usuario.
        **/

        public IEnumerable<RolUsuario> consultarRolesUsuario(int idUsuario) {

          try{

            //Console.WriteLine(idUsuario);
            return RolUsuarioRepository.Instance.GetRolesUsuario(idUsuario);

            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }


        /**
        * Asignar Rol de Usuario
        * Metodo que permite asignar un rol a un usuario.
        **/
        public void asignarRolUsuario(int idRol, int idUsuario) {

          try{

              //Console.WriteLine(idUsuario);
              RolUsuarioRepository.Instance.AsignarRolesUsuario(idRol, idUsuario);

            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        /**
        * Remover Rol de Usuario
        * Metodo que permite traer una lista de todos los rol existentes de un usuario.
        **/
        public void removerRolUsuario(int idRol, int idUsuario) {

          try{

            //Console.WriteLine(idUsuario);
            RolUsuarioRepository.Instance.RemoverRolesUsuario(idRol, idUsuario);

            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }


        /**
        * Consultar Rol
        * Metodo que permite leer un solo curso de existente en el sistema.
        **/
        public RolUsuario consultarRol(int idRol) {

        try{

            return RolUsuarioRepository.Instance.GetById(idRol);

            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

        public RolUsuario consultarRolUsuario(int idRol)
        {
            try
            {

                return RolUsuarioRepository.Instance.GetById(idRol);
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

        public DataTable getRolList() {

       try{

           DataTable tbl = RolUsuarioRepository.Instance.GetInfo();
           return tbl;

            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }


        public DataTable consultarFases() {

            try {

            DataTable tbl = RolUsuarioRepository.Instance.GetFases();
            return tbl;

            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }

    }//Fin GestorRol

} //Fin Namespace
