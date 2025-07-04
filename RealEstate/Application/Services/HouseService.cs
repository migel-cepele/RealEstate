using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;
using RealEstate.API.Application.Common;

namespace RealEstate.API.Application.Services
{
    public class HouseService
    {
        private readonly IHouseRepository _repository;

        public HouseService(IHouseRepository repository)
        {
            _repository = repository;
        }

        public List<House> GetHouses()
        {
            return _repository.GetHouses();
        }

        public OperationResult AddHouse(House house)
        {
            if (!string.IsNullOrEmpty(house.Photo) && house.PhotoLocal != null)
                return OperationResult.Fail("Only one of Photo or PhotoLocal should be set.");

            try
            {
                _repository.AddHouse(house);
                return OperationResult.Ok("House added successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to add house.", ex.Message);
            }
        }

        public House? GetHouseById(int id)
        {
            return _repository.GetHouseById(id);
        }

        public List<House> Filter(Dictionary<string, string> keyValues)
        {
            return _repository.Filter(keyValues);
        }
    }
}
