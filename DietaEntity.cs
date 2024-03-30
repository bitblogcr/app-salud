using System;
using System.ComponentModel.DataAnnotations;

namespace Salud.Models
{
    public class DietaEntity
    {
        [Key]
        public int ID_RegistroDieta { get; set; }

        [Required]
        public int ID_Usuario { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaComida { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoComida { get; set; } 

        [Required]
        public string AlimentosConsumidos { get; set; }

        [Required]
        public int CaloriasComida { get; set; }

        public string Comentarios { get; set; }
    }
}
