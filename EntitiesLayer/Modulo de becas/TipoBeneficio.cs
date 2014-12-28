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
    public class TipoBeneficio : IEntity
    {
        // Propiedades
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Nombre { get; set; }

        // Constructores
        public TipoBeneficio(int idTipoBeneficio = 0, String pNombre = "")
        {
            Id = idTipoBeneficio;
            Nombre = pNombre;
        }

    }
}
