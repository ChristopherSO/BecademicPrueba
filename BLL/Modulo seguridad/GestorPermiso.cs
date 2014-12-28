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
 * Gestor de Permiso
 * Controla la comunicacion entre las interfaces de usuario y los objetos.
 **/
namespace BLL
{

    public class GestorPermiso
    {

        /**
          * Constructor Singleton del GestorPermiso
          ***/
        public GestorPermiso() { }

        /**
        * Consultar Permiso
        * Metodo que permite traer una lista de todos los permisos existentes en el sistema.
        **/
        public IEnumerable<PermisoRol> consultarPermiso()
        {
          try{

            return PermisoRepositorio.Instance.GetAll();
            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }
        /**
        * Consultar Permiso de rol
        * Metodo que permite traer una lista de todos los Permiso existentes de un rol.
        **/
        public IEnumerable<PermisoRol> consultarPermisoRol(int idRol)
        {
            try{
            //Console.WriteLine(idRol);
            return PermisoRepositorio.Instance.GetPermisosRoles(idRol);
            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }
        /**
        * Asignar Permiso de Usuario
        * Metodo que permite asignar un Permiso a un rol.
        **/
        public void asignarPermisoRol(int idPermiso, int idRol)
        {
            try{

            PermisoRepositorio.Instance.AsignarPermisoRol(idPermiso, idRol);
            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }
        /**
        * Remover Permiso de Usuario
        * Metodo que permite traer una lista de todos los Permiso existentes de un usuario.
        **/
        public void removerPermisoRol(int idPermiso, int idRol)
        {
            try{
            //Console.WriteLine(idRol);
            PermisoRepositorio.Instance.RemoverPermisoRol(idPermiso, idRol);
            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }
        public DataTable getPermisoList()
        {
            try
            {
            DataTable tbl = PermisoRepositorio.Instance.GetInfo();
            return tbl;
            }

             catch (DataAccessException ex) {
                throw ex;
            }

            catch (Exception ex) {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
        }
    }//Fin GestorPermiso

} //Fin Namespace