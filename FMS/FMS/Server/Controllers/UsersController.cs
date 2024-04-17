using FMS.Server.Repository.Interfaces;
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

    }
}
