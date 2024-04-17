using FMS.Server.Models;
using FMS.Shared.Models;
using FMS.Shared.Entity;

namespace FMS.Server.Repository.UserRepository
{
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        private readonly AppDbContext _context;
        private readonly FmsContext _db;

        public UserRepositoryAsync(FmsContext db)
        {
            this._db = db;
        }

        public async Task<UserInfo> Add(UserInfo user)
        {
            try
            {
                _db.UserInfo.Add(user);
                await _db.SaveChangesAsync();
                return user;
            }
            catch(Exception ex)
            {
                Console.WriteLine("[UserRepository][Add] 회원가입 Repository 에러 ! " + ex);
                throw ex;
            }
                
        }
    }
}
