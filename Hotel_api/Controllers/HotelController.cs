using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly HotelApiContext _context;
        private readonly IMapper _mapper;

        // Inicialización del contexto
        public HotelController(HotelApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Hotel/1/2022-01-01/2022-01-31
        // función para traer fechas de reserva activas por hotel
        [HttpGet("{id}/{fecha_Inicio}/{Fecha_Final}")]
        public async Task<IActionResult> GetHotelModel(int id, DateTime fecha_Inicio, DateTime Fecha_Final)
        {
            // Consulta para traer las reservaciones de acuerdo a los parametros recibidos
            var ReservasHotel = await (from hotel in _context.Hoteles
                                   join habitaciones in _context.Habitaciones on hotel.Id equals habitaciones.Hotel.Id
                                   join reservas in _context.Reservas on habitaciones.Id equals reservas.Habitacion.Id
                                   join usuarios in _context.Usuarios on reservas.Usuario.Id equals usuarios.Id
                                   where hotel.Id == id 
                                   && reservas.Estado
                                   && reservas.Fecha_Entrada >= fecha_Inicio
                                   && reservas.Fecha_Entrada <= Fecha_Final
                                   select new { hotel = hotel.Nombre, 
                                       habitacion = habitaciones.Nombre, 
                                       checkin = reservas.Fecha_Entrada, 
                                       checkout = reservas.Fecha_Salida, 
                                       reservas.Fecha_Reserva,
                                       usuarios.Correo
                                   }).ToListAsync();

            // Si no se encuentra datos se envia un response notfound
            if (ReservasHotel.Count == 0 || ReservasHotel == null)
            {
                return NotFound();
            }

            // Si se encuentra datos se envia un respose 200 y el resultado encontrado
            return Ok(ReservasHotel);
        }
    }
}
