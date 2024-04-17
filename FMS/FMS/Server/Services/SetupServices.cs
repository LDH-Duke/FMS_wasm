using FMS.Server.Databases;
using FMS.Server.Repository;
using FMS.Server.Repository.Interfaces;
using FMS.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FMS.Server.Services
{
    public class SetupServices : DbContext
    {
        FmsContext context;

        public SetupServices()
        {
            context = new FmsContext();
        }

        public async ValueTask SetupAdmin()
        {
            UserInfo? model = await context.UserInfos.FirstOrDefaultAsync(m => m.UserId == "admin");

            if (model == null)
            { 
                model = new UserInfo();
                model.UserId = "admin";
                model.Password = "stecdev1234!";
                model.IsAdmin = true;
                model.PermPlace = true;
                model.PermDevice = true;
                model.PermMaterial = true;
                model.PermEnergy = true;
                model.PermAdm = true;
                model.PermComp = true;
                model.PermConst = true;
                model.PermClaim = true;
                model.PermSys = true;
                model.PermImployee = true;
                model.PermLawck = true;
                model.PermLawedu = true;

                context.UserInfos.Add(model);
                await context.SaveChangesAsync();
            }



        }
            
    }
}
