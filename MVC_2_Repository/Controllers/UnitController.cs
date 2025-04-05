using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_2_Repository.Context;
using MVC_2_Repository.Models;

namespace MVC_2_Repository.Controllers
{
    public class UnitController : Controller
    {
        private readonly InventoryDbContext context;

        public UnitController(InventoryDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            List<Unit> units = context.Units.ToList();
            return View(units);
        }

        public IActionResult Create()
        {
            Unit unit = new();
            return View(unit);
        }

        [HttpPost]
        public IActionResult Create(Unit unit)
        {
            try
            {
                context.Units.Add(unit);
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            Unit unit = GetUnit(id);
            return View(unit);
        }

        public IActionResult Edit(int id)
        {
            Unit unit = GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            try
            {
                context.Units.Attach(unit);
                context.Entry(unit).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Unit unit = GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                context.Units.Attach(unit); // unit veritabanından yüklenmeden, doğrudan ID üzerinden silinir. amaç: veritabanından yüklenmemiş bir nesnenin, EF tarafından izlenmesini sağlamak.
                context.Entry(unit).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        private Unit GetUnit(int id)
        {
            Unit unit = context.Units.Where(x => x.Id == id).FirstOrDefault();

            return unit;
        }
    }
}
