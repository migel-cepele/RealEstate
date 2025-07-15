using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;

namespace RealEstate.API.Infrastructure.Repositories
{
    public class ItemImageRepository : IItemImageRepository
    {
        private readonly AppDbContext _context;
        public ItemImageRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<ItemImage> GetAll() => _context.ItemImages.ToList();
        public ItemImage? GetById(long id) => _context.ItemImages.Find(id);
        public void Add(ItemImage entity)
        {
            _context.ItemImages.Add(entity);
            _context.SaveChanges();
        }
        public void Update(ItemImage entity)
        {
            _context.ItemImages.Update(entity);
            _context.SaveChanges();
        }
        public void Delete(long id)
        {
            var entity = _context.ItemImages.Find(id);
            if (entity != null)
            {
                _context.ItemImages.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}