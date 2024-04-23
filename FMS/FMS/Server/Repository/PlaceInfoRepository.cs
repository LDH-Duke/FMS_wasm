using FMS.Server.Databases;
using FMS.Server.Repository.Interfaces;
using FMS.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.Server.Repository
{
    public class PlaceInfoRepository : IPlaceInfoRepository
    {
        private readonly FmsContext context;

        public PlaceInfoRepository(FmsContext _context)
        {
            this.context = _context;
            Console.WriteLine("참조");
        }

        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async ValueTask<Placeinfo> AddAsync(Placeinfo model)
        {
            try
            {
                context.Placeinfos.Add(model);
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
                Placeinfo? model = await context.Placeinfos.FirstOrDefaultAsync(m => m.Code == code);
                if (model != null)
                {
                    context.Placeinfos.Remove(model);
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
        public async ValueTask<bool> EditAsync(Placeinfo model)
        {
            try
            {
                context.Placeinfos.Update(model);
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
        public async ValueTask<List<Placeinfo>> GetAllAsync()
        {
            try
            {
                return await context.Placeinfos.ToListAsync();
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
        public async ValueTask<Placeinfo> GetByUserIdAsync(string code)
        {
            try
            {
				Placeinfo? model = await context.Placeinfos.FirstOrDefaultAsync(m => m.Code == code);
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
