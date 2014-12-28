using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLayer
{
  /**
* Autor: Jean Maradiaga
* Esta clase permite mantener un registro de la informacion de un rol.
**/

    [Serializable]
    [DataContract]
    public class RolUsuario : IEntity {

        private IEnumerable<PermisoRol> _lstPermisos;

        public RolUsuario(int pidRol = 0, String pnombre = "", String pdescripcion = "", int pintervencion = 0)
        {
            this.Id = pidRol;
            this.Nombre = pnombre;
            this.Descripcion = pdescripcion;
            this.Intervencion = pintervencion;
        }

        public RolUsuario(int pidRol = 0, String pnombre = "", String pdescripcion = "", int pintervencion = 0, String fase = "")
        {
            this.Id = pidRol;
            this.Nombre = pnombre;
            this.Descripcion = pdescripcion;
            this.Intervencion = pintervencion;
            this.NombreFase = fase;
        }

        public RolUsuario()
        {
            this.Id = 0;
            this.Nombre = "";
            this.Descripcion = "";
            this.Intervencion = 0;
        }

        //Getter nd Setter

        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String Descripcion { get; set; }

        [DataMember]
        public String NombreFase { get; set; }

        [DataMember]
        public int Intervencion { get; set; }
        
        [DataMember]
        public IEnumerable<PermisoRol> LstPermisos {

            get {
                _lstPermisos = PermisoRepositorio.Instance.GetPermisosRoles(this.Id); 
                return _lstPermisos;
            }
            set {
                _lstPermisos = value;
            }

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
            else if (Intervencion < 0)
            {
                yield return new RuleViolation("La intervención es requerida", "Intervención");
            }

            yield break;
        }

    }//Fin Clase RolUsuario

} //Ends Namespace
