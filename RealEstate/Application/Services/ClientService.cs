using RealEstate.API.Application.Common;
using RealEstate.API.Application.DTO;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;

namespace RealEstate.API.Application.Services
{
    public class ClientService
    {
        private readonly IClientRepository _repository;
        private readonly IClientItemRepository _clientItemRepository;
        private readonly IItemRepository _itemRepository;

        public ClientService(IClientRepository repository, IClientItemRepository clientItemRepository, IItemRepository itemRepository)
        {
            _repository = repository;
            _clientItemRepository = clientItemRepository;
            _itemRepository = itemRepository;
        }

        public List<Client> GetAll() => _repository.GetAll();
        public Client? GetById(long id) => _repository.GetById(id);
        public OperationResult Add(Client client)
        {
            try
            {
                _repository.Add(client);
                return OperationResult.Ok("Client added successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to add client.", ex.Message);
            }
        }
        public OperationResult Update(Client client)
        {
            try
            {
                _repository.Update(client);
                return OperationResult.Ok("Client updated successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to update client.", ex.Message);
            }
        }
        public OperationResult Delete(long id)
        {
            try
            {
                _repository.Delete(id);
                return OperationResult.Ok("Client deleted successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to delete client.", ex.Message);
            }
        }

        public PaginationResult<Client> Filter(int pageNumber, int pageSize, Dictionary<string, string> keyValues)
        {
            return _repository.Filter(pageNumber, pageSize, keyValues);
        }

        public List<ClientItemsHistoryDto>? GetClientItemsHistory(long clientId)
        {
            var clientItems = _clientItemRepository.GetByClientId(clientId);
            List<ClientItemsHistoryDto> clientItemsHistory = new List<ClientItemsHistoryDto>();
            foreach (var clientItem in clientItems)
            {
                var item = _itemRepository.GetById(clientItem.ItemId);
                if (item == null)
                {
                    continue; // Skip if item not found
                }
                clientItemsHistory.Add(new ClientItemsHistoryDto
                {
                    Title = item.Title,
                    Price = item.Price,
                    Address = item.Address,
                    PropertyType = item.PropertyType,
                    Status = item.Status,
                    UpdatedAt = item.UpdatedAt,
                    SaleType = clientItem.Status,
                    AcquiredDate = clientItem.CreatedAt,
                    AcquiredPrice = clientItem.Price,
                    Discount = clientItem.Discount,
                    Commission = clientItem.Commission,
                    PaymentMethod = clientItem.PaymentMethod
                });
            }
            return clientItemsHistory;
        }
    }
}