using Hotel_api.Controllers;
using Hotel_api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Xunit;

namespace TestHotelApiXunit
{
    public class HotelShould
    {
        /**
         * Constructor de la clase de pruebas unitarias
         **/
        public HotelShould()
        {
            InitConfiguration(); // Inicialización configuración
            InitContext(); // Inicialización del contexto
        }

        private ApiDbContext _hotelContext;
        private IConfiguration _config;

        /**
         * Función internal para traer los datos de configuración 
         * a partir del archivo appsettings.json de la aplicación
         **/
        internal void InitConfiguration()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        /**
         * Función para la creación del contexto de entity framework
         * para enviar al constructor de la clase que se va a probar
         **/
        internal void InitContext()
        {
            // Se trae la cadena de conexión y se conecta a la base de datos de sql server
            var builder = new DbContextOptionsBuilder<ApiDbContext>()
                .UseSqlServer(_config.GetConnectionString("DefaultConnection"));

            // Se genera el contexto para realizar las pruebas
            _hotelContext = new ApiDbContext(builder.Options);
        }

        /**
         * Función para realizar la validación de la lista de reservas cuando se encuentran resultados
         **/

        [Fact]
        public async Task ValidateGetHotelModel()
        {
            var controller = new HotelController(_hotelContext); // Se instancia la clase a probar

            // Asignación de variables para el caso de prueba
            int IdHotel = 1;
            DateTime fecha_inicio = DateTime.Parse("2022-01-01");
            DateTime fecha_final = DateTime.Parse("2022-01-30");

            // Ejecución del metodo de la clase a probar
            var actionResult = await controller.GetHotelModel(IdHotel, fecha_inicio, fecha_final);
            // Extracción del resultado
            OkObjectResult okResult = actionResult as OkObjectResult;

            // Evaluación del resultado
            Assert.Equal(200, okResult.StatusCode);
        }

        /**
         * Función para realizar la validación de la lista de reservas cuando no se encuentran resultados
         **/

        [Fact]
        public async Task ValidateFailGetHotelModel()
        {
            var controller = new HotelController(_hotelContext);

            int IdHotel = 100;
            DateTime fecha_inicio = DateTime.Parse("2021-01-01");
            DateTime fecha_final = DateTime.Parse("2021-01-30");

            var actionResult = await controller.GetHotelModel(IdHotel, fecha_inicio, fecha_final);
            NotFoundObjectResult notFoundResult = actionResult as NotFoundObjectResult;

            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}
