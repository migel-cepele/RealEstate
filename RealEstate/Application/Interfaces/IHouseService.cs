using RealEstate.Domain;
using RealEstate.Common;

namespace RealEstate.Application.Interfaces
{
    public interface IHouseService
    {
        List<House> GetHouses();
        OperationResult AddHouse(House house);
        House? GetHouseById(int id);
    }
}
