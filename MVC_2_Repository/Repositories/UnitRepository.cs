using Microsoft.EntityFrameworkCore;
using MVC_2_Repository.Context;
using MVC_2_Repository.Interfaces;
using MVC_2_Repository.Models;

namespace MVC_2_Repository.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly InventoryDbContext context;
        public UnitRepository(InventoryDbContext _context)
        {
            context = _context;
        }
        public List<Unit> GetUnits(SortModel sortModel)
        {
            List<Unit> units = context.Units.ToList();

            if (sortModel.SortedProperty.ToLower() == "name")
            {
                if (sortModel.SortedOrder == SortOrder.Ascending)
                    units = units.OrderBy(x => x.Name).ToList();
                else
                    units = units.OrderByDescending(x => x.Name).ToList();
            }
            else
            {
                if (sortModel.SortedOrder == SortOrder.Ascending)
                    units = units.OrderBy(x => x.Description).ToList();
                else
                    units = units.OrderByDescending(x => x.Description).ToList();
            }

            return units;
        }
        public Unit GetUnit(int id)
        {
            return context.Units.Find(id);
        }
        public void AddUnit(Unit unit)
        {
            context.Units.Add(unit);
            context.SaveChanges();
        }
        public void UpdateUnit(Unit unit)
        {
            //context.Units.Update(unit);
            //context.SaveChanges();

            context.Units.Attach(unit);
            context.Entry(unit).State = EntityState.Modified;
            context.SaveChanges();
        }
        public void DeleteUnit(int id)
        {
            Unit unit = GetUnit(id);
            //context.Units.Remove(unit);
            //context.SaveChanges();

            context.Units.Attach(unit);
            context.Entry(unit).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
