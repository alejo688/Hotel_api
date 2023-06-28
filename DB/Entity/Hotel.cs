using System.ComponentModel.DataAnnotations;

namespace DB.Entity
{
    /**
     * Clase de la entidad Hotel
     **/
    public class Hotel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Pais { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Latitud { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Longitud { get; set; } = string.Empty;

        [StringLength(150)]
        public string Descripcion { get; set; } = string.Empty;

        [Required]
        public bool Estado { get; set; } = true;

        [Required]
        [Range(1,999)] // Asignación de rango
        public int Cantidad_Habitaciones { get; set; }

        public ICollection<Habitacion> Habitaciones { get; set; }
    }
}
