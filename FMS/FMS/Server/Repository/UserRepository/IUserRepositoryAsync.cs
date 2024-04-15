using FMS.Shared.Models;

namespace FMS.Server.Repository.UserRepository
{
    public interface IUserRepositoryAsync
    {
        Task<Users> Add(Users user);
    }
}
