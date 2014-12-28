using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using DAL;
using EntitiesLayer;
using TIL.CustomExceptions;

namespace BLL
{
    public class GestorRequisito
    {

        public void agregarRequisito(string nombre, int tipoRequisito, string descripcion)
        {
            try
            {
                Requisito requisito = new Requisito(-1, tipoRequisito, nombre, descripcion);
                RequisitoRepository.Instance.Insert(requisito);
                RequisitoRepository.Instance.Save();
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

        public void editarRequisito(int idRequisito, string nombre, int tipoRequisito, string descripcion)
        {
            try
            {

                Requisito requisito = consultarRequisitoXID(idRequisito);
                requisito.Nombre = nombre;
                requisito.IdTipoRequisito = tipoRequisito;
                requisito.Descripcion = descripcion;
                RequisitoRepository.Instance.Update(requisito);
                RequisitoRepository.Instance.Save();
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

        public void eliminarRequisito(int idRequisito)
        {
            try
            {
                Requisito requisito = RequisitoRepository.Instance.GetById(idRequisito);
                RequisitoRepository.Instance.Delete(requisito);
                RequisitoRepository.Instance.Save();
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


        public IEnumerable<Requisito> consultarRequisitos()
        {
            try
            {
                return RequisitoRepository.Instance.GetAll();
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

        public IEnumerable<TipoRequisito> listarTipoRequisitos()
        {
            try
            {
                return RequisitoRepository.Instance.consultarTipoRequisitos();
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

        public ArrayList consultarRequisito(int idRequisito)
        {
            try
            {
                ArrayList lstRequisito = null;

                Requisito requisito = RequisitoRepository.Instance.GetById(idRequisito);

                lstRequisito = new ArrayList();
                lstRequisito.Add(requisito.Nombre);
                lstRequisito.Add(requisito.Descripcion);

                return lstRequisito;
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


        public Requisito consultarRequisitoXID(int idRequisito)
        {
            try
            {
                return RequisitoRepository.Instance.GetById(idRequisito);
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

        public TipoRequisito consultarTipoRequisitoXID(int idTipoRequisito)
        {
            try
            {
                return RequisitoRepository.Instance.buscarTipoRequisitoPorId(idTipoRequisito);
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
    }
 }
