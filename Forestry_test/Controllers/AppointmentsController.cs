using System;
using System.Collections.Generic;
using System.Linq;
using Forestry_test.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Forestry_test.ViewModels;
using Forestry_test.ViewModels.AppointmentViewModel;
using Microsoft.AspNetCore.Authorization;

namespace Forestry_test.Controllers
{
    public class AppointmentsController : Controller
    {
        private ForestryContext db;

        public AppointmentsController(ForestryContext _db)
        {
            db = _db;
        }
        [Authorize(Roles = "MainAdmin")]
        public IActionResult Index(string firstName, int page = 1, SortState sortOrder = SortState.PointIDAsc)
        {
            int pageSize = 10;
            IQueryable<Appointment> source = db.Appointments;
            if(!String.IsNullOrEmpty(firstName))
            {
                source = source.Where(p => p.PointName.Contains(firstName));
            }
            switch (sortOrder)
            {
                case SortState.PointIDDesc:
                    source = source.OrderByDescending(s => s.PointID);
                    break;
                case SortState.PointNameAsc:
                    source = source.OrderBy(s => s.PointName);
                    break;
                case SortState.PointNameDesc:
                    source = source.OrderByDescending(s => s.PointName);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            //Customs_agentsFilterViewModel customs_AgentsFilterViewModel = new Customs_agentsFilterViewModel(firstName);
            AppointmentViewModel customsAgents = new AppointmentViewModel
            {
                Appointments = items,
                PageViewModel = pageViewModel,
                SortViewModel = new AppointmentSortViewModel(sortOrder),
                FilterViewModel = new AppointmentFilterViewModel(firstName)
                
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
        public IActionResult Create(Appointment customsAgent)
        {
            db.Appointments.Add(customsAgent);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            Appointment customsAgent = db.Appointments.Find(id);
            if (customsAgent != null)
            {
                db.Appointments.Remove(customsAgent);
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
            Appointment customsAgent = db.Appointments.Find(id);
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
            Appointment customsAgent = db.Appointments.Find(id);
            if (customsAgent != null)
            {
                return View(customsAgent);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Appointment customsAgent)
        {
            db.Entry(customsAgent).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}