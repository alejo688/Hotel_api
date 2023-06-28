using DB.Entity;
using Microsoft.EntityFrameworkCore;

namespace DB
{
    public class HotelApiContext : DbContext
    {

        public HotelApiContext()
        {
        }

        public HotelApiContext(DbContextOptions<HotelApiContext> options) 
            : base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer("Server=ALEJO688;Database=HotelApi;User Id=alejo688;Password=Alejo900330;TrustServerCertificate=True;Trusted_Connection=true;MultipleActiveResultSets=true");
            }
        }

        // Asignación de modelos que van a pasar a ser tablas
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Habitacion> Habitaciones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}