using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forestry_test.Models;
using Forestry_test.ViewModels;
using Forestry_test.ViewModels.ForestViewModel;
using Forestry_test.ViewModels.ForestsViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Forestry_test.Controllers
{
    public class ForestsController : Controller
    {
        private ForestryContext db;

        public ForestsController(ForestryContext _db)
        {
            db = _db;
        }
        private ForestViewModel _duti = new ForestViewModel
        {
            //Lght = 1,  //посмотреть как для чисел
            FIO = "",
            PointName = "",
            SortD = ""
        };
        //[Authorize(Roles = "MainAdmin, user")]
        public IActionResult Index(int? agent, int? name, int? sort, int? forest, int page = 1, SortState sortOrder = SortState.DateOfAppointmentDesc)
        {
            
            int pageSize = 10;
            IQueryable<Forest> source = db.Forests.Include(d => d.FIO)
                .Include(d => d.PointName)
                .Include(d => d.SortD)
                .Include(d => d.Loc);
            // .Include(d => d.Lght.Sorte);
            if (agent != null && agent != 0)
                source = source.Where(p => p.CarID == agent);
            if (name != null && name != 0)
                source = source.Where(p => p.PointID == name);
            if (sort != null && sort != 0)
                source = source.Where(p => p.SortID == sort);
            if(forest != null && forest !=0)
                source = source.Where(p => p.ForestID == forest);
            switch (sortOrder)
            {
                case SortState.ForestIDAsc:
                    source = source.OrderBy(s => s.ForestID);
                    break;
                case SortState.ForestIDDesc:
                    source = source.OrderByDescending(s => s.ForestID);
                    break;
                case SortState.FIOAsc:
                    source = source.OrderBy(s => s.FIO.FIO);
                    break;
                case SortState.FIODesc:
                    source = source.OrderByDescending(s => s.FIO.FIO);
                    break;
                case SortState.SortDAsc:
                    source = source.OrderBy(s => s.SortD.SortD);
                    break;
                case SortState.SortDDesc:
                    source = source.OrderByDescending(s => s.SortD.SortD);
                    break;
                case SortState.PointNameAsc:
                    source = source.OrderBy(s => s.PointName.PointName);
                    break;
                case SortState.PointNameDesc:
                    source = source.OrderByDescending(s => s.PointName.PointName);
                    break;
                case SortState.QuarterAsc:
                    source = source.OrderBy(s => s.Quarter);
                    break;
                case SortState.QuarterDesc:
                    source = source.OrderByDescending(s => s.Quarter);
                    break;
                case SortState.LocAsc:
                    source = source.OrderBy(s => s.Loc.Loc);
                    break;
                case SortState.LocDesc:
                    source = source.OrderByDescending(s => s.Loc.Loc);
                    break;
                case SortState.DateOfAppointmentAsc:
                    source = source.OrderBy(s => s.DateOfAppointment);
                    break;
                case SortState.DateOfAppointmentDesc:
                    source = source.OrderByDescending(s => s.DateOfAppointment);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ForestsViewModel duti = new ForestsViewModel
            {
                Forests = items,
                ForestViewModel = _duti,
                PageViewModel = pageViewModel,
                SortViewModel = new ForestsSortViewModel(sortOrder),
                FilterViewModel = new ForestsFilterViewModel(db.Mazists.ToList(), db.Appointments.ToList(), db.Sorts.ToList(), db.Forests.ToList(), agent, name, sort, forest)
            };
            return View(duti);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var customscontext = db.Forests.Include(c => c.PointName).Include(d => d.Loc).Include(d => d.FIO).Include(d => d.SortD);
            var items = customscontext.Where(d => d.ForestID == id).ToList();
            var agents = new SelectList(db.Appointments, "PointID", "PointName", items.First().PointID);
            var goods = new SelectList(db.Mazists, "CarID", "FIO", items.First().CarID);
            var products = new SelectList(db.Sorts, "SortID", "SortD", items.First().SortID);
            var loc = new SelectList(db.Locations, "LocID", "Loc", items.First().LocID);
            ForestsViewModel duti = new ForestsViewModel
            {
                Forests = items,
                ForestViewModel = _duti,
                MazistsList = goods,
                SortsList = products,
                LocList = loc,
                AppointmentsList = agents
            };
            return View(duti);
        }
        [HttpPost]
        public IActionResult Edit(Forest dutis)
        {
            db.Forests.Update(dutis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var agents = new SelectList(db.Appointments, "PointID", "PointName");
            var goods = new SelectList(db.Mazists, "CarID", "FIO");
            var products = new SelectList(db.Sorts, "SortID", "SortD");
            var loc = new SelectList(db.Locations, "LocID", "Loc");
            ViewBag.PointID = agents;
            ViewBag.CarID = goods;
            ViewBag.SortID = products;
            ViewBag.LocID = loc;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Forest dutis)
        {
            db.Forests.Add(dutis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var customscontext = db.Forests.Include(c => c.FIO).Include(d => d.PointName).Include(d => d.Loc).Include(d => d.SortD);
            var items = customscontext.Where(d => d.ForestID == id).ToList();
            var agents = new SelectList(db.Appointments, "PointID", "PointName");
            var goods = new SelectList(db.Mazists, "CarID", "FIO");
            var products = new SelectList(db.Sorts, "SortID", "SortD");
            var loc = new SelectList(db.Locations, "LocID", "Loc");
            ForestViewModel dutiView = new ForestViewModel
            {
                ForestID = items.First().ForestID,
                FIO = items.First().FIO.FIO,
                SortD = items.First().SortD.SortD,
                PointName = items.First().PointName.PointName,
                Quarter = items.First().Quarter,
                Location = items.First().Loc.Loc,
                DateOfAppointment = items.First().DateOfAppointment
            };
            ForestsViewModel dutis = new ForestsViewModel
            {
                Forests = items,
                ForestViewModel = _duti,
                MazistsList = agents,
                SortsList = products,
                LocList = loc,
                AppointmentsList = goods
            };
            if (items == null)
                return View("NotFound");
            else
                return View(dutis);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var dutis = db.Forests.FirstOrDefault(d => d.ForestID == id);
                db.Forests.Remove(dutis);
                db.SaveChanges();
            }
            catch { }
            return RedirectToAction("index");
        }

        public IActionResult Details(int? id)
        {
            var customscontext = db.Forests.Include(c => c.FIO).Include(d => d.PointName).Include(d => d.Loc).Include(d => d.SortD);
            var items = customscontext.Where(d => d.ForestID == id).ToList();
            var agents = new SelectList(db.Appointments, "PointID", "PointName");
            var goods = new SelectList(db.Mazists, "CarID", "FIO");
            var products = new SelectList(db.Sorts, "SortID", "SortD");
            var loc = new SelectList(db.Locations, "LocID", "Loc");

            ForestViewModel dutiView = new ForestViewModel
            {
                ForestID = items.First().ForestID,
                FIO = items.First().FIO.FIO,
                SortD = items.First().SortD.SortD,
                PointName = items.First().PointName.PointName,
                Quarter = items.First().Quarter,
                Location = items.First().Loc.Loc,
                DateOfAppointment = items.First().DateOfAppointment
            };
            ForestsViewModel dutis = new ForestsViewModel
            {
                Forests = items,
                ForestViewModel = _duti,
                MazistsList = agents,
                SortsList = products,
                LocList = loc,
                AppointmentsList = goods

            };
            if (items == null)
                return View("NotFound");
            else
                return View(dutis);
        }

        [HttpPost]
        public IActionResult DeleteAll(List<int> Forestid)
        {
            try
            {
                var count = db.Forests.Count();
                for (int i = 0; i < count; i++)
                {
                    var dutis = db.Forests.FirstOrDefault(d => d.ForestID == Forestid[i]);
                    db.Forests.Remove(dutis);
                }
                db.SaveChanges();
            }
            catch { }
            return RedirectToAction("index");
        }
    }
}