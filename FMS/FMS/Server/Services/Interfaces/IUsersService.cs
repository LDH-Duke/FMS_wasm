using FMS.Shared.Models;

namespace FMS.Server.Services.Interfaces
{
    public interface IUsersService
    {
        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ValueTask<Users> AddAsync(Users model);

        /// <summary>
        /// 전체조회
        /// </summary>
        /// <returns></returns>
        ValueTask<List<Users>> GetAllAsync();

        /// <summary>
        /// tnwjd
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ValueTask<bool> EditAsync(Users model);

        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="reqno"></param>
        /// <returns></returns>
        ValueTask<bool> DeleteAsync(int reqno);

        /// <summary>
        /// 조회 - 사용자 ID 검색
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<Users> GetByIdAsync(string userid);

        /// <summary>
        /// 조회 - REQNO 검색
        /// </summary>
        /// <param name="reqno"></param>
        /// <returns></returns>
        ValueTask<Users> GetByReqNoAsync(int reqno);

    }
}
