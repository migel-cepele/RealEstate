using RealEstate.API.Application.Common;
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
        private readonly AppDbContext _dbContext;
        public ClientItemService(IClientItemRepository repository, IClientRepository clientRepository, AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
            _clientRepository = clientRepository;
            _clientItemRepository = repository;
        }
        public List<ClientItem> GetAll() => _clientItemRepository.GetAll();
        public ClientItem? GetById(long id) => _clientItemRepository.GetById(id);
        public async Task<OperationResult> Add(ClientItem clientItem)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                //shtojme clientItem
                _clientItemRepository.Add(clientItem);

                var allClients = _clientRepository.GetAll();

                _clientRepository.UpdateClientPriority(clientItem, allClients);

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
    }
}