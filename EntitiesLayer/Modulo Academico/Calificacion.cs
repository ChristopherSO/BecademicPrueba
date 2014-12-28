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
    public class Calificacion : IEntity
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int IdUsuario { get; set; }

        [DataMember]
        public int IdCurso { get; set; }

        [DataMember]
        public double Nota { get; set; }

        [DataMember]
        public int Periodo { get; set; }

        [DataMember]
        public int Annio { get; set; }

        [DataMember]
        public String Comentarios { get; set; }

        [DataMember]

        private Curso _curso;

        public Curso Curso
        {
            get
            {
                if (_curso == null)
                {
                    Curso = CursosRepository.Instance.GetById(this.IdCurso);
                }
                return _curso;
            }
            set { _curso = value; }
        }

        public Calificacion(int id = 0, int idUsuario = 0, int idCurso = 0, double nota = 0, int periodo = 0, int annio = 0, String comentarios = "N/A")
        {
            Id = id;
            IdCurso = idCurso;
            IdUsuario = idUsuario;
            Nota = nota;
            Periodo = periodo;
            Annio = annio;
            Comentarios = comentarios;
        }

        public bool IsValid
        {
            get { return (GetRuleViolations().Count() == 0); }
        }

        public IEnumerable<RuleViolation> GetRuleViolations()
        {
            if (Id < 0 || String.IsNullOrEmpty(Id.ToString()))
            {
                yield return new RuleViolation("El Id", "Id");
            }
            else if (IdCurso < 0 || String.IsNullOrEmpty(IdCurso.ToString()))
            {
                yield return new RuleViolation("El Id curso es requerido", "IdCurso");
            }
            else if (IdUsuario < 0 || String.IsNullOrEmpty(IdUsuario.ToString()))
            {
                yield return new RuleViolation("El Id usuario es requerido", "IdUsuario");
            }
            else if (Nota < 0 || String.IsNullOrEmpty(Nota.ToString()))
            {
                yield return new RuleViolation("La calificación es requerida", "Calificacion");
            }
            else if (Periodo < 0 || String.IsNullOrEmpty(Periodo.ToString()))
            {
                yield return new RuleViolation("El periodo es requerido", "Periodo");
            }
            else if (Annio < 0 || String.IsNullOrEmpty(Annio.ToString()))
            {
                yield return new RuleViolation("El año es requerido", "Annio");
            }


            yield break;
        }
    }
}
