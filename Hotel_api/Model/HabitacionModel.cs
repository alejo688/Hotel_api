using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_api.Model
{
    /**
     * Clase modelo de la entidad Habitación
     **/
    public class HabitacionModel
    {
        // Asignación de la llave primaria de la entidad
        [Key]
        public int Id_Habitacion { get; set; }

        [Required(ErrorMessage = "El nombre de la habitación es obligatorio")] // Asignación de mensaje de error y dato requerido
        [StringLength(100)] // Asignación del valor limite del numero de caracteres
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado de la habitación es obligatorio")]
        public bool Estado { get; set; }

        public int Id_Hotel { get; set; } // Asignación de llave foranea
        public HotelModel HotelModel { get; set; }

        public List<ReservaModel> Reservas { get; set; } // Intancia de entidad 1 a muchos
    }
}
