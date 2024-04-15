using FMS.Shared.Models;

namespace FMS.Server.Repository.UserRepository
{
    public interface IUserRepositoryAsync 
    {
        /// <summary>
        /// 입력(비동기)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ValueTask<Users> AddAsync(Users model);

        /// <summary>
        /// 입력
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ValueTask<Users> Add(Users model);

        /// <summary>
        /// 전체조회(비동기)
        /// </summary>
        /// <returns></returns>
        ValueTask<List<Users>> GetAllAsync();

        /// <summary>
        /// 전체조회
        /// </summary>
        /// <returns></returns>
        ValueTask<List<Users>> GetAll();

        /// <summary>
        /// 수정(비동기)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ValueTask<bool> EditAsync(Users model);

        /// <summary>
        /// 수정
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ValueTask<bool> Edit(Users model);

        /// <summary>
        /// 삭제(비동기)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ValueTask<bool> DeleteAsync(int id);

        /// <summary>
        /// 삭제
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<bool> Delete(int id);

        /// <summary>
        /// USERID 조회(비동기)
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<Users> GetByUserIdAsync(string userid);

        /// <summary>
        /// USERID 조회
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        ValueTask<Users> GetByUserId(string userid);

        /// <summary>
        /// ID 조회(비동기)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<Users> GetByIdAsync(int id);

        /// <summary>
        /// ID 조회
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<Users> GetById(int id);
        
    }
}
