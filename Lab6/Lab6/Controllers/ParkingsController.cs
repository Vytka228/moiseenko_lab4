using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab6.Models;
using Lab6.ViewModels;

namespace Lab6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParkingsController : ControllerBase
    {
        private readonly BaseparkingContext db;

        public ParkingsController(BaseparkingContext applicationContext)
        {
            db = applicationContext;
        }
        // GET: api/<ParkingsController>
        [HttpGet]
        public IEnumerable<ParkingViewModel> Get()
        {
            var parkings = db.Parkings.ToList();
            List<ParkingViewModel> parkingViewModels = new List<ParkingViewModel>();
            foreach (var parking in parkings)
            {
                parkingViewModels.Add(new ParkingViewModel
                {
                    Id = parking.Id,
                    TypeParking = parking.TypeParking,
                    Datedeparture = parking.Datedeparture,
                    CarsNumber = db.Cars.Where(item => item.Id == parking.CarsId).First().Numberofthecar,
                    StaffFIO = db.Staffs.Where(item => item.Id == parking.StaffsId).First().FIOStaffs,
                    Dateentry = parking.Dateentry,
                    Price = parking.Price
                });
            }
            return parkingViewModels;
        }

        // GET api/<ParkingsController>/5
        [HttpGet("{id}")]
        public Parking Get(int id)
        {
            return db.Parkings.Where(item => item.Id == id).First();
        }

        // GET api/values
        [HttpGet("car")]
        public IEnumerable<Car> GetCars()
        {
            return db.Cars.ToList();
        }

        // GET api/values
        [HttpGet("staff")]
        public IEnumerable<Staffs> GetStaffs()
        {
            return db.Staffs.ToList();
        }

        // POST api/<ParkingsController>
        [HttpPost]
        public IActionResult Post([FromBody] Parking model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            model.Id = db.Parkings.Select(item => item.Id).Max() + 1;
            db.Parkings.Add(model);
            db.SaveChanges();
            return Ok(model);
        }

        // PUT api/<ParkingsController>/5
        [HttpPut]
        public IActionResult Put([FromBody] Parking model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            Parking parking = db.Parkings.Where(item => item.Id == model.Id).First();
            parking.Datedeparture = model.Datedeparture;
            parking.Dateentry = model.Dateentry;
            parking.CarsId = model.CarsId;
            parking.Price = model.Price;
            parking.StaffsId = model.StaffsId;
            parking.TypeParking = model.TypeParking;
            db.SaveChanges();
            return Ok(model);
        }

        // DELETE api/<ParkingsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            Parking parking = db.Parkings.Where(item => item.Id == id).First();
            db.Parkings.Remove(parking);
            db.SaveChanges();
            return Ok(id);
        }
    }
}
