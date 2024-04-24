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
        ValueTask<Userinfo> AddAsync(Userinfo model);

        /// <summary>
        /// 전체조회 (비동기)
        /// </summary>
        /// <returns></returns>
        ValueTask<List<Userinfo>> GetAllAsync();


        /// <summary>
        /// ID검색 조회 (비동기)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<Userinfo> GetByUserIdAsync(string userid);

        /// <summary>
        /// 수정 (비동기)
        /// </summary>
        /// <returns></returns>
        ValueTask<bool> EditAsync(Userinfo model);

        /// <summary>
        /// 삭제 (비동기)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<bool> DeleteAsync(string userid);
    }
}
