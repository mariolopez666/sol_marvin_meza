using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Entity.Layer
{
    public class Matricula
    {
        public int Id { get; set; }
        [Required]
        public string DNI { get; set; }
        [Required]
        public string CodAlumno { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        public int IdCursoSeccion { get; set; }
        [Required]
        public string Tipo { get; set; }
        public int Estado { get; set; }
        public DateTime FechaReg { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
