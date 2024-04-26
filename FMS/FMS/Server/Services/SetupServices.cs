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
            UsersTb? model = await context.UsersTbs.FirstOrDefaultAsync(m => m.UserId == "admin");

            if (model == null)
            { 
                model = new UsersTb();
                model.UserId = "admin";
                model.Password = "stecdev1234!";
                model.Name = "stec";
                model.AdminYn = true;
                model.AlarmYn = false;
                model.PermBuilding = 2;
                model.PermEquipment = 2;
                model.PermMaterial = 2;
                model.PermEnergy = 2;
                model.PermOffice = 2;
                model.PermComp = 2;
                model.PermConst = 2;
                model.PermClaim = 2;
                model.PermSys = 2;
                model.PermEmployee = 2;
                model.PermLawCk = 2;
                model.PermLawEdu = 2;
                model.Status = true;
                model.CreateUser = "관리자";

                context.UsersTbs.Add(model);
                await context.SaveChangesAsync();
            }



        }
            
    }
}
