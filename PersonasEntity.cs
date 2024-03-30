using System;

namespace Salud.Models
{
    public class PersonasEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreCompleto { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
        public DateTime? FechaNacimiento { get; set; } //   DateTime? para permitir valores nulos
        public decimal? Altura { get; set; } //  decimal? para permitir valores nulos
        public decimal? PesoActual { get; set; } //  decimal? para permitir valores nulos
        public string Genero { get; set; } 
        public byte[] FotoPerfil { get; set; }
    }
}
