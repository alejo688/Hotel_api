using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_api.Data;

namespace Hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly ApiDbContext _context;

        // Inicialización del contexto
        public HotelController(ApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Hotel/1/2022-01-01/2022-01-31
        // función para traer fechas de reserva activas por hotel
        [HttpGet("{id}/{fecha_Inicio}/{Fecha_Final}")]
        public async Task<IActionResult> GetHotelModel(int id, DateTime fecha_Inicio, DateTime Fecha_Final)
        {
            // Consulta para traer las reservaciones de acuerdo a los parametros recibidos
            var ReservasHotel = await (from hotel in _context.Hoteles
                                   join habitaciones in _context.Habitaciones on hotel.Id_Hotel equals habitaciones.Id_Hotel
                                   join reservas in _context.Reservas on habitaciones.Id_Habitacion equals reservas.Id_Habitacion
                                   join usuarios in _context.Usuarios on reservas.Id_Usuario equals usuarios.Id_Usuario
                                   where hotel.Id_Hotel == id 
                                   && reservas.Estado
                                   && reservas.Fecha_Entrada >= fecha_Inicio
                                   && reservas.Fecha_Entrada <= Fecha_Final
                                   select new { hotel = hotel.Nombre, 
                                       habitacion = habitaciones.Nombre, 
                                       checkin = reservas.Fecha_Entrada, 
                                       checkout = reservas.Fecha_Salida, 
                                       reservas.Fecha_Reserva,
                                       usuarios.Mail
                                   }).ToListAsync();

            // Si no se encuentra datos se envia un response notfound
            if (ReservasHotel.Count == 0)
            {
                return NotFound(ReservasHotel);
            }

            // Si se encuentra datos se envia un respose 200 y el resultado encontrado
            return Ok(ReservasHotel);
        }
    }
}
