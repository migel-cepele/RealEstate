using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Application.Common;
using RealEstate.API.Application.Common.Constants;

namespace RealEstate.API.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;
        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Client> GetAll() => _context.Clients.ToList();
        public Client? GetById(long id) => _context.Clients.Find(id);
        public void Add(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }
        public void Update(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
        }
        public void Delete(long id)
        {
            var client = _context.Clients.Find(id);
            if (client != null)
            {
                _context.Clients.Remove(client);
                _context.SaveChanges();
            }
        }

        public PaginationResult<Client> Filter(int pageNumber, int pageSize, Dictionary<string, string> keyValues)
        {
            throw new NotImplementedException();
        }

        public void UpdateClientPriority(ClientItem clientItem, List<Client> allClients)
        {
            // Update the priority amount for the target client duke marre parasysh shumen e veprimit te fundit
            // te kryer nga klienti.
            var targetClient = allClients.FirstOrDefault(c => c.Id == clientItem.ClientId);
            if (targetClient != null)
            {
                if (clientItem.Status == SaleType.ForSale)
                {
                    targetClient.PriorityAmount += clientItem.Price * Priority.Sold;
                }
                else if (clientItem.Status == SaleType.ForRent)
                {
                    targetClient.PriorityAmount += clientItem.Price * Priority.Rented;
                }
            }

            // Sort all clients by PriorityAmount descending
            var sortedClients = allClients.OrderByDescending(c => c.PriorityAmount ?? 0).ToList();

            // Assign PriorityNo based on sorted order
            for (int i = 0; i < sortedClients.Count; i++)
            {
                sortedClients[i].PriorityNo = i + 1;
            }

            _context.Clients.UpdateRange(sortedClients);
            _context.SaveChanges();
        }
    }
}