using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace EntitiesLayer
{
    /// <author>Jean Maradiaga</author>
    /// <summary>Esta clase permite mantener un registro de la informacion de un usuario.</summary>


    [Serializable]
    [DataContract]

    public class Usuario : IEntity
    {

        private IEnumerable<Notificacion> _lstNotificaciones;
        private IEnumerable<RolUsuario> _lstRoles;

        public Usuario(String pnombre, String papellido1, String pgenero, String pcorreo, String pcontra,
                        int pcedula, int pestado, String nombre_2 = "N/A", String papellido2 = "N/A",
                        String ptelefono = "N/A", String pnombreRol = "", String pnombreEstado = "")
        {

            this.Nombre = pnombre;
            this.SegundoNombre = nombre_2;
            this.PrimerApellido = papellido1;
            this.SegundoApellido = papellido2;
            this.Genero = pgenero;
            this.Correo = pcorreo;
            this.Password = pcontra;
            this.Cedula = pcedula;
            this.Telefono = ptelefono;
            this.Estado = pestado;
            this.NombreRol = pnombreRol;
            this.NombreEstado = pnombreEstado;

        }

        public Usuario(int _idUsuario = 0, String pnombre = "", String nombre_2 = "N/A", String papellido1 = "",
                       String papellido2 = "N/A", String pgenero = "", String pcorreo = "", int pcedula = 0,
                       String ptelefono = "N/A", String pnombreEstado = "", int pidEstado = 0)
        {

            this.Id = _idUsuario;
            this.Nombre = pnombre;
            this.SegundoNombre = nombre_2;
            this.PrimerApellido = papellido1;
            this.SegundoApellido = papellido2;
            this.Genero = pgenero;
            this.Correo = pcorreo;
            this.Cedula = pcedula;
            this.Telefono = ptelefono;
            this.NombreEstado = pnombreEstado;
            this.Estado = pidEstado;


        }

        public Usuario()
        {
            this.Nombre = "";
            this.PrimerApellido = "";
            this.SegundoApellido = "";
            this.Genero = "";
            this.Correo = "";
            this.Cedula = 0;
            this.Telefono = "";
            //      Rol = 0;
            this.NombreRol = "";
            //       Estado = 0;
            this.NombreEstado = "";

        }

        //Getter nd Setters

        [DataMember]

        public int Id { get; set; }

        [DataMember]
        public String Nombre { get; set; }

        [DataMember]
        public String SegundoNombre { get; set; }

        [DataMember]
        public String PrimerApellido { get; set; }

        [DataMember]
        public String SegundoApellido { get; set; }

        [DataMember]
        public String Genero { get; set; }

        [DataMember]
        public String Correo { get; set; }

        [DataMember]
        public String Password { get; set; }

        [DataMember]
        public int Cedula { get; set; }

        [DataMember]
        public String Telefono { get; set; }

        [DataMember]
        public int Rol { get; set; }

        [DataMember]
        public int Estado { get; set; }

        [DataMember]
        public String NombreRol { get; set; }

        [DataMember]
        public String NombreEstado { get; set; }

        
        public IEnumerable<Notificacion> LstNotificaciones
        {
            get
            {
                _lstNotificaciones = NotificacionRepository.Instance.ListarNoVistas(this.Id);
                return _lstNotificaciones;
            }
            set
            {
                _lstNotificaciones = value;
            }
        }

        [DataMember]
        public IEnumerable<RolUsuario> LstRoles
        {
            get {
                _lstRoles = RolUsuarioRepository.Instance.GetRolesUsuario(this.Id);
                return _lstRoles;
            }
            set {
                _lstRoles = value;
            }
        }

        /// <summary>
        /// Metodo que crea una conrasena al azar para un nuevo usuario o para modificar la antigua.
        /// </summary>
        /// <param name="PasswordLength">Longitud de la nueva contrasena</param>
        /// <returns></returns>

        public string randomPass(int PasswordLength)
        {
            string _allowedChars = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ123456789!@$?";
            Byte[] randomBytes = new Byte[PasswordLength];
            char[] chars = new char[PasswordLength];
            int allowedCharCount = _allowedChars.Length;

            for (int i = 0; i < PasswordLength; i++)
            {
                Random randomObj = new Random();
                randomObj.NextBytes(randomBytes);
                chars[i] = _allowedChars[(int)randomBytes[i] % allowedCharCount];
            }

            return new string(chars);
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
            else if (String.IsNullOrEmpty(PrimerApellido))
            {
                yield return new RuleViolation("El primer apellido es requerido", "Apellido");
            }
            else if (String.IsNullOrEmpty(Correo))
            {
                yield return new RuleViolation("Debe de proporcionar un correo", "Correo");
            }
            else if (Cedula < 0)
            {
                yield return new RuleViolation("La cedula es requerida", "Cedula");
            }

            yield break;
        }



    }//Fin Clase Usuario

} //Ends Namespace