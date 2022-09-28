using Scanpay.Dtos;
using Scanpay.Entity;
using Scanpay.Interface.Repository;
using Scanpay.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Implementation.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

       /*public bool AddUSer(CreateUserRequestModel model)
        {
           
            throw new NotImplementedException();
        }*/

        /*public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            _userRepository.DeleteUser(user);

            return true;
        }*/



        public async Task<IList<UserDto>> GetAllUsersAsync()
        {
            var user = await _userRepository.GetAllUsersAsync();
            var users = user.Select(u => new UserDto 
            { 
                FirstName = u.FirstName,
                LastName = u.LastName,
                Address = u.Address,
                Email = u.Email,
                Id = u.Id,
                PhoneNumber = u.PhoneNumber,

                UserRoles = u.UserRoles.Select(role => new RoleDto
                {
                    Id = role.Role.Id,
                    Name = role.Role.Name,
                    Description = role.Role.Description

                }).ToList()

            }).ToList();

            return users;
            
        }

        
        public async Task<UserDto> GetUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return new UserDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                UserRoles = user.UserRoles.Select(role => new RoleDto
                {
                    Id = role.Role.Id,
                    Name = role.Role.Name,
                    Description = role.Role.Description
                                   
                }).ToList()
                
            };
            
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return new UserDto 
            { 
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Id = user.Id,
                UserRoles = user.UserRoles.Select(role => new RoleDto
                {
                    Id = role.Role.Id,
                    Name = role.Role.Name,
                    Description = role.Role.Description

                }).ToList()
            };
        }

        public async Task<UserDto> LogInAsync(LogInRequestModel model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);
            //var passWord = await _userRepository.ExistsByPassWordAsync(model.Password);
            if(user == null)
            {
                return null;
            }
            if (user.Email != null && user.Password == model.Password) 
            {

                return new UserDto
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    PhoneNumber = user.PhoneNumber,
                    Id = user.Id,
                    UserRoles = user.UserRoles.Select(u => new RoleDto
                    {
                        Name = u.Role.Name,
                        Description = u.Role.Description,
                        Id = u.Role.Id

                    }).ToList()

                };
               
            }
            return null;
            


        }    
                
                  
       

        /*public UserDto RegisterUser(UserRegisterRequestModel model)
        {
            throw new NotImplementedException();
        }*/


         /*public async Task<bool> UpdateUserAsync(int id, UpdateUserRequestModel model)
         {
            var user = await _userRepository.GetUserAsync(id);
            var 
            var userRole = await _roleRepository.GetSelectedRolesAsync(model.UserRoleIds);

            foreach (var role in userRole) 
            {
                var roleUser = new UserRole 
                { 
                    UserId = user.Id,
                    User = user,
                    Role = role,
                    RoleId = role.Id,

                };
                user.UserRoles.Add(roleUser);
            
            }
             await _userRepository.UpdateUserAsync(user);

            return true;

         }*/
    }
}
