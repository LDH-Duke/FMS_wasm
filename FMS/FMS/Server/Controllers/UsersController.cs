using FMS.Server.Repository.Interfaces;
using FMS.Server.Services;
using FMS.Shared.Model;
using FMS.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;

namespace FMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService dataService;
        private readonly IUserInfoRepository UserInfoRepository;

        public UsersController(IUserInfoRepository _UserInfoRepository, IUserService _dataService)
        {
            UserInfoRepository = _UserInfoRepository;
            dataService = _dataService;
        }

        [HttpGet]
        public async ValueTask<IEnumerable<Userinfo>> Get()
        {
            var temp = await UserInfoRepository.GetAllAsync();
            //var temp2 = dataService.Test();
            return temp;
        }



        [HttpPost]
        [Route("aa")]
        public async Task<IActionResult> AddUser()
        {
            try
            {
                Console.WriteLine("gg");
                using var reader = new StreamReader(Request.Body);
                string body = await reader.ReadToEndAsync();
                Console.WriteLine(body);


                //UserInfoRepository.GetByUserIdAsync()
                return Ok("Data received successfully!");

            }
            catch(Exception ex)
            {
                Console.WriteLine("[UserController][AddUser] + 회원가입 컨트롤러 에러 ! \n" + ex);
                return BadRequest("Error occurred while processing data.");
            }
        }


    }
}
