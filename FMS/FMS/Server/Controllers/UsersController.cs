using FMS.Server.Repository.Interfaces;
using FMS.Server.Services;
using FMS.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

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
        public async ValueTask<IEnumerable<UserInfo>> Get()
        {
            var temp = await UserInfoRepository.GetAllAsync();
            //var temp2 = dataService.Test();
            return temp;
        }



    }
}
