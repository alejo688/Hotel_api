using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_api.Model
{
    public class ReservaModel
    {
        [Key]
        public int Id_Reserva { get; set; }

        [Required(ErrorMessage = "La fecha de entrada es obligatorio")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime")]
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
