using FMS.Server.Services.UserService.DTOs;
using FMS.Shared.Models;

namespace FMS.Server.Services.UserService
{
    public interface IUserServiceAsync
    {
        //생성
        Task<Users> AddUserAsync(UserDTO userDto);
        //로그인
        Task<LoginDTO> LoginAsync(LoginDTO loginDto);
        //단일 조회
        Task<Users> GetUserByAccountAsync(string account);
        //전체 조회
        Task<List<Users>> GetAllUserAsync();
        //수정
        Task<Users> EditAsync(UserDTO userDto);
        //삭제
        Task<bool> DeleteAsync(string account);

    }
}
