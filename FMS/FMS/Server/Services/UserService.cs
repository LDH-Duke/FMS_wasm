using FMS.Server.Databases;
using FMS.Shared.Model;
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

        
      
    }
}
