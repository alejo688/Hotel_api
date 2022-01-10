using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_api.Model
{
    /**
     * Clase modelo de la entidad Reserva
     **/
    public class ReservaModel
    {
        [Key]
        public int Id_Reserva { get; set; }

        [Required(ErrorMessage = "La fecha de entrada es obligatorio")]
        [DataType(DataType.Date)] // Asignación del tipo de dato a nivel de ef
        [Column(TypeName = "datetime")] // Asignación del tipo de dato a nivel de base de datos
        public DateTime Fecha_Entrada { get; set; }

        [Required(ErrorMessage = "La fecha de salida es obligatorio")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        public DateTime Fecha_Salida { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
        public DateTime Fecha_Reserva { get; set; }

        [Required(ErrorMessage = "El estado de la reserva es obligatorio")]
        public bool Estado { get; set; }

        public int Id_Usuario { get; set; }
        public UsuarioModel UsuarioModel { get; set; }

        public int Id_Habitacion { get; set; }
        public HabitacionModel HabitacionModel { get; set; }

    }
}
