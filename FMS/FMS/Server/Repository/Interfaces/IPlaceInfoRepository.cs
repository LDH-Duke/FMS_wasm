using FMS.Shared.Models;

namespace FMS.Server.Repository.Interfaces
{
    public interface IPlaceInfoRepository
    {
        /// <summary>
        /// 입력(비동기)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ValueTask<PlaceInfo> AddAsync(PlaceInfo model);

        /// <summary>
        /// 전체조회 (비동기)
        /// </summary>
        /// <returns></returns>
        ValueTask<List<PlaceInfo>> GetAllAsync();


        /// <summary>
        /// ID검색 조회 (비동기)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<PlaceInfo> GetByUserIdAsync(string code);

        /// <summary>
        /// 수정 (비동기)
        /// </summary>
        /// <returns></returns>
        ValueTask<bool> EditAsync(PlaceInfo model);

        /// <summary>
        /// 삭제 (비동기)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<bool> DeleteAsync(string code);
    }
}
