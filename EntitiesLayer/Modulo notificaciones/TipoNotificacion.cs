using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EntitiesLayer
{
    /// <author>Christopher Suárez</author>
    /// <summary>Clase de TipoNotificacion</summary>

    [Serializable]
    [DataContract]
    public class TipoNotificacion : IEntity
    {

        // Propiedades

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


        /// <summary>Constructor de la clase tipo de notificación.</summary>
        /// <param name="id">Id tipo: Integer</param>
        /// <param name="nombre">Nombre tipo: String</param>
        /// <param name="descripcion">Descripción tipo: String</param>
        /// <param name="icono">Icono tipo: String</param>
        /// <param name="color">Color tipo: String</param>
        public TipoNotificacion(int id = 0, String nombre = "", String descripcion = "", String icono = "", String color = "")
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Icono = icono;
            this.Color = color;
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
