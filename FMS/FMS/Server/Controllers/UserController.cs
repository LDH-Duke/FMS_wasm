using FMS.Server.Services.UserService;
using FMS.Server.Services.UserService.DTOs;
using FMS.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserServiceAsync _userService;

        public UserController(IUserServiceAsync userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddUser(UserDTO userDTO)
        {
            try
            {
                //서비스 호출
                Console.WriteLine(userDTO);
                await _userService.AddUserAsync(userDTO);
                return Ok(userDTO);
            }
            catch (Exception ex)
            {
                return Ok();
            }
        }

        /// <summary>
        /// 단일 조회
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserByAccount(string account)
        {
            try
            {
                //서비스 호출
                Console.WriteLine(account);
                return Ok(account);
            }
            catch (Exception ex)
            {
                return Ok();
            }
            
        }

        /// <summary>
        /// 전체 조회
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllUser()
        {
            try
            {
                //서비스 호출

                return Ok();
            }
            catch(Exception ex)
            {
                return Ok();
            }
            
        }

        /// <summary>
        /// 회원 수정
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult EditUser(Users user)
        {
            try
            {
                //서비스 호출

                return Ok();
            }
            catch(Exception ex)
            {
                return Ok();

            }
            
        }

        /// <summary>
        /// 회원 삭제
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeleteUser(string account)
        {
            try
            {
                return Ok();
            }catch(Exception ex)
            {
                return Ok();
            }
        }
    }
}
