using RealEstate.API.Application.Common;
using RealEstate.API.Domain;

namespace RealEstate.API.Application.Interfaces
{
    public interface IItemRepository : IBaseInterface<Item>
    {
        PaginationResult<Item> Filter(int pageNumber, int pageSize, Dictionary<string, string> keyValues);
    }
}