using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user);

        Task<User> UpdateUserAsync(User user);

        Task<User> GetUserAsync(int id);

        Task<IList<User>> GetAllUsersAsync();

        Task<IList<User>> GetAllSelectedUserAsync(IList<int> ids);

        //void DeleteUser(User user);

        Task<bool> ExistsByPassWordAsync(string passWord);
        
        Task<bool> ExitsByEmailAsync(string email);

        Task<User> GetUserByEmailAsync(string email);

        Task<User> GetUserByPasswordAsync(string password);


    }
}
