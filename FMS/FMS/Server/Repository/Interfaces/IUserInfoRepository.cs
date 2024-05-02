using FMS.Shared.Model;

namespace FMS.Server.Repository.Interfaces
{
    public interface IUserInfoRepository
    {
        /// <summary>
        /// 입력(비동기)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ValueTask<UsersTb> AddAsync(UsersTb model);

        /// <summary>
        /// 전체조회 (비동기)
        /// </summary>
        /// <returns></returns>
        ValueTask<List<UsersTb>> GetAllAsync();


        /// <summary>
        /// ID검색 조회 (비동기)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<UsersTb> GetByUserIdAsync(string userid);

        /// <summary>
        /// 수정 (비동기)
        /// </summary>
        /// <returns></returns>
        ValueTask<bool> EditAsync(UsersTb model);

        /// <summary>
        /// 삭제 (비동기)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<bool> DeleteAsync(string userid);

        /// <summary>
        /// 사용자검색 (이름으로)
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        ValueTask<List<UsersTb>> GetByUserNameAsync(string username);
    }
}
