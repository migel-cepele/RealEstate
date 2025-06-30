using RealEstate.Application.Interfaces;
using RealEstate.Domain;
using RealEstate.Infrastructure.Repositories;
using RealEstate.Common;

namespace RealEstate.Application.Services
{
    public class HouseService : IHouseService
    {
        private readonly HouseRepository _repository;

        public HouseService(HouseRepository repository)
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
    }
}
