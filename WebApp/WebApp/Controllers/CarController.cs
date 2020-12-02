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
    public class CarController : Controller
    {
        // Объект контекста данных
        private readonly BaseparkingContext db;
        private IMemoryCache cache;

        public CarController(BaseparkingContext applicationContext, IMemoryCache cache)
        {
            db = applicationContext;
            this.cache = cache;
        }

        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult Index(int page = 1, string number = null, string owner = "Все")
        {
            int pageSize = 10;
            List<Owner> owners = db.Owners.ToList();
            List<CarSecondaryViewModel> carSecondaryViewModels;
            if (!cache.TryGetValue("Cars", out carSecondaryViewModels))
            {
                List<Car> cars = db.Cars.ToList();

                carSecondaryViewModels = new List<CarSecondaryViewModel>();
                foreach (var car in cars)
                {
                    carSecondaryViewModels.Add(new CarSecondaryViewModel()
                    {
                        Id = car.Id,
                        Carbrands = car.Carbrands,
                        Numberofthecar = car.Numberofthecar,
                        OwnersFIO = owners.Where(elem => elem.Id == car.OwnersId).First().Fio
                    });
                }
                cache.Set("Cars", carSecondaryViewModels, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
            }
            List<string> ownerFios = owners.Select(item => item.Fio).ToList();
            ownerFios.Add("Все");

            if (number != null)
            {
                carSecondaryViewModels = carSecondaryViewModels.Where(item => item.Numberofthecar.Contains(number)).ToList();
            }
            if (owner != "Все")
            {
                carSecondaryViewModels = carSecondaryViewModels.Where(item => item.OwnersFIO == owner).ToList();
            }

            CarIndexViewModel carView = new CarIndexViewModel()
            {
                Cars = carSecondaryViewModels.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                OwnerFIOs = ownerFios,
                PageViewModel = new PageViewModel(carSecondaryViewModels.Count, page, pageSize)
            };
            return View(carView);
        }

        [Authorize(Roles = "Администратор, Работник")]
        [HttpGet]
        public IActionResult AddCar()
        {
            CarAddViewModel carAddViewModel = new CarAddViewModel()
            {
                OwnerFIOs = db.Owners.Select(elem => elem.Fio).ToList()
            };

            return View(carAddViewModel);
        }

        [Authorize(Roles = "Администратор, Работник")]
        [HttpPost]
        public IActionResult AddCar(CarAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var id = 0;
                if (db.Cars.Count() != 0)
                {
                    id = db.Cars.Select(item => item.Id).Max();
                }
                id++;   
                db.Cars.Add(new Car()
                {
                    Id = id,
                    Carbrands = model.Carbrands,
                    Numberofthecar = model.Numberofthecar,
                    OwnersId = db.Owners.Where(elem => elem.Fio == model.OwnersFIO).First().Id
                });
                db.SaveChanges();
                cache.Remove("Cars");
                cache.Set("Cars", db.Cars.ToList(), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
                return RedirectToAction("Index", "Car");
            }
        }

        [Authorize(Roles = "Администратор, Работник")]
        [HttpGet]
        public IActionResult DeleteCar()
        {
            CarDeleteViewModel model = new CarDeleteViewModel()
            {
                IdList = db.Cars.Select(elem => elem.Id).ToList()
            };

            return View(model);
        }

        [Authorize(Roles = "Администратор, Работник")]
        [HttpPost]
        public IActionResult DeleteCar(CarDeleteViewModel model)
        {
            ViewData["Message"] = "";
            var car = db.Cars.Where(item => item.Id == model.Id).FirstOrDefault();
            db.Cars.Remove(car);
            db.SaveChanges();
            cache.Remove("Cars");
            cache.Set("Cars", db.Cars.ToList(), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
            return RedirectToAction("Index", "Car");
        }

        [Authorize(Roles = "Администратор, Работник")]
        [HttpPost]
        public IActionResult UpdateCar(CarUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var car = db.Cars.Where(item => item.Id == model.Id).FirstOrDefault();
                car.Numberofthecar = model.Numberofthecar;
                car.OwnersId = db.Owners.Where(elem => elem.Fio == model.OwnersFIO).First().Id;
                car.Carbrands = model.Carbrands;
                db.SaveChanges();
                cache.Remove("Cars");
                cache.Set("Cars", db.Cars.ToList(), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
                return RedirectToAction("Index", "Car");
            }
        }
    }
}
