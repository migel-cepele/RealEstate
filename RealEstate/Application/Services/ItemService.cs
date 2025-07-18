using Microsoft.EntityFrameworkCore;
using RealEstate.API.Application.Common;
using RealEstate.API.Application.DTO;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;

namespace RealEstate.API.Application.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IClientItemRepository _clientItemRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IItemImageRepository _itemImageRepository;
        private readonly AppDbContext _dbContext;
        public ItemService(IItemRepository itemRepository, IClientItemRepository clientItemRepository, 
            IClientRepository clientRepository, IItemImageRepository itemImageRepository, AppDbContext appDbContext)
        {
            _itemRepository = itemRepository;
            _clientItemRepository = clientItemRepository;
            _clientRepository = clientRepository;
            _itemImageRepository = itemImageRepository;
            _dbContext = appDbContext;
        }
        public List<Item> GetAll() => _itemRepository.GetAll();
        public Item? GetById(long id) => _itemRepository.GetById(id);
        public async Task<OperationResult> Add(Item item, List<ItemImage> itemImages)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                _itemRepository.Add(item);
                foreach(var image in itemImages)
                {
                    image.ItemId = item.Id; // Associate the image with the item
                    _itemImageRepository.Add(image);
                }

                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                await transaction.CommitAsync();
                return OperationResult.Ok("Item and item images added successfully.");
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

        public PaginationResult<Item> Filter(int pageNumber, int pageSize, long lastId, Dictionary<string, string> keyValues)
        {
            return _itemRepository.Filter(pageNumber, pageSize, lastId, keyValues);
        }

        public List<ItemClientsHistoryDto>? GetItemClientsHistory(long itemId)
        {
            var itemClients = _clientItemRepository.GetByItemId(itemId);
            List<ItemClientsHistoryDto> itemClientsHistory = new List<ItemClientsHistoryDto>();
            foreach (var itemClient in itemClients)
            {
                var client = _clientRepository.GetById(itemClient.ClientId);
                if (client == null)
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