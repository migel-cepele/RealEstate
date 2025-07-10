using RealEstate.API.Application.Common;
using RealEstate.API.Application.Common.Constants;
using RealEstate.API.Domain;

namespace RealEstate.API.Application.Interfaces
{
    public interface IClientRepository : IBaseInterface<Client>
    {
        PaginationResult<Client> Filter(int pageNumber, int pageSize, long lastId, Dictionary<string, string> keyValues);
        void UpdateClientPriority(ClientItem clientItem, List<Client> allClients);
    }
}