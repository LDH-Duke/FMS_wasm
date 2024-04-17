using FMS.Server.Databases;
using FMS.Server.Repository.Interfaces;
using FMS.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FMS.Server.Repository
{
    public class PlaceInfoRepository : IPlaceInfoRepository
    {
        private readonly FmsContext context;

        public PlaceInfoRepository(FmsContext _context)
        {
            this.context = _context;
        }

        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async ValueTask<PlaceInfo> AddAsync(PlaceInfo model)
        {
            try
            {
                context.PlaceInfos.Add(model);
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
        /// <param name="code"></param>
        /// <returns></returns>
        public async ValueTask<bool> DeleteAsync(string code)
        {
            try
            {
                PlaceInfo? model = await context.PlaceInfos.FirstOrDefaultAsync(m => m.Code == code);
                if (model != null)
                {
                    context.PlaceInfos.Remove(model);
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
        /// <param name="model"></param>
        /// <returns></returns>
        public async ValueTask<bool> EditAsync(PlaceInfo model)
        {
            try
            {
                context.PlaceInfos.Update(model);
                return await context.SaveChangesAsync() > 0 ? true : false;
            }catch(Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// 전체조회
        /// </summary>
        /// <returns></returns>
        public async ValueTask<List<PlaceInfo>> GetAllAsync()
        {
            try
            {
                return await context.PlaceInfos.ToListAsync();
            }
            catch(Exception ex) 
            {
                throw;
            }
        }

        /// <summary>
        /// ID 검색
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async ValueTask<PlaceInfo> GetByUserIdAsync(string code)
        {
            try
            {
                PlaceInfo? model = await context.PlaceInfos.FirstOrDefaultAsync(m => m.Code == code);
                if (model != null)
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
