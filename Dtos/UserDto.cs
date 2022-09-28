using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

      

       // public string HashSalt { get; set; }

        
        public ICollection<RoleDto> UserRoles { get; set; } = new List<RoleDto>();
    }
    /*public class CreateUserRequestModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Password { get; set; }

        public string HashSalt { get; set; }

        public ICollection<int> UserRoleId = new List<int>();
    }*/

    public class UpdateUserRequestModel
    {
        /*public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string HashSalt { get; set; }

        public string Password { get; set; }

        
        public IList<int> UserRoleIds = new List<int>();*/
    }

    public class UserLoginResponseModel 
    {
        public string Token { get; set; }

        public UserDto Data { get; set; }

        public bool Success { get; set; }

        public string Message { get; set; }
    }

    /*public class UserRegisterRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }*/

    public class LogInRequestModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
        
    }
    public class LoginResponseModel
    {
        public string Token { get; set; }
        public UserDto Data { get; set; }

        public ICollection<RoleDto> UserRoles { get; set; } = new List<RoleDto>();
    } 
}
