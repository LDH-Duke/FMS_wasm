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

        public ValueTask<Users> AddAsync(Users model)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> Edit(Users model)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> EditAsync(Users model)
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<Users>> GetAll()
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<Users>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask<Users> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Users> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Users> GetByUserId(string userid)
        {
            throw new NotImplementedException();
        }

        public ValueTask<Users> GetByUserIdAsync(string userid)
        {
            throw new NotImplementedException();
        }

        ValueTask<Users> IUserRepositoryAsync.Add(Users model)
        {
            throw new NotImplementedException();
        }
    }
}
