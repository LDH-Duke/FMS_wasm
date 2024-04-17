using FMS.Server.Databases;
using FMS.Server.Repository.Interfaces;
using FMS.Shared.Models;
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
        public async ValueTask<UserInfo> AddAsync(UserInfo model)
        {
            try
            {
                context.UserInfos.Add(model);
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
                UserInfo? model = await context.UserInfos.FirstOrDefaultAsync(m => m.UserId == userid);
                if (model != null)
                {
                    context.UserInfos.Remove(model);
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
        public async ValueTask<bool> EditAsync(UserInfo model)
        {
            try
            {
                context.UserInfos.Update(model);
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
        public async ValueTask<List<UserInfo>> GetAllAsync()
        {
            try
            {
                return await context.UserInfos.ToListAsync();
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
        public async ValueTask<UserInfo> GetByUserIdAsync(string userid)
        {
            try
            {
                UserInfo? model = await context.UserInfos.FirstOrDefaultAsync(m => m.UserId == userid);
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
