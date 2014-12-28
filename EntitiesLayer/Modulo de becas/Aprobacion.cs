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
    public class Aprobacion : IEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int IdSolicitud { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public DateTime Fecha { get; set; }

        [DataMember]
        public String Comentario { get; set; }

        [DataMember]
        public bool Aprobado { get; set; }

        public Aprobacion( int idAprobacion = 0, int idSolicitud = 0, int idUsuario = 0, DateTime fecha = default(DateTime), String comentario = "", bool aprobado = false)
        {
            this.Id = idAprobacion;
            this.IdSolicitud = idSolicitud;
            this.IdUsuario = idUsuario;
            this.Fecha = fecha;
            this.Comentario = comentario;
            this.Aprobado = aprobado;
        }

        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (this.IdUsuario < 0)
            {
                yield return new RuleViolation("El usuario es requerido", "IdUsuario");
            }
            else if (this.IdSolicitud < 0)
            {
                yield return new RuleViolation("La solicitud es requerida", "IdSolicitud");
            }
            else if (String.IsNullOrEmpty(this.Comentario))
            {
                yield return new RuleViolation("El comentario es requerido", "Comentario");
            }
            yield break;
        }
    }
}
