using System;
using System.Collections.Generic;
using System.Linq;
using Forestry_test.Models;
using Forestry_test.ViewModels;
using Forestry_test.ViewModels.MazistViewModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Forestry_test.Controllers
{
    public class MazistsController : Controller
    {
        private ForestryContext db;

        public MazistsController(ForestryContext _db)
        {
            db = _db;
        }
         [Authorize(Roles = "MainAdmin")]
        public IActionResult Index(string firstName, int page = 1, SortState sortOrder = SortState.CarIDAsc)
        {
            int pageSize = 10;
            IQueryable<Mazist> source = db.Mazists;
            if (!String.IsNullOrEmpty(firstName))
            {
                source = source.Where(p => p.FIO.Contains(firstName));
            }
            switch (sortOrder)
            {
                case SortState.CarIDDesc:
                    source = source.OrderByDescending(s => s.CarID);
                    break;
                case SortState.FIOAsc:
                    source = source.OrderBy(s => s.FIO);
                    break;
                case SortState.FIODesc:
                    source = source.OrderByDescending(s => s.FIO);
                    break;
                case SortState.CarNumberAsc:
                    source = source.OrderBy(s => s.CarNumber);
                    break;
                case SortState.CarNumberDesc:
                    source = source.OrderByDescending(s => s.CarNumber);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            //Customs_agentsFilterViewModel customs_AgentsFilterViewModel = new Customs_agentsFilterViewModel(firstName);
            MazistViewModel customsAgents = new MazistViewModel
            {
                Mazists = items,
                PageViewModel = pageViewModel,
                SortViewModel = new MazistSortViewModel(sortOrder),
                FilterViewModel = new MazistFilterViewModel(firstName)

            };
            //var customsAgents = db.Customs_agents.ToList();
            return View(customsAgents);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Mazist customsAgent)
        {
            db.Mazists.Add(customsAgent);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Mazist customsAgent = db.Mazists.Find(id);
            if (customsAgent != null)
            {
                db.Mazists.Remove(customsAgent);
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
            Mazist customsAgent = db.Mazists.Find(id);
            if (customsAgent != null)
            {
                return View(customsAgent);
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
            Mazist customsAgent = db.Mazists.Find(id);
            if (customsAgent != null)
            {
                return View(customsAgent);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Mazist customsAgent)
        {
            db.Entry(customsAgent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}