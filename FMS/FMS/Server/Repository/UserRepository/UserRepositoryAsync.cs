using FMS.Server.Models;
using FMS.Shared.Models;

namespace FMS.Server.Repository.UserRepository
{
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        private readonly AppDbContext _context;

        public UserRepositoryAsync(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<Users> Add(Users user)
        {
            try
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
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
