using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DB.Entity
{
    /**
     * Clase de la entidad Reserva
     **/
    public class Reserva
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)] // Asignación del tipo de dato a nivel de ef
        [Column(TypeName = "datetime")] // Asignación del tipo de dato a nivel de base de datos
        public DateTime Fecha_Entrada { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        public DateTime Fecha_Salida { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        public DateTime Fecha_Reserva { get; set; } = DateTime.Now;
        [Required]
        public bool Estado { get; set; } = true;

        // Asignacion de relaciones con otras entidades
        public Usuario Usuario { get; set; }
        public Habitacion Habitacion { get; set; }

    }
}
