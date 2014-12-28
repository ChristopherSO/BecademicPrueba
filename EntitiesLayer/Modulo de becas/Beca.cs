using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EntitiesLayer
{
    /// <author>Christopher Suárez</author>
    /// <summary>Clase de Beca</summary>

    [Serializable]
    [DataContract]
    public class Beca : IEntity
    {

        // Propiedades
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdCarrera { get; set; }
        [DataMember]
        public DateTime FechaAprobacion { get; set; }
        [DataMember]
        public int IdUsuario { get; set; }
        [DataMember]
        public int IdTipoBeca { get; set; }
        [DataMember]
        public bool Estado { get; set; }
        [DataMember]
        public String Comentario { get; set; }

        [DataMember]
        private Carrera _carrera;
        public Carrera Carrera
        {
            get
            {
                if (_carrera == null)
                {
                    Carrera = CarreraRepository.Instance.GetById(IdCarrera);
                }
                return _carrera;
            }
            set { _carrera = value; }
        }

        [DataMember]
        private Usuario _usuario;
        public Usuario Usuario
        {
            get
            {
                if (_usuario == null)
                {
                    Usuario = UsuarioRepository.Instance.GetById(IdUsuario);
                }
                return _usuario;
            }
            set { _usuario = value; }
        }

        [DataMember]
        private TipoBeca _tipoBeca;
        public TipoBeca TipoBeca
        {
            get
            {
                if (_tipoBeca == null)
                {
                    TipoBeca = TipoBecaRepository.Instance.GetById(IdTipoBeca);
                }
                return _tipoBeca;
            }
            set { _tipoBeca = value; }
        }

        // Constructor
        public Beca(int pIdBeca = 0, int pIdCarrera = 0, DateTime pFechaAprobacion = default(DateTime), int pIdUsuario = 0, int pIdTipoBeca = 0, bool pEstado = false, string pComentario = "")
        {
            Id = pIdBeca;
            IdCarrera = pIdCarrera;
            FechaAprobacion = pFechaAprobacion;
            IdUsuario = pIdUsuario;
            IdTipoBeca = pIdTipoBeca;
            Estado = pEstado;
            Comentario = pComentario;
        }


        /// <summary>El nombre del método ListaTiposDeBeca representa la lista de tipos de becas
        /// que están relacionados con esta Beca.</summary>
        /// <value>El método ListaTiposDeBeca obtiene la lista de tipo IEnumerable(Carrera).</value>
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
            //if (String.IsNullOrEmpty(Nombre))
            //{
            //    yield return new RuleViolation("Nombre es requerido", "Nombre");
            //}
            yield break;
        }

    }
}
