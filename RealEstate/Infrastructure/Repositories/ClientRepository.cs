using RealEstate.API.Application.Common;
using RealEstate.API.Application.Common.Constants;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;
using System.Linq.Expressions;

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

        public PaginationResult<Client> Filter(int pageNumber, int pageSize, long lastId, Dictionary<string, string> keyValues)
        {
            if(keyValues.Count > 0)
            {
                IQueryable<Client> query = _context.Clients;
                var clientType = typeof(Client);

                foreach (var keyValue in keyValues)
                {
                    var property = clientType.GetProperty(keyValue.Key);
                    if (property == null) continue;

                    //expression is used to build dynamic LINQ queries. For example here: h = > h.PropertyName == value
                    var parameter = Expression.Parameter(typeof(Client), "h");
                    var propertyAccess = Expression.Property(parameter, property);

                    // vlera ne dictionary eshte gjithmone string, pavarsisht nese type i property mund te jete ndryshe
                    // ketu behet konvertimi i type nga string ne ate qe duhet
                    object? typedValue = null;
                    try
                    {
                        if (property.PropertyType == typeof(byte[]))
                        {
                            continue;
                        }
                        else if (property.PropertyType == typeof(bool))
                        {
                            typedValue = bool.Parse(keyValue.Value);
                        }
                        else if (property.PropertyType.IsEnum)
                        {
                            typedValue = Enum.Parse(property.PropertyType, keyValue.Value);
                        }
                        else
                        {
                            typedValue = Convert.ChangeType(keyValue.Value, property.PropertyType);
                        }
                    }
                    catch
                    {
                        continue;
                    }

                    var constant = Expression.Constant(typedValue, property.PropertyType);
                    var equal = Expression.Equal(propertyAccess, constant);
                    var lambda = Expression.Lambda<Func<Client, bool>>(equal, parameter); //where eshte true ose jo
                    query = query.Where(lambda);
                }

                var totalItems = query.Count();
                var nextPage = query
                    .OrderByDescending(x => x.Id)
                    .Where(x => x.Id > lastId)
                    .Take(pageSize);

                 return new PaginationResult<Client>
                 {
                    Results = (List<Client>)nextPage,
                    TotalCount = totalItems,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
                 };
            }
            else
            {
                // If no filters are applied, return all clients with pagination
                var totalItems = _context.Clients.Count();
                var nextPage = _context.Clients
                    .OrderByDescending(x => x.Id)
                    .Where(x => x.Id > lastId)
                    .Take(pageSize)
                    .ToList();
                

                return new PaginationResult<Client>
                {
                    Results = nextPage,
                    TotalCount = totalItems,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
                };
            }
            
        }

        public void UpdateClientPriority(ClientItem clientItem, List<Client> allClients)
        {
            // Update the priority amount for the target client duke marre parasysh shumen e veprimit te fundit
            // te kryer nga klienti.
            var targetClient = allClients.FirstOrDefault(c => c.Id == clientItem.ClientId);
            
            if (targetClient != null)
            {
                decimal cpa = targetClient.PriorityAmount ?? 0;

                if (clientItem.Status == ItemStatus.Sold)
                {
                    cpa += clientItem.Price * Priority.Sold;
                }
                else if (clientItem.Status == ItemStatus.Rented)
                {
                    cpa += clientItem.Price * Priority.Rented;
                }
                targetClient.PriorityAmount = cpa;
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