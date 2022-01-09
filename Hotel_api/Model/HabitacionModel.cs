using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_api.Model
{
    public class HabitacionModel
    {
        [Key]
        public int Id_Habitacion { get; set; }

        [Required(ErrorMessage = "El nombre de la habitación es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado de la habitación es obligatorio")]
        public bool Estado { get; set; }

        public int Id_Hotel { get; set; }
        public HotelModel HotelModel { get; set; }

        public List<ReservaModel> Reservas { get; set; }
    }
}
