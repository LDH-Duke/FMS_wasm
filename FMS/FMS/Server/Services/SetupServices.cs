using FMS.Server.Databases;
using FMS.Server.Repository;
using FMS.Server.Repository.Interfaces;
using FMS.Shared.Model;
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
            Userinfo? model = await context.Userinfos.FirstOrDefaultAsync(m => m.Userid == "admin");

            if (model == null)
            { 
                model = new Userinfo();
                model.Userid = "admin";
                model.Password = "stecdev1234!";
                model.AdminYn = true;
                model.PermPlace = 2;
                model.PermDevice = 2;
                model.PermMaterial = 2;
                model.PermEnergy = 2;
                model.PermAdm = 2;
                model.PermComp = 2;
                model.PermConst = 2;
                model.PermClaim = 2;
                model.PermSys = 2;
                model.PermImployee = 2;
                model.PermLawck = 2;
                model.PermLawedu = 2;

                context.Userinfos.Add(model);
                await context.SaveChangesAsync();
            }



        }
            
    }
}
