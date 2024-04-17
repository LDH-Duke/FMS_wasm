using FMS.Server.Databases;
using FMS.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FMS.Server.Services
{
    public class UserService : IUserService
    {
        private readonly FmsContext context;

        public UserService(FmsContext context)
        {
            this.context = context;
        }

        

        public UserInfo CreateModel(UserInfo model)
        {
            model.UserId = model.UserId.ToLower();
            return model;
        }
    }
}
