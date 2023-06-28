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
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la habitación es obligatorio")] // Asignación de mensaje de error y dato requerido
        [StringLength(100)] // Asignación del valor limite del numero de caracteres
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado de la habitación es obligatorio")]
        public bool Estado { get; set; }
        [Required(ErrorMessage = "El Hotel es requerido")]
        public int HotelId { get; set; } 
    }
}
