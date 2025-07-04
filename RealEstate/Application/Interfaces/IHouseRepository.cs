using RealEstate.API.Domain;

namespace RealEstate.API.Application.Interfaces
{
    public interface IHouseRepository
    {
        List<House> GetHouses();
        void AddHouse(House house);
        House? GetHouseById(int id);
        List<House> Filter(Dictionary<string, string> keyValues);
    }
}
