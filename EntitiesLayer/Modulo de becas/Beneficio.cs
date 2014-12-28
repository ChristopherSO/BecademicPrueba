using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EntitiesLayer
{
    /// <author>Christopher Suárez</author>
    /// <summary>Clase de Beneficio</summary>

    [Serializable]
    [DataContract]
    public class Beneficio : IEntity
    {

        // Propiedades
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdTipoBeneficio { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String Valor { get; set; }

        [DataMember]
        private TipoBeneficio _tipoBeneficio;
        public TipoBeneficio TipoBeneficio
        {
            get
            {
                if (_tipoBeneficio == null)
                {
                    TipoBeneficio = BeneficioRepository.Instance.buscarTipoBeneficioPorId(IdTipoBeneficio);
                }
                return _tipoBeneficio;
            }
            set { _tipoBeneficio = value; }
        }

        // Constructor
        public Beneficio(int pIdBeneficio = 0, int pIdTipoBeneficio = 0, String pNombre = "", String pDescripcion = "", String pValor = "")
        {
            Id = pIdBeneficio;
            IdTipoBeneficio = pIdTipoBeneficio;
            Nombre = pNombre;
            Descripcion = pDescripcion;
            Valor = pValor;
        }


        /// <summary>El nombre del método ListaTiposDeBeca representa la lista de tipos de becas
        /// que están relacionados con este beneficio.</summary>
        /// <value>El método ListaTiposDeBeca obtiene la lista de tipo IEnumerable(TipoBeneficio).</value>
        public IEnumerable<TipoBeca> ListaTiposDeBeca()
        {
            return TipoBecaRepository.Instance.GetTiposDeBecaPorIdBeneficio(this.Id);
        }

        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                yield return new RuleViolation("Nombre es requerido", "Nombre");
            }
            yield break;
        }


    }
}