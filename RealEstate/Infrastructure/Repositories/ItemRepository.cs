using RealEstate.API.Application.Common;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;
using System.Linq.Expressions;

namespace RealEstate.API.Infrastructure.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _context;
        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Item> GetAll() => _context.Items.ToList();
        public Item? GetById(long id) => _context.Items.Find(id);
        public void Add(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
        }
        public void Update(Item item)
        {
            _context.Items.Update(item);
            _context.SaveChanges();
        }
        public void Delete(long id)
        {
            var item = _context.Items.Find(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }
        }

        public PaginationResult<Item> Filter(int pageNumber, int pageSize, long lastId, Dictionary<string, string> keyValues)
        {
            if (keyValues.Count > 0)
            {
                IQueryable<Item> query = _context.Items;
                var itemType = typeof(Item);

                foreach (var keyValue in keyValues)
                {
                    var property = itemType.GetProperty(keyValue.Key);
                    if (property == null) continue;

                    //expression is used to build dynamic LINQ queries. For example here: h = > h.PropertyName == value
                    var parameter = Expression.Parameter(typeof(Item), "h");
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
                    var lambda = Expression.Lambda<Func<Item, bool>>(equal, parameter); //where eshte true ose jo
                    query = query.Where(lambda);
                }

                var totalItems = query.Count();
                var nextPage = query
                    .OrderByDescending(x => x.Id)
                    .Where(x => x.Id > lastId)
                    .Take(pageSize);

                return new PaginationResult<Item>
                {
                    Results = (List<Item>)nextPage,
                    TotalCount = totalItems,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
                };
            }
            else
            {
                // If no filters are applied, return all clients with pagination
                var totalItems = _context.Items.Count();
                var nextPage = _context.Items
                    .OrderByDescending(x => x.Id)
                    .Where(x => x.Id > lastId)
                    .Take(pageSize)
                    .ToList();


                return new PaginationResult<Item>
                {
                    Results = nextPage,
                    TotalCount = totalItems,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
                };
            }
        }
    }
}