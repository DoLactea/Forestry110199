using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forestry_test.Models;
using Forestry_test.ViewModels;
using Forestry_test.ViewModels.ProductViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Forestry_test.Controllers
{
    public class ProductsController : Controller
    {
        private ForestryContext db;

        public ProductsController(ForestryContext _db)
        {
            db = _db;
        }
        private ProductViewModel _product = new ProductViewModel
        {
            SortD = "",
            Location = ""
        };
        [Authorize(Roles = "MainAdmin, Master, User")]
        public IActionResult Index(int? name, int page = 1, SortState sortOrder = SortState.DateOfShipmentDesc)
        {
            int pageSize = 10;
            IQueryable<Product> source = db.Products.Include(d => d.Sorte)
                .Include(d => d.Loc);
            if (name != null && name != 0)
                source = source.Where(p => p.Sorte.SortID == name);
            switch (sortOrder)
            {
                case SortState.ProdIDAsc:
                    source = source.OrderBy(s => s.ProdID);
                    break;
                case SortState.ProdIDDesc:
                    source = source.OrderByDescending(s => s.ProdID);
                    break;
                case SortState.SortDAsc:
                    source = source.OrderBy(s => s.Sorte.SortD);
                    break;
                case SortState.SortDDesc:
                    source = source.OrderByDescending(s => s.Sorte.SortD);
                    break;
                case SortState.LghtAsc:
                    source = source.OrderBy(s => s.Lght);
                    break;
                case SortState.LghtDesc:
                    source = source.OrderByDescending(s => s.Lght);
                    break;
                case SortState.VolumeAsc:
                    source = source.OrderBy(s => s.Volume);
                    break;
                case SortState.VolumeDesc:
                    source = source.OrderByDescending(s => s.Volume);
                    break;
                case SortState.QuartersAsc:
                    source = source.OrderBy(s => s.Quarters);
                    break;
                case SortState.QuartersDesc:
                    source = source.OrderByDescending(s => s.Quarters);
                    break;
                case SortState.LocAsc:
                    source = source.OrderBy(s => s.Loc.Loc);
                    break;
                case SortState.LocDesc:
                    source = source.OrderByDescending(s => s.Loc.Loc);
                    break;
                case SortState.DateOfShipmentAsc:
                    source = source.OrderBy(s => s.DateOfShipment);
                    break;
                case SortState.DateOfShipmentDesc:
                    source = source.OrderByDescending(s => s.DateOfShipment);
                    break;
            }
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            ProductsViewModel customsWerehouse = new ProductsViewModel
            {
                Products = items,
                ProductViewModel = _product,
                PageViewModel = pageViewModel,
                SortViewModel = new ProductsSortViewModel(sortOrder),
                FilterViewModel = new ProductsFilterViewModel(db.Products.ToList(), name)
            };
            return View(customsWerehouse);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            var customscontext = db.Products.Include(c => c.Sorte).Include(d => d.Loc);
            var items = customscontext.Where(d => d.ProdID == id).ToList();
            var goods = new SelectList(db.Sorts, "SortID", "SortD", items.First().SortID);
            var loc = new SelectList(db.Locations, "LocID", "Loc", items.First().LocID);
            ProductsViewModel customsWerehouse = new ProductsViewModel
            {
                Products = items,
                ProductViewModel = _product,
                LocList = loc,
                SortsList = goods
            };
            return View(customsWerehouse);
        }
        [HttpPost]
        public IActionResult Edit(Product werehousis)
        {
            db.Products.Update(werehousis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            var goods = new SelectList(db.Sorts, "SortID", "SortD");
            var loc = new SelectList(db.Locations, "LocID", "Loc");
            ViewBag.SortID = goods;
            ViewBag.LocID = loc;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product werehousis)
        {
            db.Products.Add(werehousis);
            //db.Entry(werehousis).State = EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            var customscontext = db.Products.Include(d => d.Sorte).Include(d => d.Loc);
            var items = customscontext.Where(d => d.ProdID == id).ToList();
            var goods = new SelectList(db.Sorts, "SortID", "SortD");
            var loc = new SelectList(db.Locations, "LocID", "Loc");
            ProductViewModel werehouseView = new ProductViewModel
            {
                ProdID = items.First().ProdID,
                SortD = items.First().Sorte.SortD,
                Location = items.First().Loc.Loc,
                DateOfShipment = items.First().DateOfShipment
            };
            ProductsViewModel werehousis = new ProductsViewModel
            {
                Products = items,
                ProductViewModel = _product,
                SortsList = goods,
                LocList = loc
            };
            if (items == null)
                return View("NotFound");
            else
                return View(werehousis);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var werehousis = db.Products.FirstOrDefault(d => d.ProdID == id);
                db.Products.Remove(werehousis);
                db.SaveChanges();
            }
            catch { }
            return RedirectToAction("index");
        }

        public IActionResult Details(int? id)
        {
            var customscontext = db.Products.Include(d => d.Sorte).Include(d => d.Loc);
            var items = customscontext.Where(d => d.ProdID == id).ToList();
            var goods = new SelectList(db.Sorts, "SortID", "SortD");
            var loc = new SelectList(db.Locations, "LocID", "Loc");

            ProductViewModel werehouseView = new ProductViewModel
            {
                ProdID = items.First().ProdID,
                SortD = items.First().Sorte.SortD,
                Location = items.First().Loc.Loc,
                DateOfShipment = items.First().DateOfShipment
            };
            ProductsViewModel werehousis = new ProductsViewModel
            {
                Products = items,
                ProductViewModel = _product,
                SortsList = goods,
                LocList = loc
            };
            if (items == null)
                return View("NotFound");
            else
                return View(werehousis);
        }
    }
}