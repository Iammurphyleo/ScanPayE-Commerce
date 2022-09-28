using Microsoft.EntityFrameworkCore;
using Scanpay.Contex;
using Scanpay.Entity;
using Scanpay.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ScanPayContext _context;

        public UserRepository(ScanPayContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
             _context.Users.Add(user);

           await _context.SaveChangesAsync();

            return user;
        }

        /*public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }*/

        public async Task<bool> ExistsByPassWordAsync(string passWord)
        {
            var user = await _context.Users.AnyAsync(u => u.Password == passWord && u.IsDeleted == false);

            return user;
        }

        public async Task<bool> ExitsByEmailAsync(string email)
        {
            var user = await _context.Users.AnyAsync(u => u.Email == email && u.IsDeleted == false);

            return user;


        }

        public async Task<IList<User>> GetAllSelectedUserAsync(IList<int> ids)
        {
            var user = await _context.Users.Include(u => u.Staff).Include(s => s.Customer)
                
           .Where(s => ids.Contains(s.Id) && s.IsDeleted == false).ToListAsync();

            return user;
        }

        public async Task<IList<User>> GetAllUsersAsync()
        {
            var user = await _context.Users.Include(u=>u.UserRoles).ThenInclude(u=>u.Role)
                
            .Where(s => s.IsDeleted == false).ToListAsync();

            return user;
        }

        public async Task<User> GetUserAsync(int id)
        {
            //var user = await _context.Users.FindAsync(id);
            var user = await _context.Users.Include(u => u.UserRoles)

           .ThenInclude(u => u.Role).Where(u => u.Id == id && u.IsDeleted == false)

           .SingleOrDefaultAsync();

            return user;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _context.Users.Include(us=>us.UserRoles).ThenInclude(L=> L.Role)
                
            .FirstOrDefaultAsync(u => u.Email == email && u.IsDeleted == false);

                //(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            return user;
        }

        public async Task<User> GetUserByPasswordAsync(string password)
        {
            var user = await _context.Users.Where(u => u.Password == password && u.IsDeleted == false)

            .SingleOrDefaultAsync();

            return user;
        }

        public async  Task<User> UpdateUserAsync(User user)
        {
             _context.Users.Update(user);

            await _context.SaveChangesAsync();

            return user;
        }
    }
}
