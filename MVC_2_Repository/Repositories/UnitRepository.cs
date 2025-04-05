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
        public List<Unit> GetUnits()
        {
            return context.Units.ToList();
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
