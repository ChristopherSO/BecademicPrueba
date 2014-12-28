using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EntitiesLayer
{
    [Serializable]
    [DataContract]
    public class Estudio : IEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int idUsuarioFuncionario { get; set; }
        [DataMember]
        public string fecha { get; set; }
        [DataMember]
        public string resumenEstudio { get; set; }
        [DataMember]
        public Boolean esElegible { get; set; }

        /// <summary>El nombre del metodo IsValid valida si el objeto es válido.</summary>
        /// <returns>_valid tipo: Booleano</returns>
        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        /// <summary>El nombre del metodo getRuleViolations se obtiene si ocurrió una violación
        /// a la hora de llenar los campos requeridos de un tipo de beca.</summary>
        /// <returns>_lstViolation tipo: IEnumerable(RuleViolation)</returns>
        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            yield break;
        }
    }
}
