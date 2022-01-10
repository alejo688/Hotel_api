using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel_api.Model
{
    /**
     * Clase modelo de la entidad Usuario
     **/
    public class UsuarioModel
    {
        [Key]
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "Los nombres son obligatorios")]
        [StringLength(100)]
        public string Nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son obligatorios")]
        [StringLength(100)]
        public string Apellidos { get; set; }

        [Required(ErrorMessage = "El mail es obligatorio")]
        [StringLength(100)]
        public string Mail { get; set; }

        [Required(ErrorMessage = "La direccion es obligatoria")]
        [StringLength(100)]
        public string Direccion { get; set; }

        public List<ReservaModel> Reservas { get; set; }
    }
}
