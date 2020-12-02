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
    public class OwnerController : Controller
    {
        // Объект контекста данных
        private readonly BaseparkingContext db;
        private IMemoryCache cache;

        public OwnerController(BaseparkingContext applicationContext, IMemoryCache cache)
        {
            db = applicationContext;
            this.cache = cache;
        }

        [ResponseCache(CacheProfileName = "Cache")]
        public IActionResult Index(int page = 1, string fone = null)
        {
            int pageSize = 20;
            List<Owner> owners;
            if (!cache.TryGetValue("Owners", out owners))
            {
                owners = db.Owners.ToList();
                cache.Set("Owners", db.Owners.ToList(), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
            }
            List<int> IdList = owners.Select(item => item.Id).ToList();

            if (fone != null)
            {
                owners = owners.Where(item => item.NameFone.Contains(fone)).ToList();
            }


            OwnerViewModel ownerViewModel = new OwnerViewModel()
            {
                Owners = owners.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageViewModel = new PageViewModel(owners.Count, page, pageSize)
            };

            return View(ownerViewModel);
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet]
        public IActionResult AddOwner()
        {
            OwnerAddViewModel model = new OwnerAddViewModel();
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost]
        public IActionResult AddOwner(OwnerAddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var id = 0;
                if (db.Owners.Count() != 0)
                {
                    id = db.Owners.Select(item => item.Id).Max();
                }
                id++;
                db.Owners.Add(new Owner() { Id = id, Fio = model.Fio, NameFone = model.NameFone });
                db.SaveChanges();
                cache.Remove("Owners");
                cache.Set("Owners", db.Owners.ToList(), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
                return RedirectToAction("Index", "Owner");
            }
        }
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        public IActionResult DeleteOwner()
        {
            OwnerDeleteViewModel model = new OwnerDeleteViewModel()
            {
                IdList = db.Owners.Select(elem => elem.Id).ToList()
            };

            return View(model);
        }


        [Authorize(Roles = "Администратор")]
        [HttpPost]
        public IActionResult DeleteOwner(OwnerDeleteViewModel model)
        {
            var owner = db.Owners.Where(item => item.Id == model.Id).FirstOrDefault();
            db.Owners.Remove(owner);
            db.SaveChanges();
            cache.Remove("Owners");
            cache.Set("Owners", db.Owners.ToList(), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
            return RedirectToAction("Index", "Owner");
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet]
        public IActionResult UpdateOwner()
        {
            OwnerUpdateViewModel model = new OwnerUpdateViewModel()
            {
                IdList = db.Owners.Select(elem => elem.Id).ToList()
            };

            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost]
        public IActionResult UpdateOwner(OwnerUpdateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var owner = db.Owners.Where(item => item.Id == model.Id).FirstOrDefault();
                owner.Fio = model.Fio;
                owner.NameFone = model.NameFone;
                db.SaveChanges();
                cache.Remove("Owners");
                cache.Set("Owners", db.Owners.ToList(), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(10)));
                return RedirectToAction("Index", "Owner");
            }
        }
    }
}
