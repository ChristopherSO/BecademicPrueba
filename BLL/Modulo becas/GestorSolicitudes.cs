using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using EntitiesLayer;
using DAL;

/**
 * Gestor de Solicitudes
 * Controla la comunicacion entre las interfaces de usuario y los objetos.
 **/
namespace BLL
{
    public class GestorSolicitudes
    {
        /**
         * Constructor Singleton del GestorSolicitudes
         ***/
        public GestorSolicitudes() { }
        
        /**
         * Agregar Solicitud
         * Metodo que permite construir un objeto tipo Solicitud mediante el repositorio encargado.
         **/
        public void agregarSolicitud(int idUsuario, int idCarrera, int idTipoBeca, int idEstudio, string fecha)
        {
            try
            {
                Solicitud Solicitud = new Solicitud { 
                    
                    idUsuario = idUsuario,
                    idCarrera = idCarrera,
                    idTipoBeca = idTipoBeca,
                    idEstudio = idEstudio,
                    fecha = fecha
                    
                };

                SolicitudRepository.Instance.Insert(Solicitud);
                SolicitudRepository.Instance.Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /**
         * Agregar Solicitud
         * Metodo que permite modificar un objeto tipo Solicitud mediante el repositorio encargado.
         **/
        public void editarSolicitud(int idSolicitud, int idUsuario, int idCarrera, int idTipoBeca, int idEstudio, string fecha)
        {
            try
            {
                Solicitud Solicitud = SolicitudRepository.Instance.GetById(idSolicitud);

                Solicitud.idUsuario = idUsuario;
                Solicitud.idCarrera = idCarrera;
                Solicitud.idTipoBeca = idTipoBeca;
                Solicitud.idEstudio = idEstudio;
                Solicitud.fecha = fecha;

                SolicitudRepository.Instance.Update(Solicitud);
                SolicitudRepository.Instance.Save();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /**
        * Eliminar Solicitud
        * Metodo que permite eliminar un objeto tipo Solicitud mediante el repositorio encargado.
        **/
        public void eliminarSolicitud(int idSolicitud)
        {
            try{
                Solicitud Solicitud = SolicitudRepository.Instance.GetById(idSolicitud);
                SolicitudRepository.Instance.Delete(Solicitud);
                SolicitudRepository.Instance.Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /**
        * Consultar Solicitudes
        * Metodo que permite traer una lista de todos los Solicitudes existentes en el sistema.
        **/
        public IEnumerable<Solicitud> consultarSolicitudes()
        {
            try
            {
                return SolicitudRepository.Instance.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public IEnumerable<Solicitud> consultarBecaPorFase(int pnumFase)
        {
            try
            {
                return SolicitudRepository.Instance.GetByFase(pnumFase);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /**
        * Consultar Solicitud
        * Metodo que permite leer un solo Solicitud de existente en el sistema.
        **/
        public Solicitud consultarSolicitud(int idSolicitud)
        {
            try{
                return SolicitudRepository.Instance.GetById(idSolicitud);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
 }
