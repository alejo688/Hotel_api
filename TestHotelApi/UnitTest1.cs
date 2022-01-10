using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Hotel_api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Hotel_api.Data;

namespace TestHotelApi
{
    [TestClass]
    public class UnitTest1
    {
        private ApiDbContext _context;

        [TestMethod]
        public async Task TestHotelReservacion()
        {
            _context = "";

            int id_hotel = 1;
            DateTime fecha_inicio = DateTime.Parse("2022-01-01");
            DateTime fecha_final = DateTime.Parse("2022-01-30");

            var controller = new HotelController(_context);
            var actionResult = await controller.GetHotelModel(id_hotel, fecha_inicio, fecha_final);

            OkObjectResult okResult = actionResult as OkObjectResult;

            Assert.AreEqual(200, okResult.StatusCode);
        }

        /*[TestMethod]
        public async Task TestHotelReservacionNotFound()
        {
            int id_hotel = 100;
            DateTime fecha_inicio = DateTime.Parse("2021-01-01");
            DateTime fecha_final = DateTime.Parse("2021-01-30");

            var HotelController = new HotelController();
            IActionResult actionResult = await HotelController.GetHotelModel(id_hotel, fecha_inicio, fecha_final);

            NotFoundResult result = actionResult as NotFoundResult;

            Assert.AreEqual(NotFoundResult, result.StatusCode);
        }*/
    }
}
