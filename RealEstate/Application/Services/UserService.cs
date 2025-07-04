using RealEstate.API.Application.Common;
using RealEstate.API.Application.Interfaces;
using RealEstate.API.Domain;

namespace RealEstate.API.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public List<User> GetAll() => _repository.GetAll();
        public User? GetById(long id) => _repository.GetById(id);
        public OperationResult Add(User user)
        {
            try
            {
                _repository.Add(user);
                return OperationResult.Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to add user.", ex.Message);
            }
        }
        public OperationResult Update(User user)
        {
            try
            {
                _repository.Update(user);
                return OperationResult.Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to update user.", ex.Message);
            }
        }
        public OperationResult Delete(long id)
        {
            try
            {
                _repository.Delete(id);
                return OperationResult.Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return OperationResult.Fail("Failed to delete user.", ex.Message);
            }
        }
    }
}