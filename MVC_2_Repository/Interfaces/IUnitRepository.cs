using MVC_2_Repository.Models;

namespace MVC_2_Repository.Interfaces
{
    public interface IUnitRepository
    {
        List<Unit> GetUnits(string sortProperty, SortOrder sortOrder);
        Unit GetUnit(int id);
        void AddUnit(Unit unit);
        void UpdateUnit(Unit unit);
        void DeleteUnit(int id);
    }
}
