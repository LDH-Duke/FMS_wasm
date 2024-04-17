using FMS.Server.Repository.UserRepository;
using FMS.Server.Services.UserService.DTOs;
using FMS.Shared.Models;

namespace FMS.Server.Services.UserService
{
    public class UserService : IUserServiceAsync
    {
        private readonly IUserRepositoryAsync _userRepositoryAsync;

        public UserService(IUserRepositoryAsync userRepositoryAsync)
        {
            _userRepositoryAsync = userRepositoryAsync;
        }

        public async Task<Users> AddUserAsync(UserDTO userDto)
        {
            try
            {
                Console.WriteLine("service");
                Console.WriteLine(userDto);
                //await _userRepositoryAsync.Add(userDto);

                return new Users();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[UserService][AddUser] User Service 사용자 추가 에러 ! " + ex);
                throw ex;
            }
        }

        public Task<LoginDTO> LoginAsync(LoginDTO loginDto)
        {
            throw new NotImplementedException();
        }


        public Task<List<Users>> GetAllUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Users> GetUserByAccountAsync(string account)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(string account)
        {
            throw new NotImplementedException();
        }

        public Task<Users> EditAsync(UserDTO userDto)
        {
            throw new NotImplementedException();
        }

       
    }
}
