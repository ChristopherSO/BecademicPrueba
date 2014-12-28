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
    public class Requisito : IEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdTipoRequisito { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Descripcion { get; set; }

        private TipoRequisito _tipoRequisito;
        public TipoRequisito TipoRequisito
        {
            get
            {
                if (_tipoRequisito == null)
                {
                    TipoRequisito = RequisitoRepository.Instance.buscarTipoRequisitoPorId(IdTipoRequisito);
                }
                return _tipoRequisito;
            }
            set { _tipoRequisito = value; }
        }

        public Requisito(int id = 0, int idtipoRequisito = 0, String nombre = "", String descripcion = "")
        {
            this.Id = id;
            this.Nombre = nombre;
            this.IdTipoRequisito = idtipoRequisito;
            this.TipoRequisito = null;
            this.Descripcion = descripcion;
        }
    }
}