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

    /// <summary>
    /// Clase gestor que comunica a la UI con el entities layer.
    /// </summary>
    public class GestorTipoBeca
    {
        /// <summary>
        /// Crea una nueva instancia de tipo TipoBeca
        /// </summary>
        /// <param name="nombre">nombre de tipo String</param>
        /// <param name="descripcion">descripción de tipo String</param>
        /// <param name="icono">icono de tipo String</param>
        /// <param name="color">color de tipo String</param>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        /// <exception cref="System.ApplicationException">Se crea una nueva excepción cuando no pasó el ruleViolation.</exception>
        public void agregarTipoBeca(string nombre, string descripcion, string icono, string color, bool socioeconomico, int cantidad)
        {
            try
            {
                TipoBeca tipoBeca = new TipoBeca(0, nombre, descripcion, icono, color, socioeconomico, cantidad);

                if (tipoBeca.IsValid)
                {
                    TipoBecaRepository.Instance.Insert(tipoBeca);
                    TipoBecaRepository.Instance.Save();
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in tipoBeca.GetRuleViolations())
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

        /// <summary>
        /// Llama a una instancia de tipo TipoBeca y le asigna un beneficio al TipoBeca.
        /// </summary>
        /// <param name="pidTipoBeca">pidTipoBeca de tipo Integer</param>
        /// <param name="pidBeneficio">pIdBeneficio de tipo Integer</param>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        /// <exception cref="System.ApplicationException">Se crea una nueva excepción cuando no pasó el ruleViolation.</exception>
        public void asignarBeneficio(int pidTipoBeca, int pidBeneficio)
        {
            try
            {
                TipoBeca tipoBeca = TipoBecaRepository.Instance.GetById(pidTipoBeca);

                if (tipoBeca.IsValid)
                {

                    foreach (Beneficio beneficio in tipoBeca.LstBeneficios)
                    {
                        if (pidBeneficio == beneficio.Id)
                        {
                            throw new ApplicationException("Este beneficio ya está asignado");
                        }
                    }

                    tipoBeca.setBeneficio(pidBeneficio);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in tipoBeca.GetRuleViolations())
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
                throw new Exception(String.Format(ex.Message));
            }
        }

        /// <summary>
        /// Llama a una instancia de tipo TipoBeca y le asigna un requisito al TipoBeca.
        /// </summary>
        /// <param name="pidTipoBeca">pidTipoBeca de tipo Integer</param>
        /// <param name="pidRequisito">pidRequisito de tipo Integer</param>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        /// <exception cref="System.ApplicationException">Se crea una nueva excepción cuando no pasó el ruleViolation.</exception>
        public void asignarRequisito(int pidTipoBeca, int pidRequisito)
        {
            try
            {
                TipoBeca tipoBeca = TipoBecaRepository.Instance.GetById(pidTipoBeca);

                if (tipoBeca.IsValid)
                {

                    foreach (Requisito requisito in tipoBeca.LstRequisitos)
                    {

                        if (pidRequisito == requisito.Id)
                        {
                            throw new ApplicationException("Este requisito ya está asignado");
                        }
                    }

                    tipoBeca.setRequisito(pidRequisito);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in tipoBeca.GetRuleViolations())
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
                throw new Exception(String.Format(ex.Message));
            }
        }

        /// <summary>
        /// Llama a una instancia de tipo TipoBeca y le asigna una carrera al TipoBeca.
        /// </summary>
        /// <param name="pidTipoBeca">pdIdTipoBeca de tipo Integer</param>
        /// <param name="pidCarrera">pIdCarrera de tipo Integer</param>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        /// <exception cref="System.ApplicationException">Se crea una nueva excepción cuando no pasó el ruleViolation.</exception>
        public void asignarCarrera(int pidTipoBeca, int pidCarrera)
        {
            try
            {
                TipoBeca tipoBeca = TipoBecaRepository.Instance.GetById(pidTipoBeca);

                if (tipoBeca.IsValid)
                {
                    foreach (Carrera carrera in tipoBeca.LstCarreras){

                        if (pidCarrera == carrera.Id)
                        {
                            throw new ApplicationException("Esta carrera ya está asignada");
                        }
                    }

                    tipoBeca.setCarrera(pidCarrera);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (RuleViolation rv in tipoBeca.GetRuleViolations())
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
                throw new Exception(String.Format(ex.Message));
            }
        }

        /// <summary>
        /// Cambia los datos a una instancia de tipo TipoBeca.
        /// </summary>
        /// <param name="idTipoBeca">idTipoBeca de tipo Integer</param>
        /// <param name="nombre">nombre de tipo String</param>
        /// <param name="descripcion">descripción de tipo String</param>
        /// <param name="icono">icono de tipo String</param>
        /// <param name="color">color de tipo String</param>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public void editarTipoBeca(int idTipoBeca, string nombre, string descripcion, string icono, string color, bool socioeconomico, int cantidad)
        {
            try
            {
                TipoBeca tipoBeca = TipoBecaRepository.Instance.GetById(idTipoBeca);
                tipoBeca.Nombre = nombre;
                tipoBeca.Descripcion = descripcion;
                tipoBeca.Icono = icono;
                tipoBeca.Color = color;
                tipoBeca.Socioeconomico = socioeconomico;
                tipoBeca.Cantidad = cantidad;
                TipoBecaRepository.Instance.Update(tipoBeca);
                TipoBecaRepository.Instance.Save();
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
        /// Elimina una instacia de tipo TipoBeca
        /// </summary>
        /// <param name="idTipoBeca">idTipoBeca de tipo Integer</param>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public void eliminarTipoBeca(int idTipoBeca)
        {
            try
            {
                TipoBeca tipoBeca = TipoBecaRepository.Instance.GetById(idTipoBeca);
                TipoBecaRepository.Instance.Delete(tipoBeca);
                TipoBecaRepository.Instance.Save();
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
        /// Remueve la instancia entre el requisito escogido y el tipoBeca.
        /// </summary>
        /// <param name="idRequisito">idRequisito de tipo Integer</param>
        /// <param name="idTipoBeca">idTipoBeca de tipo Integer</param>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public void eliminarRequisitoBeca(int idRequisito, int idTipoBeca)
        {
            try
            {
                TipoBecaRepository.Instance.DeleteRequisitoBeca(idRequisito, idTipoBeca);
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
        /// Remueve la instancia entre el beneficio escogido y el tipoBeca.
        /// </summary>
        /// <param name="idBeneficio">idBeneficio de tipo Integer</param>
        /// <param name="idTipoBeca">idTipoBeca de tipo Integer</param>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public void eliminarBeneficioBeca(int idBeneficio, int idTipoBeca)
        {
            try
            {
                TipoBecaRepository.Instance.DeleteBeneficioBeca(idBeneficio, idTipoBeca);
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
        /// Remueve la instancia entre la carrera escogida y el tipoBeca.
        /// </summary>
        /// <param name="idCarrera">idCarrera de tipo Integer</param>
        /// <param name="idTipoBeca">idTipoBeca de tipo Integer</param>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public void eliminarCarreraBeca(int idCarrera, int idTipoBeca)
        {
            try{
            TipoBecaRepository.Instance.DeleteCarreraBeca(idCarrera, idTipoBeca);
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
        /// Consulta los tipoBecas registrados.
        /// </summary>
        /// <returns>LstTipoBeca de tipo IEnumerable(TipoBeca)</returns>
        /// <remarks>Retorna una lista.</remarks>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public IEnumerable<TipoBeca> consultarTipoBecas()
        {
            try
            {
                return TipoBecaRepository.Instance.GetAll();
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
        /// Consulta el tipoBeca registrado por Id.
        /// </summary>
        /// <param name="idTipoBeca">idTipoBeca de tipo Integer</param>
        /// <returns>Retorna una beca de tipo TipoBeca</returns>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public TipoBeca consultarTipoBecaById(int idTipoBeca)
        {
            TipoBeca tipoBeca = null;

            try
            {
                tipoBeca = TipoBecaRepository.Instance.GetById(idTipoBeca);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }

            return tipoBeca;
        }

        /// <summary>
        /// Busca un tipo de beca por nombre.
        /// </summary>
        /// <param name="nombre">nombre de tipo String</param>
        /// <returns>Retorna una beca de tipo TipoBeca</returns>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public IEnumerable<TipoBeca> buscarTipoBeca(String nombre)
        {
            try
            {
                return TipoBecaRepository.Instance.buscarTipoBeca(nombre);
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
        /// Consulta los requisitos asociados a un tipoBeca.
        /// </summary>
        /// <param name="idTipoBeca">idTipoBeca de tipo Integer</param>
        /// <returns>Retorna los requisitos asociados de tipo IEnumerable(Requisito)</returns>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public IEnumerable<Requisito> consultarRequisitosBeca(int idTipoBeca)
        {
            TipoBeca tipoBeca = null;
            try
            {
                tipoBeca = consultarTipoBecaById(idTipoBeca);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
            
            return tipoBeca.LstRequisitos;
        }

        /// <summary>
        /// Consulta los beneficios asociados a un tipoBeca.
        /// </summary>
        /// <param name="idTipoBeca">idTipoBeca de tipo Integer</param>
        /// <returns>Retorna los beneficios asociados de tipo IEnumerable(Beneficio)</returns>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public IEnumerable<Beneficio> consultarBeneficiosBeca(int idTipoBeca)
        {
            TipoBeca tipoBeca = null;

            try
            {
                tipoBeca = consultarTipoBecaById(idTipoBeca);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }

            return tipoBeca.LstBeneficios;
        }

        /// <summary>
        /// Consulta las carreras asociadas a un tipoBeca.
        /// </summary>
        /// <param name="idTipoBeca">idTipoBeca de tipo Integer</param>
        /// <returns>Retorna las carreras asociadas de tipo IEnumerable(Requisito)</returns>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public IEnumerable<Carrera> consultarCarrerasBeca(int idTipoBeca)
        {
            TipoBeca tipoBeca = null;

            try
            {
                tipoBeca = consultarTipoBecaById(idTipoBeca);
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }

            return tipoBeca.LstCarreras;
        }

        /// <summary>
        /// Se obtiene los beneficios registrados en el sistema.
        /// </summary>
        /// <returns>lista beneficios (lstBeneficios) de tipo IEnumerable(Beneficio)</returns>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public IEnumerable<Beneficio> getBeneficios()
        {
            IEnumerable<Beneficio> lstBeneficios = null;

            try
            {
                lstBeneficios = TipoBecaRepository.Instance.GetBeneficios();
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }

            return lstBeneficios;
        }

        /// <summary>
        /// Se obtiene los requisitos registrados en el sistema.
        /// </summary>
        /// <returns>lista requisitos (lstRequisitos) de tipo IEnumerable(Requisito)</returns>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public IEnumerable<Requisito> getRequisitos()
        {
            IEnumerable<Requisito> lstRequisitos = null;

            try
            {
                lstRequisitos = TipoBecaRepository.Instance.GetRequisitos();
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }

            return lstRequisitos;
        }

        /// <summary>
        /// Se obtiene las carreras registradas en el sistema.
        /// </summary>
        /// <returns>lista carreras (lstCarreras) de tipo IEnumerable(Carrera)</returns>
        /// <exception cref="System.Exception">Se captura la excepción cuando fue lanzada desde la capa entities layer, 
        /// y la lanza al UI.</exception>
        public IEnumerable<Carrera> getCarreras()
        {
            IEnumerable<Carrera> lstCarreras = null;

            try
            {
                lstCarreras = TipoBecaRepository.Instance.GetCarreras();
            }

            catch (DataAccessException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Error: {0}", ex.Message));
            }
            return lstCarreras;
        }
    }
 }
