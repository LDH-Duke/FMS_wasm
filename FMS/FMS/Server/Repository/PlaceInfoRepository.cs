using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using FMS.Server.Databases;
using FMS.Server.Repository.Interfaces;
using FMS.Shared.Client.Dto;
using FMS.Shared.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

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
        public async ValueTask<PlacesTb> AddAsync(PlacesTb model)
        {
            try
            {
                context.PlacesTbs.Add(model);
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
                PlacesTb? model = await context.PlacesTbs.FirstOrDefaultAsync(m => m.PlaceCd == code);
                if (model != null)
                {
                    context.PlacesTbs.Remove(model);
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
        public async ValueTask<bool> EditAsync(PlacesTb model)
        {
            try
            {
                context.PlacesTbs.Update(model);
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
        public async ValueTask<List<PlacesTb>> GetAllAsync()
        {
            try
            {
                return await context.PlacesTbs.ToListAsync();
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
        public async ValueTask<PlacesTb> GetByUserIdAsync(string code)
        {
            try
            {
				PlacesTb? model = await context.PlacesTbs.FirstOrDefaultAsync(m => m.PlaceCd == code);
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

        public async ValueTask<List<PlaceDto>> GetTableListAsync(){
            try
            {
                var result = await context.PlacesTbs
                .Select(p => new PlaceDto
                {
                    Code = p.PlaceCd,
                    Name = p.Name,
                    Note = p.Note,
                    ContractNum = p.ContractNum,
                    ContractDate = (DateTime)p.CreateDt,
                })
                .ToListAsync();
                return result;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async void GetColumnsAsync(){
            var a = typeof(PlacesTb);
            var b = a.GetProperties();
            foreach(var property in b){
                var c = property.GetCustomAttribute<ColumnAttribute>();
                Console.WriteLine(c);
            }

        
        }
    }


}
