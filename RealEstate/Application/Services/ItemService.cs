using RealEstate.API.Application.Common;
using RealEstate.API.Application.DTO;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;

namespace RealEstate.API.Application.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IClientItemRepository _clientItemRepository;
        private readonly IClientRepository _clientRepository;
        public ItemService(IItemRepository itemRepository, IClientItemRepository clientItemRepository, IClientRepository clientRepository)
        {
            _itemRepository = itemRepository;
            _clientItemRepository = clientItemRepository;
            _clientRepository = clientRepository;
        }
        public List<Item> GetAll() => _itemRepository.GetAll();
        public Item? GetById(long id) => _itemRepository.GetById(id);
        public OperationResult Add(Item item)
        {
            try
            {
                _itemRepository.Add(item);
                return OperationResult.Ok("Item added successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to add item.", ex.Message);
            }
        }
        public OperationResult Update(Item item)
        {
            try
            {
                _itemRepository.Update(item);
                return OperationResult.Ok("Item updated successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to update item.", ex.Message);
            }
        }
        public OperationResult Delete(long id)
        {
            try
            {
                _itemRepository.Delete(id);
                return OperationResult.Ok("Item deleted successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to delete item.", ex.Message);
            }
        }

        public PaginationResult<Item> Filter(int pageNumber, int pageSize, Dictionary<string, string> keyValues)
        {
            return _itemRepository.Filter(pageNumber, pageSize, keyValues);
        }

        public List<ItemClientsHistoryDto>? GetItemClientsHistory(long itemId)
        {
            var itemClients = _clientItemRepository.GetByItemId(itemId);
            List<ItemClientsHistoryDto> itemClientsHistory = new List<ItemClientsHistoryDto>();
            foreach (var itemClient in itemClients)
            {
                var client = _clientRepository.GetById(itemClient.ClientId);
                if(client == null)
                {
                    continue; // Skip if client not found
                }
                itemClientsHistory.Add(new ItemClientsHistoryDto
                {
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    PhoneNumber = client.PhoneNumber,
                    IsActive = client.IsActive,
                    UpdatedAt = client.UpdatedAt,
                    PriorityNo = client.PriorityNo ?? 0,
                    SaleType = itemClient.Status,
                    Price = itemClient.Price,
                    Discount = itemClient.Discount,
                    Commission = itemClient.Commission,
                    PaymentMethod = itemClient.PaymentMethod,
                    Currency = itemClient.Currency
                });
            }
            return itemClientsHistory;
        }
    }
}