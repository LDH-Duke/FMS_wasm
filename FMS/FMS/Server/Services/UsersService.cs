using FMS.Server.Models;
using FMS.Server.Services.Interfaces;
using FMS.Shared.Models;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;

namespace FMS.Server.Services
{
    public class UsersService : IUsersService
    {
        private readonly AppDbContext context;

        public UsersService(AppDbContext _context)
        {
            context = _context;
        }

        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async ValueTask<Users> AddAsync(Users model)
        {
            try
            {
                context.User.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        
        
        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="reqno"></param>
        /// <returns></returns>
        public async ValueTask<bool> DeleteAsync(int reqno)
        {
            try
            {
                Users? model = await context.User.FindAsync(reqno);
                if(model != null)
                {
                    context.User.Remove(model);
                    return await context.SaveChangesAsync() > 0 ? true : false;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async ValueTask<bool> EditAsync(Users model)
        {
            try
            {
                context.User.Update(model);
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 전체 조회
        /// </summary>
        /// <returns></returns>
        public async ValueTask<List<Users>> GetAllAsync()
        {
            try
            {
                return await context.User.ToListAsync();
            }
            catch(Exception ex)
            {
                throw;
            }

        }

        /// <summary>
        /// ID 조회
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async ValueTask<Users> GetByIdAsync(string userid)
        {
            /*
            try
            {
                Users? model = await context.User.FirstOrDefaultAsync(m => m.UserId == userid);
                if(model != null)
                {
                    return model;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            */

            return null;
        }

        /// <summary>
        /// REQNO 조회
        /// </summary>
        /// <param name="reqno"></param>
        /// <returns></returns>
        public async ValueTask<Users> GetByReqNoAsync(int reqno)
        {
            /*
            try
            {
                Users? model = await context.User.FirstOrDefaultAsync(m => m.Reqno == reqno);

                if (model != null)
                {
                    return model;
                }
                else
                {
                    throw new ArgumentNullException();
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            */

            return null;
        }
    }
}
