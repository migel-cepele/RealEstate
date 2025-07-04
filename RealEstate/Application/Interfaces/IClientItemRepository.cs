using RealEstate.API.Application.Common;
using RealEstate.API.Domain;

namespace RealEstate.API.Application.Interfaces
{
    public interface IClientItemRepository : IBaseInterface<ClientItem>
    {
        List<ClientItem> GetByClientId(long clientId);
        List<ClientItem> GetByItemId(long itemId);
        List<ClientItem> GetByStatus(string status);
    }
}