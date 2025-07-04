using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;
using RealEstate.API.Application.Interfaces;

namespace RealEstate.API.Infrastructure.Repositories
{
    public class ClientItemRepository : IClientItemRepository
    {
        private readonly AppDbContext _context;
        public ClientItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<ClientItem> GetAll() => _context.ClientItems.ToList();
        public ClientItem? GetById(long id) => _context.ClientItems.Find(id);

        public void Add(ClientItem clientItem)
        {
            _context.ClientItems.Add(clientItem);
            _context.SaveChanges();

        }
        public void Update(ClientItem clientItem)
        {
            _context.ClientItems.Update(clientItem);
            _context.SaveChanges();
        }
        public void Delete(long id)
        {
            var clientItem = _context.ClientItems.Find(id);
            if (clientItem != null)
            {
                _context.ClientItems.Remove(clientItem);
                _context.SaveChanges();
            }
        }

        public List<ClientItem> GetByClientId(long clientId)
        {
            return _context.ClientItems.Where(ci => ci.ClientId == clientId).ToList();
        }

        public List<ClientItem> GetByItemId(long itemId)
        {
            return _context.ClientItems.Where(ci => ci.ItemId == itemId).ToList();
        }

        public List<ClientItem> GetByStatus(string status)
        {
            return _context.ClientItems.Where(ci => ci.Status == status).ToList();
        }
    }
}