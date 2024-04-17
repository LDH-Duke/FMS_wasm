using FMS.Server.Repository.Interfaces;
using FMS.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace FMS.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserInfoRepository UserInfoRepository;

        public UsersController(IUserInfoRepository _UserInfoRepository)
        {
            UserInfoRepository = _UserInfoRepository;
        }

        [HttpGet]
        public async ValueTask<IEnumerable<UserInfo>> Get()
        {
            var temp = await UserInfoRepository.GetAllAsync();
            return temp;
        }


        [HttpPost]
        public void AddUser()
        {
            try
            {
                Console.WriteLine("gg");
                var requestBody = Request.Body;

                Console.WriteLine(requestBody);

                //UserInfoRepository.GetByUserIdAsync()

                
            }
            catch(Exception ex)
            {
                Console.WriteLine("[UserController][AddUser] + 회원가입 컨트롤러 에러 ! \n" + ex);
            }
        }

    }
}
