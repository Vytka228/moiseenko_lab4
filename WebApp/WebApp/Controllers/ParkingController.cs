using WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace WebApp.Controllers
{
    public class ParkingController : Controller
    {
        // Объект контекста данных
        private readonly BaseparkingContext db;
        private IMemoryCache cache;

        public ParkingController(BaseparkingContext applicationContext, IMemoryCache cache)
        {
            db = applicationContext;
            this.cache = cache;
        }

        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult Index(int page = 1, string carnumber = "Все", string type = "Все")
        {
            int pageSize = 20;
            List<int> IdList = db.Parkings.Select(item => item.Id).ToList();
            
            List<Car> cars = db.Cars.ToList();
            List<ParkingSecondaryViewModel> parkingSecondaryViewModels;
            if (!cache.TryGetValue("Parkings", out parkingSecondaryViewModels))
            {
                parkingSecondaryViewModels = new List<ParkingSecondaryViewModel>();
                List<Parking> parkings = db.Parkings.ToList();
                foreach (var parking in parkings)
                {
                    parkingSecondaryViewModels.Add(new ParkingSecondaryViewModel()
                    {
                        Id = parking.Id,
                        Datedeparture = parking.Datedeparture,
                        Dateentry = parking.Dateentry,
                        CarsNumber = cars.Where(elem => elem.Id == parking.CarsId).First().Numberofthecar,
                        Price = parking.Price,
                        TypeParking = parking.TypeParking
                    });
                }
                cache.Set("Parkings", db.Parkings.ToList(), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
            }
            List<string> carsNumbers = cars.Select(item => item.Numberofthecar).ToList();
            List<string> types = parkingSecondaryViewModels.Select(item => item.TypeParking).ToList();
            carsNumbers.Add("Все");
            types.Add("Все");

            if (carnumber != "Все")
            {
                parkingSecondaryViewModels = parkingSecondaryViewModels.Where(item => item.CarsNumber == carnumber).ToList();
            }

            if (type != "Все")
            {
                parkingSecondaryViewModels = parkingSecondaryViewModels.Where(item => item.TypeParking == type).ToList();
            }

            ParkingViewModel model = new ParkingViewModel()
            {
                Parkings = parkingSecondaryViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                CarsNumbers = carsNumbers,
                TypeParkingsFiltr = types,
                PageViewModel = new PageViewModel(parkingSecondaryViewModels.Count, page, pageSize)
            };
            return View(model);
        }

        [Authorize(Roles = "Администратор, Работник")]
        [HttpGet]
        public IActionResult AddParking()
        {
            ParkingAddViewModel model = new ParkingAddViewModel()
            {
                CarsNumbers = db.Cars.Select(elem => elem.Numberofthecar).ToList()
            };

            return View(model);
        }

        [Authorize(Roles = "Администратор, Работник")]
        [HttpPost]
        public IActionResult AddParking(ParkingAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var id = 0;
                if (db.Parkings.Count() != 0)
                {
                    id = db.Parkings.Select(item => item.Id).Max();
                }
                id++;
                db.Parkings.Add(new Parking()
                {
                    Id = id,
                    Datedeparture = model.Datedeparture,
                    Dateentry = model.Dateentry,
                    CarsId = db.Cars.Where(elem => elem.Numberofthecar == model.CarsNumber).First().Id,
                    Price = model.Price,
                    StaffsId = 1,
                    TypeParking = model.TypeParking
                });
                db.SaveChanges();
                cache.Remove("Parkings");
                return RedirectToAction("Index", "Parking");
            }
        }

        [Authorize(Roles = "Администратор, Работник")]
        [HttpGet]
        public IActionResult DeleteParking()
        {
            ParkingDeleteViewModel model = new ParkingDeleteViewModel()
            {
                IdList = db.Parkings.Select(elem => elem.Id).ToList()
            };

            return View(model);
        }

        [Authorize(Roles = "Администратор, Работник")]
        [HttpPost]
        public IActionResult DeleteParking(ParkingDeleteViewModel model)
        {
            var parking = db.Parkings.Where(item => item.Id == model.Id).FirstOrDefault();
            db.Parkings.Remove(parking);
            db.SaveChanges();
            cache.Remove("Parkings");
            return RedirectToAction("Index", "Parking");
        }

        [Authorize(Roles = "Администратор, Работник")]
        [HttpPost]
        public IActionResult UpdateParking(ParkingUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var parking = db.Parkings.Where(item => item.Id == model.Id).FirstOrDefault();
                parking.Datedeparture = model.Datedeparture;
                parking.Dateentry = model.Dateentry;
                parking.CarsId = db.Cars.Where(item => item.Numberofthecar == model.CarsNumber).First().Id;
                parking.Price = model.Price;
                parking.TypeParking = model.TypeParking;
                parking.StaffsId = 1;
                db.SaveChanges();
                cache.Remove("Parkings");
                return RedirectToAction("Index", "Parking");
            }
        }
    }
}
