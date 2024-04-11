using FMS.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FMS.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUser(Users user)
        {
            //서비스 호출
            Console.WriteLine(user);
            return Ok(user);
        }

        /// <summary>
        /// 단일 조회
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetUserByAccount(string account)
        {
            //서비스 호출
            Console.WriteLine(account);
            return Ok(account);
        }

        /// <summary>
        /// 전체 조회
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllUser()
        {
            //서비스 호출
            
            return Ok();
        }

        /// <summary>
        /// 회원 수정
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult EditUser(Users user)
        {
            //서비스 호출

            return Ok();
        }

        /// <summary>
        /// 회원 삭제
        /// </summary>
        /// <param name="Account"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult DeleteUser(string account)
        {
            //서비스 호출

            return Ok();
        }
    }
}
