using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using EntitiesLayer;
using DAL;

/**
 * Gestor de Estudios
 * Controla la comunicacion entre las interfaces de usuario y los objetos.
 **/
namespace BLL
{
    public class GestorEstudios
    {
        /**
         * Constructor Singleton del GestorEstudios
         ***/
        public GestorEstudios() { }
        
        /**
         * Agregar Estudio
         * Metodo que permite construir un objeto tipo Estudio mediante el repositorio encargado.
         **/
        public void agregarEstudio(int id_funcionario, string fecha, string resumen_socioeconomico, bool esElegible)
        {
            try
            {
                Estudio estudio = new Estudio { 
                    
                    idUsuarioFuncionario = id_funcionario,
                    fecha = fecha,
                    resumenEstudio = resumen_socioeconomico,
                    esElegible = esElegible
                    
                };

                EstudioRepository.Instance.Insert(estudio);
                EstudioRepository.Instance.Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /**
         * Agregar Estudio
         * Metodo que permite modificar un objeto tipo Estudio mediante el repositorio encargado.
         **/
        public void editarEstudio(int idEstudio, int idFuncionario, string fecha, string resumen, bool elegible)
        {
            try
            {
                Estudio estudio = EstudioRepository.Instance.GetById(idEstudio);

                estudio.idUsuarioFuncionario = idFuncionario;
                estudio.fecha = fecha;
                estudio.resumenEstudio = resumen;
                estudio.esElegible = elegible;

                EstudioRepository.Instance.Update(estudio);
                EstudioRepository.Instance.Save();
            }

            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /**
        * Eliminar Estudio
        * Metodo que permite eliminar un objeto tipo Estudio mediante el repositorio encargado.
        **/
        public void eliminarEstudio(int idEstudio)
        {
            try{
                Estudio estudio = EstudioRepository.Instance.GetById(idEstudio);
                EstudioRepository.Instance.Delete(estudio);
                EstudioRepository.Instance.Save();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /**
        * Consultar Estudios
        * Metodo que permite traer una lista de todos los Estudios existentes en el sistema.
        **/
        public IEnumerable<Estudio> consultarEstudios()
        {
            try
            {
                return EstudioRepository.Instance.GetAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        /**
        * Consultar Estudio
        * Metodo que permite leer un solo Estudio de existente en el sistema.
        **/
        public Estudio consultarEstudio(int idEstudio)
        {
            try{
                return EstudioRepository.Instance.GetById(idEstudio);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
 }
