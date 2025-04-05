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

        public IActionResult Index(string sortExpression = "")
        {
            ViewData["SortParamName"] = "name";
            ViewData["SortParamDesc"] = "description";

            ViewData["SortIconName"] = "";
            ViewData["SortIconDesc"] = "";

            SortOrder sortOrder;
            string sortProperty;

            switch (sortExpression.ToLower())
            {
                case "name_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "name";
                    ViewData["SortParamName"] = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-up";
                    break;
                case "description":
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "description";
                    ViewData["SortParamDesc"] = "description_desc";
                    ViewData["SortIconDesc"] = "fa fa-arrow-down";
                    break;
                case "description_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "description";
                    ViewData["SortParamDesc"] = "description";
                    ViewData["SortIconDesc"] = "fa fa-arrow-up";
                    break;
                default:
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "name";
                    ViewData["SortParamName"] = "name_desc";
                    ViewData["SortIconName"] = "fa fa-arrow-down";
                    break;
            }
            List<Unit> units = unitRepository.GetUnits(sortProperty, sortOrder);
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
