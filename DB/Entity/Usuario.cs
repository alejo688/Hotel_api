using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DB.Entity
{
    /**
     * Clase modelo de la entidad Usuario
     **/
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Direccion { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Telefono { get; set; } = string.Empty;

        public ICollection<Reserva> Reservas { get; set; }
    }
}
