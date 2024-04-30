using FMS.Server.Repository;
using FMS.Server.Repository.Interfaces;
using FMS.Server.Services;
using FMS.Shared.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Nodes;

namespace FMS.Server.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService dataService;
        private readonly IUserInfoRepository UserInfoRepository;

        private readonly IPlaceInfoRepository PlaceInfoRepository;

        public UsersController(IUserInfoRepository _UserInfoRepository, IUserService _dataService, IPlaceInfoRepository _PlaceInfoRepository)
        {
            //place 테스트
            PlaceInfoRepository = _PlaceInfoRepository;
            UserInfoRepository = _UserInfoRepository;
            dataService = _dataService;
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

        // 사업장 DB조회 TEST용
        [HttpGet]
        [Route("place")]
        public async Task<IActionResult> FindAllPlace()
        {
            try
            {
                Console.WriteLine("사업장 테이블 조회");
                var place_list = await PlaceInfoRepository.GetTableListAsync();
                Console.WriteLine(place_list);


                return Ok(place_list);
            }catch(Exception ex)
            {
                Console.WriteLine("[UserController][AddUser] + 회원가입 컨트롤러 에러 ! \n" + ex);
                return BadRequest("Error occurred while processing data.");
            }
        }
    }

}

