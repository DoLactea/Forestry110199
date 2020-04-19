using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forestry_test.Models;
using Microsoft.EntityFrameworkCore;
using Forestry_test.ViewModels;
using Forestry_test.ViewModels.LocationViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Forestry_test.Controllers
{
    public class LocationsController : Controller
    {
        private ForestryContext db;

        public LocationsController(ForestryContext _db)
        {
            db = _db;
        }
         [Authorize(Roles = "MainAdmin")]
        public IActionResult Index(string Loc, int page = 1, SortState sortOrder = SortState.LocIDAsc)
        {
            int pageSize = 10;
            IQueryable<Location> source = db.Locations;
            if (!String.IsNullOrEmpty(Loc))
            {
                source = source.Where(p => p.Loc.Contains(Loc));
            }
            switch (sortOrder)
            {
                case SortState.LocIDDesc:
                    source = source.OrderByDescending(s => s.LocID);
                    break;
                case SortState.LocAsc:
                    source = source.OrderBy(s => s.Loc);
                    break;
                case SortState.LocDesc:
                    source = source.OrderByDescending(s => s.Loc);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            LocationViewModel ToGS = new LocationViewModel
            {
                Locations = items,
                PageViewModel = pageViewModel,
                SortViewModel = new LocationSortViewModel(sortOrder),
                FilterViewModel = new LocationFilterViewModel(Loc)
            };
            return View(ToGS);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Location tog)
        {
            db.Locations.Add(tog);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Location tog = db.Locations.Find(id);
            if (tog != null)
            {
                db.Locations.Remove(tog);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Location tog = db.Locations.Find(id);
            if (tog != null)
            {
                return View(tog);
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Location tog = db.Locations.Find(id);
            if (tog != null)
            {
                return View(tog);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Location tog)
        {
            db.Entry(tog).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}