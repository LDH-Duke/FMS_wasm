using FMS.Shared.Models;

namespace FMS.Server.Services
{
    public interface IUserService
    {
        UserInfo CreateModel(UserInfo model);
    }
}
