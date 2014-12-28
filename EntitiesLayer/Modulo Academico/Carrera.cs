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
    public class Carrera : IEntity
    {
        private int _idCarrera;
        [DataMember]
        public int Id
        {
            get { return _idCarrera; }
            set { _idCarrera = value; }
        }
        [DataMember]
        public String Nombre { get; set; }
        [DataMember]
        public String Descripcion { get; set; }
        [DataMember]
        public String Icono { get; set; }
        [DataMember]
        public String Color { get; set; }
        private IEnumerable<Curso> _lstCursos;
        private IEnumerable<Usuario> _lstDirectoresAcademicos;
        private IEnumerable<Usuario> _lstEstudiantes;

        public Carrera(int id = 0, String nombre = "", String descripcion = "", String icono = "", String color= "")
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Icono = icono;
            Color = color;
            _lstCursos = null;
            _lstDirectoresAcademicos = null;   
        }

        public IEnumerable<Curso> LstCursos
        {
            get {
                LstCursos = CarreraRepository.Instance.listarCursosPorCarrera(this.Id) ;
                return _lstCursos;
            }
            set { 
                _lstCursos = value;
            }
        }

        public IEnumerable<Usuario> LstDirectoresAcademicos
        {
            get
            {
                LstDirectoresAcademicos = CarreraRepository.Instance.listarDirectoresPorCarrera(this.Id);
                return _lstDirectoresAcademicos;
            }
            set
            {
                _lstDirectoresAcademicos = value;
            }
        }

        public IEnumerable<Usuario> LstEstudiantes
        {
            get
            {
                LstEstudiantes = CarreraRepository.Instance.listarEstudiantesPorCarrera(this.Id);
                return _lstEstudiantes;
            }
            set
            {
                _lstEstudiantes = value;
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
            else if (String.IsNullOrEmpty(Descripcion))
            {
                yield return new RuleViolation("La descripción es requerida", "Descripcion");
            }

            yield break;
        }

    }
}