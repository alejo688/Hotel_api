using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_api.Model;
using AutoMapper;
using DB;
using DB.Entity;

namespace Hotel_api.Controllers
{
    /**
     * Clase controlador de la entidad Reserva
     **/
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly HotelApiContext _context;
        private readonly IMapper _mapper;

        // Inicialización del contexto
        public ReservaController(HotelApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST: api/Reserva
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // Clase para la creación de reservas
        [HttpPost]
        public async Task<ActionResult<ReservaModel>> PostReservaModel(ReservaModel reservaModel)
        {
            // Validación del request
            if (reservaModel == null)
            {
                return BadRequest();
            }

            // Validación del modelo enviado por el request
            if (!ModelState.IsValid)
            {
                return Conflict(new { message = "Datos no validos" });
            } // Validación de las fechas de reservación
            else if (reservaModel.Fecha_Entrada > reservaModel.Fecha_Salida) 
            {
                return Conflict(new { message = "La fecha del checkin no puede ser mayor a la fecha de checkout" });
            }
            else
            {
                // validación de disponibilidad de la habitación de acuerdo a las fechas recibidas
                var validarReservacion = await _context.Reservas
                    .Join(_context.Habitaciones,
                        p => p.Id,
                        x => x.Id,
                        (p, x) => new { Reserva = p, Habitacion = x }
                    )
                    .Where(x => ((x.Reserva.Fecha_Entrada >= reservaModel.Fecha_Entrada && x.Reserva.Fecha_Entrada <= reservaModel.Fecha_Entrada)
                            || (x.Reserva.Fecha_Entrada > reservaModel.Fecha_Salida && x.Reserva.Fecha_Entrada < reservaModel.Fecha_Salida)
                            || (x.Reserva.Fecha_Salida >= reservaModel.Fecha_Entrada && x.Reserva.Fecha_Salida <= reservaModel.Fecha_Entrada)
                            || (x.Reserva.Fecha_Salida > reservaModel.Fecha_Salida && x.Reserva.Fecha_Salida < reservaModel.Fecha_Salida))
                        && x.Reserva.Estado == true)
                    .Select(x => x.Habitacion.Nombre)
                    .FirstOrDefaultAsync();

                // Si la validación es correcta se almacena en base de datos y se envia en el response el id de la reserva
                if (validarReservacion == null)
                {
                    var reserva = _mapper.Map<Reserva>(reservaModel);
                    
                    _context.Reservas.Add(reserva);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetReservaModel", new { id = reserva.Id }, reservaModel);
                }
                else
                { // si la validación no es correcta se envia mensaje de indisponibilidad de fechas
                    return Conflict(new { message = $"La habitación { validarReservacion } ya se encuentra reservada para las fechas {reservaModel.Fecha_Entrada} - {reservaModel.Fecha_Salida}, por favor seleccione otro rango de fechas." });
                }

                
            }
        }

        // DELETE: api/Reserva/5
        // Clase para la cancelación de reservas
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientModel(int id)
        {
            // Obtención de datos por medio del id suministrado
            var reservaModel = await _context.Reservas.FindAsync(id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            // Cambio del estado de la reserva de true a false
            reservaModel.Estado = false;

            // Actualización de la reserva
            _context.Reservas.Update(reservaModel);
            await _context.SaveChangesAsync();

            // Se envia repuesta al response
            return NoContent();
        }
    }
}
