using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;

namespace RealEstate.API.Application.Services
{
    public class ItemImageService
    {
        private readonly IItemImageRepository _repository;
        public ItemImageService(IItemImageRepository repository)
        {
            _repository = repository;
        }
        public List<ItemImage> GetAll() => _repository.GetAll();
        public ItemImage? GetById(long id) => _repository.GetById(id);
        public void Add(ItemImage entity) => _repository.Add(entity);
        public void Update(ItemImage entity) => _repository.Update(entity);
        public void Delete(long id) => _repository.Delete(id);
    }
}