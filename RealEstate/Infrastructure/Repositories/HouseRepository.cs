using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;
using System.Linq.Expressions;
using RealEstate.API.Application.Interfaces;

namespace RealEstate.API.Infrastructure.Repositories
{
    public class HouseRepository : IHouseRepository
    {
        private readonly AppDbContext _context;

        public HouseRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<House> GetHouses()
        {
            return _context.Houses.ToList();
        }

        public void AddHouse(House house)
        {
            _context.Houses.Add(house);
            _context.SaveChanges();
        }

        public House? GetHouseById(int id)
        {
            return _context.Houses.FirstOrDefault(h => h.Id == id);
        }

        public void UpdateHouse(House house)
        {
            _context.Houses.Update(house);
            _context.SaveChanges();
        }

        public List<House> Filter(Dictionary<string, string> keyValues)
        {
            IQueryable<House> query = _context.Houses;
            var houseType = typeof(House);

            foreach (var keyValue in keyValues)
            {
                var property = houseType.GetProperty(keyValue.Key);
                if (property == null) continue;

                //expression is used to build dynamic LINQ queries. For example here: h = > h.PropertyName == value
                var parameter = Expression.Parameter(typeof(House), "h");
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
                var lambda = Expression.Lambda<Func<House, bool>>(equal, parameter); //where eshte true ose jo
                query = query.Where(lambda);
            }

            return query.ToList();
        }
    }
}
