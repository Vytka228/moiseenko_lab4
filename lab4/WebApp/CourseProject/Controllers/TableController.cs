using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    // Контроллер представления страниц записей из таблиц
    public class TableController : Controller
    {
        // Объект контекста данных
        private readonly BaseparkingContext db;

        public TableController(BaseparkingContext applicationContext)
        {
            db = applicationContext;
        }

        // Метод получения страницы машин.
        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult GetCars()
        {
            List<Car> cars = db.Cars.ToList();
            List<CarViewModel> models = new List<CarViewModel>();
            foreach (var car in cars)
            {
                var fio = db.Owners.Where(elem => elem.Id == car.OwnersId).First().Fio;
                models.Add(new CarViewModel() { Id = car.Id, Carbrands = car.Carbrands, Numberofthecar = car.Numberofthecar, OwnersFIO = fio });
            }
            return View(models);
        }

        // Метод получения страницы владельцев.
        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult GetOwners()
        {
            List<Owner> owners = db.Owners.ToList();
            return View(owners);
        }

        // Метод получения страницы мебели.
        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult GetParkings()
        {
            List<Parking> parkings = db.Parkings.ToList();
            List<ParkingViewModel> models = new List<ParkingViewModel>();
            foreach (var parking in parkings)
            {
                var number = db.Cars.Where(elem => elem.Id == parking.CarsId).FirstOrDefault().Numberofthecar;
                models.Add(new ParkingViewModel() { Id = parking.Id, CarsNumber = number, Datedeparture = parking.Datedeparture, Dateentry = parking.Dateentry, Price = parking.Price, TypeParking = parking.TypeParking });
            }
            return View(models);
        }
    }
}
