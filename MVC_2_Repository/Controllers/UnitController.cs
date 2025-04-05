using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_2_Repository.Context;
using MVC_2_Repository.Interfaces;
using MVC_2_Repository.Models;

namespace MVC_2_Repository.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitRepository unitRepository;

        public UnitController(IUnitRepository _unitRepository)
        {
            unitRepository = _unitRepository;
        }

        public IActionResult Index()
        {
            List<Unit> units = unitRepository.GetUnits();
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
                unitRepository.AddUnit(unit);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            Unit unit = unitRepository.GetUnit(id);
            return View(unit);
        }

        public IActionResult Edit(int id)
        {
            Unit unit = unitRepository.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Edit(Unit unit)
        {
            try
            {
                unitRepository.UpdateUnit(unit);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Unit unit = unitRepository.GetUnit(id);
            return View(unit);
        }

        [HttpPost]
        public IActionResult Delete(Unit unit)
        {
            try
            {
                unitRepository.DeleteUnit(unit.Id);
            }
            catch (Exception)
            {

                throw;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
