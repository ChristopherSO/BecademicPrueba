using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EntitiesLayer
{
    /// <author>Marco Durán</author>
    /// <summary>Clase de tipo de beca</summary>

    [Serializable]
    [DataContract]
    public class TipoBeca : IEntity
    {
        /// <summary>El nombre de la propiedad Id reprensenta el campo Id de un tipo de beca.</summary>
        /// <value>Propiedad Id que se obtiene/setea el campo Id de tipo Integer.</value>
        /// <remarks>No puede ser modificable.</remarks>

        [DataMember]
        public int Id { get; set; }

        /// <summary>El nombre de la propiedad Nombre reprensenta el campo nombre de un tipo de beca.</summary>
        /// <value>Propiedad Nombre que se obtiene/setea el campo nombre de tipo String.</value>
        /// <remarks>Puede ser modificable en cualquier momento.</remarks>

        [DataMember]
        public String Nombre { get; set; }

        /// <summary>El nombre de la propiedad Descripción reprensenta el campo descripción de un tipo de beca.</summary>
        /// <value>Propiedad Descripción que se obtiene/setea el campo descripción de tipo String.</value>
        /// <remarks>Puede ser modificable en cualquier momento.</remarks>

        [DataMember]
        public String Descripcion { get; set; }

        /// <summary>El nombre de la propiedad Icono reprensenta el campo icono de un tipo de beca.</summary>
        /// <value>Propiedad Icono que se obtiene/setea el campo icono de tipo String.</value>
        /// <remarks>Puede ser modificable en cualquier momento.</remarks>

        [DataMember]
        public String Icono { get; set; }

        /// <summary>El nombre de la propiedad Color reprensenta el campo color de un tipo de beca.</summary>
        /// <value>Propiedad Color que se obtiene/setea el campo color de tipo String.</value>
        /// <remarks>Puede ser modificable en cualquier momento.</remarks>

        [DataMember]
        public String Color { get; set; }

        [DataMember]
        public bool Socioeconomico { get; set; }

        [DataMember]
        public int Cantidad { get; set; }

        private IEnumerable<Requisito> _lstRequisitos;
        private IEnumerable<Carrera> _lstCarreras;
        private IEnumerable<Beneficio> _lstBeneficios;

        /// <summary>El nombre de la propiedad LstRequisitos representa la lista de requisitos
        /// asociados de un tipo de beca.</summary>
        /// <value>La propiedad LstRequisitos se obtiene/setea el valor de la variable
        /// _lstRequisitos de tipo IEnumerable(Requisito).</value>
        /// <remarks>Puede ser modificable en cualquier momento.</remarks>
        [DataMember]
        public IEnumerable<Requisito> LstRequisitos
        {
            get
            {
                LstRequisitos = TipoBecaRepository.Instance.GetRequisitosBeca(this.Id);
                return _lstRequisitos;
            }
            set
            {
                _lstRequisitos = value;
            }
        }

        /// <summary>El nombre de la propiedad LstBeneficios representa la lista de beneficios
        /// asociados de un tipo de beca.</summary>
        /// <value>La propiedad LstBeneficios se obtiene/setea el valor de la variable
        /// _lstBeneficios de tipo IEnumerable(Beneficio).</value>
        /// <remarks>Puede ser modificable en cualquier momento.</remarks>
        [DataMember]
        public IEnumerable<Beneficio> LstBeneficios
        {
            get
            {
                LstBeneficios = TipoBecaRepository.Instance.GetBeneficiosBeca(this.Id);
                return _lstBeneficios;
            }
            set
            {
                _lstBeneficios = value;
            }
        }

        /// <summary>El nombre de la propiedad LstCarreras representa la lista de carreras
        /// asociados de un tipo de beca.</summary>
        /// <value>La propiedad LstCarreras se obtiene/setea el valor de la variable
        /// _lstCarreras de tipo IEnumerable(Carrera).</value>
        /// <remarks>Puede ser modificable en cualquier momento.</remarks>
        [DataMember]
        public IEnumerable<Carrera> LstCarreras
        {
            get
            {
                LstCarreras = TipoBecaRepository.Instance.GetCarrerasBeca(this.Id);
                return _lstCarreras;
            }
            set
            {
                _lstCarreras = value;
            }
        }

        /// <summary>Constructor de la clase tipo de beca.</summary>
        /// <param name="id">Id tipo: Integer</param>
        /// <param name="nombre">Nombre tipo: String</param>
        /// <param name="descripcion">Descripción tipo: String</param>
        /// <param name="icono">Icono tipo: String</param>
        /// <param name="color">Color tipo: String</param>
        public TipoBeca(int id = 0, String nombre = "", String descripcion = "", String icono = "", String color = "", bool socioeconomico = false, int cantidad = 0)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Icono = icono;
            this.Color = color;
            this.Socioeconomico = socioeconomico;
            this.Cantidad = cantidad;
            this.LstRequisitos = null;
            this.LstBeneficios = null;
            this.LstCarreras = null;
        }

        /// <summary>El nombre del metodo setBeneficio setea el beneficio de un tipo de beca.</summary>
        /// <param name="pidBeneficio">pidBeneficio tipo: Integer</param>
        public void setBeneficio(int pidBeneficio)
        {
            TipoBecaRepository.Instance.AsignarBeneficioBeca(this.Id, pidBeneficio);
        }

        /// <summary>El nombre del metodo setRequisito setea el requisito de un tipo de beca.</summary>
        /// <param name="pidRequisito"></param>
        public void setRequisito(int pidRequisito)
        {
            TipoBecaRepository.Instance.AsignarRequisitoBeca(this.Id, pidRequisito);
        }

        /// <summary>El nombre del metodo setCarrera setea la carrera de un tipo de beca.</summary>
        /// <param name="pidCarrera"></param>
        public void setCarrera(int pidCarrera)
        {
            TipoBecaRepository.Instance.AsignarCarreraBeca(this.Id, pidCarrera);
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
            if (String.IsNullOrEmpty(Nombre))
            {
                yield return new RuleViolation("Nombre es requerido", "Nombre");
            }
            else if (String.IsNullOrEmpty(Descripcion))
            {
                yield return new RuleViolation("La descripción es requerido", "Descripcion");
            }

            yield break;
        }
    }
}