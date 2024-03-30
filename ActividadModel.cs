using System;
using System.ComponentModel.DataAnnotations;

namespace Salud.Models
{
    public class ActividadEntity
    {
        [Key] 
        public int ID_RegistroActividad { get; set; }
        public int ID_Usuario { get; set; }
        public string TipoActividad { get; set; }
        public DateTime FechaHoraActividad { get; set; }
        public int Duracion { get; set; }
        public decimal DistanciaRecorrida { get; set; }
        public int CaloriasQuemadas { get; set; }
        public string Comentarios { get; set; }
    }
}
