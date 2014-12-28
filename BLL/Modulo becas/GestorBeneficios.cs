using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using EntitiesLayer;
using DAL;
using TIL.CustomExceptions;

namespace BLL
{
    public class GestorBeneficios
    {
        public void agregarBeneficio(int pIdTipoBeneficio, string pNombre, string pDescripcion, string pValor)
        {
            try
            {
                Beneficio beneficio = new Beneficio(-1, pIdTipoBeneficio, pNombre, pDescripcion, pValor);

                if (beneficio.IsValid)
                {
                    BeneficioRepository.Instance.Insert(beneficio);
                    BeneficioRepository.Instance.Save();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in beneficio.GetRuleViolations())
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

        public void editarBeneficio(int pIdBeneficio, int pIdTipoBeneficio, string pNombre, string pDescripcion, string pValor)
        {
            try
            {
                Beneficio beneficio = BeneficioRepository.Instance.GetById(pIdBeneficio);
                beneficio.IdTipoBeneficio = pIdTipoBeneficio;
                beneficio.Nombre = pNombre;
                beneficio.Descripcion = pDescripcion;
                beneficio.Valor = pValor;
                BeneficioRepository.Instance.Update(beneficio);
                BeneficioRepository.Instance.Save();
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

        public void eliminarBeneficio(int pIdBeneficio)
        {
            try
            {
                Beneficio beneficio = BeneficioRepository.Instance.GetById(pIdBeneficio);
                BeneficioRepository.Instance.Delete(beneficio);
                BeneficioRepository.Instance.Save();
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


        public IEnumerable<Beneficio> consultarBeneficios()
        {
            try
            {
                return BeneficioRepository.Instance.GetAll();
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

        public Beneficio consultarBeneficioPorID(int pIdBeneficio)
        {
            try
            {
                return BeneficioRepository.Instance.GetById(pIdBeneficio);
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
        /// Consulta la cantidad de tipos de beca asociados a un beneficio.
        /// </summary>
        /// <param name="idTipoBeca">idBeneficio de tipo Integer</param>
        /// <returns>Retorna la cantidad de tipos de beca asociados de tipo IEnumerable(TipoBeca)</returns>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public int consultarCantTiposDeBecaPorIdBeneficio(int idBeneficio)
        {
            Beneficio beneficio = null;

            try
            {
                beneficio = consultarBeneficioPorID(idBeneficio);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }

            return beneficio.ListaTiposDeBeca().Count();
        }

        public IEnumerable<TipoBeneficio> buscarTiposDeBeneficios()
        {
            try
            {
                return BeneficioRepository.Instance.BuscarTiposDeBeneficios();
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
