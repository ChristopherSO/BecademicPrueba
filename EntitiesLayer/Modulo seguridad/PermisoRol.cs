using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EntitiesLayer
{
    /**
  * Autor: Jean Maradiaga
  * Esta clase permite mantener un registro de la informacion de un rol.
  **/

    [Serializable]
    [DataContract]
    public class PermisoRol : IEntity
    {
        private int _idPermiso;
        private String nombre;
        private String descripcion;
        private String categoria;

        public PermisoRol(int pidPermiso = 0, String pnombre = "", String pdescripcion = "", String categoria = "")
        {
            Id = pidPermiso;
            Nombre = pnombre;
            Descripcion = pdescripcion;
            Categoria = categoria;
        }

        public PermisoRol()
        {
            Id = 0;
            Nombre = "";
            Descripcion = "";
            Categoria = "";
        }

        //Getter nd Setter
        [DataMember]
        public int Id
        {
            get { return _idPermiso; }
            set { _idPermiso = value; }
        }

        [DataMember]
        public String Nombre
        {

            get { return nombre; }
            set { nombre = value; }
        }

        [DataMember]
        public String Descripcion
        {

            get { return descripcion; }
            set { descripcion = value; }
        }

        [DataMember]
        public String Categoria
        {

            get { return categoria; }
            set { categoria = value; }
        }

        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (String.IsNullOrEmpty(Nombre))
            {
                yield return new RuleViolation("El nombre es requerido", "Nombre");
            }
            else if (String.IsNullOrEmpty(Categoria))
            {
                yield return new RuleViolation("La categoria es requerida", "Intervención");
            }

            yield break;
        }

    }//Fin Clase RolUsuario

} //Ends Namespace
