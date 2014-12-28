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
    public class Solicitud : IEntity
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int idUsuario { get; set; }
        [DataMember]
        public int idCarrera { get; set; }
        [DataMember]
        public int idTipoBeca { get; set; }
        [DataMember]
        public int idEstudio { get; set; }
        [DataMember]
        public string fecha { get; set; }
        [DataMember]
        public Estudio EstudioSocioEconomico
        {
            get
            {
                Estudio _estudio = new Estudio();
                if (idEstudio > 0)
                {
                    _estudio = EstudioRepository.Instance.GetById(this.idEstudio);
                }
                return _estudio;
            }
            set
            {
                this.EstudioSocioEconomico = value;
            }
        }
        [DataMember]
        public Carrera Carrera 
        {
            get {
                Carrera _carrera = new Carrera();
                if(idCarrera > 0)
                {
                    _carrera = CarreraRepository.Instance.GetById(idCarrera);
                }
                return _carrera;
            }
            set {
                this.Carrera = value;
            }
        }
        [DataMember]
        public Usuario Usuario 
        {
            get {
                Usuario _usuario = new Usuario();
                if(idUsuario > 0)
                {
                    _usuario = UsuarioRepository.Instance.GetById(idUsuario);
                }
                return _usuario;
            }
            set {
                this.Usuario = value;
            }
        }
        [DataMember]
        public TipoBeca TipoDeBeca 
        {
            get {
                TipoBeca _tipoDeBeca = new TipoBeca();
                if(idTipoBeca > 0)
                {
                    _tipoDeBeca = TipoBecaRepository.Instance.GetById(idTipoBeca);
                }
                return _tipoDeBeca;
            }
            set {
                this.TipoDeBeca = value;
            }
        }
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
