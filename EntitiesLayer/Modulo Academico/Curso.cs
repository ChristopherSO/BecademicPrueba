using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

/**
 * Autor: Roger Quiros
 * Esta clase permite mantener un cuerpo canonico para la informacion de un curso
 **/
namespace EntitiesLayer
{
    [Serializable]
    [DataContract]
    public class Curso : IEntity
    {
        /**
         * Propiedades, Setters y Getters
         */
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Codigo { get; set; }
        [DataMember]
        public String Precio { get; set; }
        [DataMember]
        public int CantidadCreditos { get; set; }

        /**
         * Constructor
         * El constructor mantiene todos sus argumentos como opcionales.
         */
        public Curso(int id = 0, string nombre = "", string codigo = "", string precio = "", int cantidad_creditos = 0)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Codigo = codigo;
            this.Precio = precio;
            this.CantidadCreditos = cantidad_creditos;
        }

        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                yield return new RuleViolation("Nombre es requerido", "Nombre");
            }
            else if (String.IsNullOrEmpty(Codigo))
            {
                yield return new RuleViolation("El código es requerido", "Codigo");
            }
            else if (String.IsNullOrEmpty(Precio))
            {
                yield return new RuleViolation("El precio es requerido", "Precio");
            }
            else if (String.IsNullOrEmpty(CantidadCreditos.ToString()))
            {
                yield return new RuleViolation("La cantidad de creditos es requerida", "CantidadCreditos");
            }

            yield break;
        }
    }
}
