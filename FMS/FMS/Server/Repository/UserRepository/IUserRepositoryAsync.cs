using FMS.Shared.Models;
using FMS.Shared.Entity;

namespace FMS.Server.Repository.UserRepository
{
    public interface IUserRepositoryAsync
    {
        Task<UserInfo> Add(UserInfo user);
    }
}
