using System.ComponentModel.DataAnnotations;

namespace DB.Entity
{
    /**
     * Clase de la entidad Habitación
     **/
    public class Habitacion
    {
        // Asignación de la llave primaria de la entidad
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)] // Asignación del valor limite del numero de caracteres
        public string Nombre { get; set; } = string.Empty;
        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        public bool Estado { get; set; } = true;

        // Asignacion de relaciones con otras entidades
        public Hotel Hotel { get; set; }

        public ICollection<Reserva> Reservas { get; set; } // Intancia de entidad 1 a muchos
    }
}
