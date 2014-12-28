using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
    [Serializable]
    [DataContract]
    public class TipoRequisito : IEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String Extensiones { get; set; }


        public TipoRequisito(int id = 0,String nombre = "", String descripcion = "", String extenciones = "")
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Extensiones = extenciones;
        }
    }

}
