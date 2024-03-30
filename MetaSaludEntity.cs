using System;
using System.ComponentModel.DataAnnotations;

namespace Salud.Models
{
    public class MetaSalud
    {
        
         [Key]
        public int ID_MetaSalud { get; set; }

        [Required(ErrorMessage = "El ID del usuario es requerido")]
        public int ID_Usuario { get; set; }

        [Required(ErrorMessage = "El tipo de meta es requerido")]
        [StringLength(15, ErrorMessage = "El tipo de meta debe tener como máximo 15 caracteres")]
        public string TipoMeta { get; set; }

        [Required(ErrorMessage = "El peso objetivo es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El peso objetivo debe ser mayor que cero")]
        public decimal PesoObjetivo { get; set; }

        [Required(ErrorMessage = "La fecha objetivo es requerida")]
        [DataType(DataType.Date)]
        public DateTime FechaObjetivo { get; set; }

        [Required(ErrorMessage = "El nivel de actividad física deseado es requerido")]
        [StringLength(20, ErrorMessage = "El nivel de actividad física deseado debe tener como máximo 20 caracteres")]
        public string NivelActiFisica { get; set; }

        public string ObjetivosEspecificos { get; set; }
    }
}
