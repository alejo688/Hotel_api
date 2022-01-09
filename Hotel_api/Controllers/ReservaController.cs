using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel_api.Data;
using Hotel_api.Model;

namespace Hotel_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ReservaController(ApiDbContext context)
        {
            _context = context;
        }

        // POST: api/Reserva
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservaModel>> PostReservaModel(ReservaModel reservaModel)
        {
            if (reservaModel == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return Conflict(new { message = "Datos no validos" });
            }
            else if (reservaModel.Fecha_Entrada > reservaModel.Fecha_Salida) 
            {
                return Conflict(new { message = "La fecha del checkin no puede ser mayor a la fecha de checkout" });
            }
            else
            {

                var validarReservacion = await _context.Reservas
                    .Join(_context.Habitaciones,
                        p => p.Id_Habitacion,
                        x => x.Id_Habitacion,
                        (p, x) => new { Reserva = p, Habitacion = x }
                    )
                    .Where(x => x.Reserva.Id_Habitacion == reservaModel.Id_Habitacion
                        && ((x.Reserva.Fecha_Entrada >= reservaModel.Fecha_Entrada && x.Reserva.Fecha_Entrada <= reservaModel.Fecha_Entrada)
                            || (x.Reserva.Fecha_Entrada > reservaModel.Fecha_Salida && x.Reserva.Fecha_Entrada < reservaModel.Fecha_Salida)
                            || (x.Reserva.Fecha_Salida >= reservaModel.Fecha_Entrada && x.Reserva.Fecha_Salida <= reservaModel.Fecha_Entrada)
                            || (x.Reserva.Fecha_Salida > reservaModel.Fecha_Salida && x.Reserva.Fecha_Salida < reservaModel.Fecha_Salida))
                        && x.Reserva.Estado == true)
                    .Select(x => x.Habitacion.Nombre)
                    .FirstOrDefaultAsync();

                if (validarReservacion == null)
                {
                    _context.Reservas.Add(reservaModel);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetReservaModel", new { id = reservaModel.Id_Reserva }, reservaModel);
                }
                else
                {
                    return Conflict(new { message = $"La habitación { validarReservacion } ya se encuentra reservada para las fechas {reservaModel.Fecha_Entrada} - {reservaModel.Fecha_Salida}, por favor seleccione otro rango de fechas." });
                }

                
            }
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientModel(int id)
        {
            var reservaModel = await _context.Reservas.FindAsync(id);
            if (reservaModel == null)
            {
                return NotFound();
            }

            reservaModel.Estado = false;

            _context.Reservas.Update(reservaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
