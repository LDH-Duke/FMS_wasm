using FMS.Server.Databases;
using FMS.Server.Repository.Interfaces;
using FMS.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.Server.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly FmsContext context;

        public UserInfoRepository(FmsContext _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async ValueTask<UsersTb> AddAsync(UsersTb model)
        {
            try
            {
                System.Console.WriteLine("여기들어옴");
                context.UsersTbs.Add(model);
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
        /// <param name="userid"></param>
        /// <returns></returns>
        public async ValueTask<bool> DeleteAsync(string userid)
        {
            try
            {
                UsersTb? model = await context.UsersTbs.FirstOrDefaultAsync(m => m.UserId == userid);
                if (model != null)
                {
                    context.UsersTbs.Remove(model);
                    return await context.SaveChangesAsync() > 0 ? true : false;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 수정
        /// </summary>
        /// <returns></returns>
        public async ValueTask<bool> EditAsync(UsersTb model)
        {
            try
            {
                context.UsersTbs.Update(model);
                return await context.SaveChangesAsync() > 0 ? true : false;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 전체조회
        /// </summary>
        /// <returns></returns>
        public async ValueTask<List<UsersTb>> GetAllAsync()
        {
            try
            {
                return await context.UsersTbs.ToListAsync();
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// ID 검색
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        public async ValueTask<UsersTb> GetByUserIdAsync(string userid)
        {
            try
            {
                UsersTb? model = await context.UsersTbs.FirstOrDefaultAsync(m => m.UserId == userid);
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
        }
    }
}
