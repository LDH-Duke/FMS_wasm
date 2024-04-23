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
        public async ValueTask<Userinfo> AddAsync(Userinfo model)
        {
            try
            {
                context.Userinfos.Add(model);
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
                Userinfo? model = await context.Userinfos.FirstOrDefaultAsync(m => m.Userid == userid);
                if (model != null)
                {
                    context.Userinfos.Remove(model);
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
        public async ValueTask<bool> EditAsync(Userinfo model)
        {
            try
            {
                context.Userinfos.Update(model);
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
        public async ValueTask<List<Userinfo>> GetAllAsync()
        {
            try
            {
                return await context.Userinfos.ToListAsync();
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
        public async ValueTask<Userinfo> GetByUserIdAsync(string userid)
        {
            try
            {
                Userinfo? model = await context.Userinfos.FirstOrDefaultAsync(m => m.Userid == userid);
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
