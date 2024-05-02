using FMS.Server.Repository;
using FMS.Server.Repository.Interfaces;
using FMS.Server.Services;
using FMS.Shared.Model;
using FMS.Shared.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;

namespace FMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserInfoRepository UserInfoRepository;

        public UsersController(IUserInfoRepository _UserInfoRepository, IUserService _dataService)
        {
            UserInfoRepository = _UserInfoRepository;
        }

        [HttpGet]
        public async void Get()
        {
            var temp = await UserInfoRepository.GetAllAsync();
            //var temp2 = dataService.Test();
            // return temp;
        }



        [HttpPost]
        [Route("aa")]
        public async Task<IActionResult> AddUser()
        {
            try
            {
                Console.WriteLine("gg");
                var reader = new StreamReader(Request.Body);
                string body = await reader.ReadToEndAsync();
                UsersTb user = JsonConvert.DeserializeObject<UsersTb>(body);
                await UserInfoRepository.AddAsync(user);


                //UserInfoRepository.GetByUserIdAsync()
                return Ok("Data received successfully!");

            }
            catch(Exception ex)
            {
                Console.WriteLine("[UserController][AddUser] + 회원가입 컨트롤러 에러 ! \n" + ex);
                return BadRequest("Error occurred while processing data.");
            }
        }

        [HttpPost]
        [Route("search/{username}")]
        public async Task<IActionResult> SearchName(string username)
        {
            var temp = await UserInfoRepository.GetByUserNameAsync(username);

            return Ok();
        }

    }
}
