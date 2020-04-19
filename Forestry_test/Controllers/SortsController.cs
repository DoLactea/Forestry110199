using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forestry_test.Models;
using Microsoft.EntityFrameworkCore;
using Forestry_test.ViewModels;
using Forestry_test.ViewModels.SortViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Forestry_test.Controllers
{
    public class SortsController : Controller
    {
        private ForestryContext db;

        public SortsController(ForestryContext _db)
        {
            db = _db;
        }
        [Authorize(Roles = "MainAdmin")]
        public IActionResult Index(string SortD, int page = 1, SortState sortOrder = SortState.SortIDAsc)
        {
            int pageSize = 10;
            IQueryable<Sort> source = db.Sorts;
            if(!String.IsNullOrEmpty(SortD))
            {
                source = source.Where(p => p.SortD.Contains(SortD));
            }
            switch (sortOrder)
            {
                case SortState.SortIDDesc:
                    source = source.OrderByDescending(s => s.SortID);
                    break;
                case SortState.SortDAsc:
                    source = source.OrderBy(s => s.SortD);
                    break;
                case SortState.SortDDesc:
                    source = source.OrderByDescending(s => s.SortD);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            SortViewModel ToGS = new SortViewModel
            {
                Sorts = items,
                PageViewModel = pageViewModel,
                SortedViewModel = new SortSortedViewModel(sortOrder),
                FilterViewModel = new SortFilterViewModel(SortD)
            };
            return View(ToGS);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sort tog)
        {
            db.Sorts.Add(tog);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Sort tog = db.Sorts.Find(id);
            if (tog != null)
            {
                db.Sorts.Remove(tog);
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
            Sort tog = db.Sorts.Find(id);
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
            Sort tog = db.Sorts.Find(id);
            if (tog != null)
            {
                return View(tog);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Sort tog)
        {
            db.Entry(tog).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}