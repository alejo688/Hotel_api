using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_api.Model
{
    /**
     * Clase modelo de la entidad Hotel
     **/
    public class HotelModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del hotel es obligatorio")]
        [StringLength(150)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre del pais es obligatorio")]
        [StringLength(100)]
        public string Pais { get; set; }

        [Required(ErrorMessage = "La latitud del hotel es obligatoria")]
        [StringLength(20)]
        public string Latitud { get; set; }

        [Required(ErrorMessage = "La longitud del hotel es obligatoria")]
        [StringLength(20)]
        public string Longitud { get; set; }

        [StringLength(150)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado del hotel es obligatorio")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "La cantidad de habitaciones del hotel es obligatoria")]
        [Range(1,999)] // Asignación de rango
        public int Cantidad_Habitaciones { get; set; }
    }
}
