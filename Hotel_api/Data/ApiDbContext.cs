using Hotel_api.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hotel_api.Data
{
    /**
     * Clase contexto de la solucion
     **/
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        // Asignación de modelos que van a pasar a ser tablas
        public DbSet<HotelModel> Hoteles { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<HabitacionModel> Habitaciones { get; set; }
        public DbSet<ReservaModel> Reservas { get; set; }

        /**
         *  Función para configuración e insercción de datos
         **/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Asignación de llave primaria
            modelBuilder.Entity<HotelModel>()
                .ToTable("Hoteles")
                .HasKey(b => b.Id_Hotel);

            // Generación de datos de pruebas para la entidad
            modelBuilder.Entity<HotelModel>()
                .HasData(
                    new { Id_Hotel = 1, Nombre = "Hotel Bogotá", Pais = "Colombia", Latitud = "4.640845", Longitud = "-74.098481", Descripcion = "Hermoso hotel ubicado en la ciudad de bogotá", Estado = true, Cantidad_Habitaciones = 5 },
                    new { Id_Hotel = 2, Nombre = "Hotel Madrid", Pais = "España", Latitud = "40.405885", Longitud = "-3.674803", Descripcion = "Hermoso hotel ubicado en la ciudad de madrid", Estado = true, Cantidad_Habitaciones = 5 }
                );

            modelBuilder.Entity<UsuarioModel>()
                .ToTable("Usuarios")
                .HasKey(b => b.Id_Usuario);

            modelBuilder.Entity<UsuarioModel>()
                .HasData(
                    new { Id_Usuario = 1, Nombres = "Luis", Apellidos = "Perez", Mail = "luis.perez@tudominio.com", Direccion = "Calle 123" },
                    new { Id_Usuario = 2, Nombres = "Juan", Apellidos = "Perez", Mail = "juan.perez@tudominio.com", Direccion = "Calle 456" },
                    new { Id_Usuario = 3, Nombres = "Maria", Apellidos = "Perez", Mail = "maria.perez@tudominio.com", Direccion = "Calle 789" },
                    new { Id_Usuario = 4, Nombres = "Monica", Apellidos = "Perez", Mail = "monica.perez@tudominio.com", Direccion = "Calle 987" },
                    new { Id_Usuario = 5, Nombres = "Luisa", Apellidos = "Perez", Mail = "luisa.perez@tudominio.com", Direccion = "Calle 654" },
                    new { Id_Usuario = 6, Nombres = "Pedro", Apellidos = "Perez", Mail = "pedro.perez@tudominio.com", Direccion = "Calle 321" }
                );

            modelBuilder.Entity<HabitacionModel>()
                .ToTable("Habitaciones")
                .HasKey(b => b.Id_Habitacion);

            // Asignación de tipo de relación entre entidades
            modelBuilder.Entity<HabitacionModel>()
                .HasOne(p => p.HotelModel)
                .WithMany(b => b.Habitaciones)
                .HasForeignKey(p => p.Id_Hotel);

            modelBuilder.Entity<HabitacionModel>()
                .HasData(
                    new { Id_Habitacion = 1, Nombre = "Habitación 101", Descripcion = "Habitación sencilla", Estado = true, Id_Hotel = 1 },
                    new { Id_Habitacion = 2, Nombre = "Habitación 102", Descripcion = "Habitación sencilla", Estado = true, Id_Hotel = 1 },
                    new { Id_Habitacion = 3, Nombre = "Habitación 201", Descripcion = "Habitación doble", Estado = true, Id_Hotel = 1 },
                    new { Id_Habitacion = 4, Nombre = "Habitación 202", Descripcion = "Habitación doble", Estado = true, Id_Hotel = 1 },
                    new { Id_Habitacion = 5, Nombre = "Habitación 301", Descripcion = "Habitación vip", Estado = true, Id_Hotel = 1 },
                    new { Id_Habitacion = 6, Nombre = "Habitación 101", Descripcion = "Habitación sencilla", Estado = true, Id_Hotel = 2 },
                    new { Id_Habitacion = 7, Nombre = "Habitación 102", Descripcion = "Habitación sencilla", Estado = true, Id_Hotel = 2 },
                    new { Id_Habitacion = 8, Nombre = "Habitación 201", Descripcion = "Habitación doble", Estado = true, Id_Hotel = 2 },
                    new { Id_Habitacion = 9, Nombre = "Habitación 202", Descripcion = "Habitación doble", Estado = true, Id_Hotel = 2 },
                    new { Id_Habitacion = 10, Nombre = "Habitación 301", Descripcion = "Habitación vip", Estado = true, Id_Hotel = 2 }
                );

            modelBuilder.Entity<ReservaModel>()
                .ToTable("Reservas")
                .HasKey(b => b.Id_Reserva);

            modelBuilder.Entity<ReservaModel>()
                .HasOne(p => p.HabitacionModel)
                .WithMany(b => b.Reservas)
                .HasForeignKey(p => p.Id_Habitacion);

            modelBuilder.Entity<ReservaModel>()
                .HasOne(p => p.UsuarioModel)
                .WithMany(b => b.Reservas)
                .HasForeignKey(p => p.Id_Usuario);

            // Asignación de datos por defecto a columna Fecha_reserva
            modelBuilder.Entity<ReservaModel>()
                .Property(b => b.Fecha_Reserva)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<ReservaModel>()
                .HasData(
                    new { Id_Reserva = 1, Fecha_Entrada = DateTime.Parse("2022-01-06"), Fecha_Salida = DateTime.Parse("2022-01-11"), Fecha_Reserva = DateTime.Parse("2021-10-10"), Estado = true, Id_Usuario = 1, Id_Habitacion = 1 },
                    new { Id_Reserva = 2, Fecha_Entrada = DateTime.Parse("2022-01-06"), Fecha_Salida = DateTime.Parse("2022-01-11"), Fecha_Reserva = DateTime.Parse("2021-10-10"), Estado = true, Id_Usuario = 5, Id_Habitacion = 10 }
                );
        }
    }
}
