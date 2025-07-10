using RealEstate.API.Application.Common;
using RealEstate.API.Application.Common.Constants;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;
using RealEstate.API.Infrastructure.Data;
using System;

namespace RealEstate.API.Application.Services
{
    public class ClientItemService
    {
        private readonly IClientItemRepository _clientItemRepository;
        private readonly IClientRepository _clientRepository;
        private readonly IItemRepository _itemRepository;
        private readonly AppDbContext _dbContext;
        public ClientItemService(IClientItemRepository repository, IClientRepository clientRepository, AppDbContext appDbContext, IItemRepository itemRepository)
        {
            _dbContext = appDbContext;
            _clientRepository = clientRepository;
            _clientItemRepository = repository;
            _itemRepository = itemRepository;
        }
        public List<ClientItem> GetAll() => _clientItemRepository.GetAll();
        public ClientItem? GetById(long id) => _clientItemRepository.GetById(id);
        public async Task<OperationResult> Add(ClientItem clientItem)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                //shtojme clientItem
                clientItem.CreatedAt = CustomDateTime.GetNow();
                clientItem.UpdatedAt = CustomDateTime.GetNow();
                clientItem.IsActive = true; // Set IsActive to true when adding a new ClientItem
                _clientItemRepository.Add(clientItem);

                var allClients = _clientRepository.GetAll();

                _clientRepository.UpdateClientPriority(clientItem, allClients);

                // Update the item to be inactive
                var item = _itemRepository.GetById(clientItem.ItemId);
                if (item == null)
                {
                    return OperationResult.Fail("Item not found to add client item.");
                }
                item.IsActive = false; // Set IsActive to false when adding a new ClientItem
                item.Status = clientItem.Status; // Update the sale type
                item.UpdatedAt = CustomDateTime.GetNow();

                _itemRepository.Update(item);


                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                await transaction.CommitAsync();

                return OperationResult.Ok("ClientItem added successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to add client item.", ex.Message);
            }
        }
        public OperationResult Update(ClientItem clientItem)
        {
            try
            {
                _clientItemRepository.Update(clientItem);
                return OperationResult.Ok("ClientItem updated successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to update client item.", ex.Message);
            }
        }
        public OperationResult Delete(long id)
        {
            try
            {
                _clientItemRepository.Delete(id);
                return OperationResult.Ok("ClientItem deleted successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to delete client item.", ex.Message);
            }
        }

        public async Task<OperationResult> UpdateInActive(ClientItem clientItem)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                clientItem.UpdatedAt = CustomDateTime.GetNow();
                clientItem.IsActive = false; // Set IsActive to true when updating to active
                _clientItemRepository.Update(clientItem);

                var item = _itemRepository.GetById(clientItem.ItemId);
                if (item == null)
                {
                    return OperationResult.Fail("Item not found to update.");
                }
                item.IsActive = true;
                item.Status = ItemStatus.Available; // Update the sale type
                item.UpdatedAt = CustomDateTime.GetNow();

                _itemRepository.Update(item);

                // Commit transaction if all commands succeed, transaction will auto-rollback
                // when disposed if either commands fails
                await transaction.CommitAsync();
                return OperationResult.Ok("ClientItem updated to inactive successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to update client item to active.", ex.Message);
            }
        }
    }
}