using Scanpay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Interface.Service
{
    public interface IUserService
    {
        //bool AddUSer(CreateUserRequestModel model);


        //Task<bool> UpdateUserAsync(int id, UpdateUserRequestModel model);

        Task<UserDto> GetUserAsync(int id);

        Task<IList<UserDto>> GetAllUsersAsync();

        //Task<bool> DeleteUserAsync(int id);


        //Task<bool> ExistsByPassWord(string passWord);

        // Task<bool> ExitsByEmailAsync(string email);

        Task<UserDto> LogInAsync(LogInRequestModel model);

        Task<UserDto> GetUserByEmailAsync(string email);

       // UserDto RegisterUser(UserRegisterRequestModel model);
            

        //Task<UserDto> GetUserByPasswordAsync(string password);





    }
}
