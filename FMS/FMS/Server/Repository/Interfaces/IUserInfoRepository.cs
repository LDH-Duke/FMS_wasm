using FMS.Shared.Models;

namespace FMS.Server.Repository.Interfaces
{
    public interface IUserInfoRepository
    {
        /// <summary>
        /// 입력(비동기)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ValueTask<UserInfo> AddAsync(UserInfo model);

        /// <summary>
        /// 전체조회 (비동기)
        /// </summary>
        /// <returns></returns>
        ValueTask<List<UserInfo>> GetAllAsync();


        /// <summary>
        /// ID검색 조회 (비동기)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<UserInfo> GetByUserIdAsync(string userid);

        /// <summary>
        /// 수정 (비동기)
        /// </summary>
        /// <returns></returns>
        ValueTask<bool> EditAsync(UserInfo model);

        /// <summary>
        /// 삭제 (비동기)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<bool> DeleteAsync(string userid);
    }
}
