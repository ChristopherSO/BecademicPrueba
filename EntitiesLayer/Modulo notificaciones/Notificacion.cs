using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EntitiesLayer
{
    /// <author>Christopher Suárez</author>
    /// <summary>Clase de Notificacion</summary>

    [Serializable]
    [DataContract]
    public class Notificacion : IEntity
    {

        // Propiedades
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdUsuarioAutor { get; set; }
        [DataMember]
        public int IdTipoNotificacion { get; set; }
        [DataMember]
        public String Mensaje { get; set; }
        [DataMember]
        public DateTime Fecha { get; set; }

        // Relaciones
        //[DataMember]
        private Usuario usuarioAutor;
        public Usuario UsuarioAutor
        {
            get
            {
                if (usuarioAutor == null)
                {
                    UsuarioAutor = UsuarioRepository.Instance.GetById(IdUsuarioAutor);
                }
                return usuarioAutor;
            }
            set { usuarioAutor = value; }
        }

        //[DataMember]
        private TipoNotificacion _tipoNotificacion;
        public TipoNotificacion TipoNotificacion
        {
            get
            {
                if (_tipoNotificacion == null)
                {
                    TipoNotificacion = NotificacionRepository.Instance.buscarTipoNotificacionPorId(IdTipoNotificacion);
                }
                return _tipoNotificacion;
            }
            set { _tipoNotificacion = value; }
        }

        // Constructor
        public Notificacion(int pIdNotificacion = 0, int pIdUsuarioAutor = 0, int pIdTipoNotificacion = 0, string pMensaje = "", DateTime pFecha = default(DateTime))
        {
            this.Id = pIdNotificacion;
            this.IdUsuarioAutor = pIdUsuarioAutor;
            this.IdTipoNotificacion = pIdTipoNotificacion;
            this.Mensaje = pMensaje;
            this.Fecha = pFecha;
            this.UsuarioAutor = null;
            this.TipoNotificacion = null;
        }


        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            //if (String.IsNullOrEmpty(Nombre))
            //{
            //    yield return new RuleViolation("Nombre es requerido", "Nombre");
            //}
            yield break;
        }

    }
}
