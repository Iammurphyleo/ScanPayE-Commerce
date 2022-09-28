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
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public StaffService(IStaffRepository staffRepository , IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _staffRepository = staffRepository;

            _userRepository = userRepository;

            _roleRepository = roleRepository;
        }

        public async Task<StaffDto> AddStaffAsync(CreateStaffRequestModel model)
        {
            var staffCode = $"STC{Guid.NewGuid().ToString().Substring(0, 9).Replace("-", "").ToUpper()}";
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Password = staffCode,
                

            };
            var roles = await _roleRepository.GetSelectedRolesAsync(model.RoleIds);

            foreach(var role in roles) 
            {
                var userRole = new UserRole 
                { 
                    Role = role,
                    RoleId = role.Id,
                    User = user,
                    UserId = user.Id
                };
                user.UserRoles.Add(userRole);
            }
            var staff = new Staff
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                StaffCode = staffCode,
                UserId = user.Id,
                User = user
                
            };
            await _userRepository.CreateUserAsync(user);
            var newStaff = await _staffRepository.CreateStaffAsync(staff);
            return new StaffDto 
            { 
                FirstName = newStaff.FirstName,
                LastName = newStaff.LastName,
                Address = newStaff.Address,
                Email = newStaff.Email,
                PhoneNumber = newStaff.PhoneNumber,
                Id = newStaff.Id,
                StaffCode = newStaff.StaffCode
            
            };
        }

        public async Task<bool> DeleteStaffAsync(int id)
        {
            var staff = await _staffRepository.GetStaffAsync(id);

            staff.IsDeleted = true;

            await _staffRepository.UpdateStaffAsync(staff);

            ///_staffRepository.DeleteStaff(staff);
            return true;
        }

        public async Task<IList<StaffDto>> GetAllStaffsAsync()
        {
            var staff = await _staffRepository.GetAllStaffsAsync();

            var staffs = staff.Select(s => new StaffDto
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                Address = s.Address,
                Email = s.Email,
                PhoneNumber = s.PhoneNumber,
                Id = s.Id,
                StaffCode = s.StaffCode,
                Roles = s.User.UserRoles.Select(role => new RoleDto 
                { 
                    Id = role.Role.Id,
                    Name = role.Role.Name,
                    Description = role.Role.Description,

                }).ToList()
            }).ToList();

            return staffs;
        }

        public async  Task<StaffDto> GetStaffAsync(int id)
        {
            var staff = await _staffRepository.GetStaffAsync(id);
            return new StaffDto 
            {
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Address = staff.Address,
                Email = staff.Email,
                PhoneNumber = staff.PhoneNumber,
                Id = staff.Id,
                StaffCode = staff.StaffCode,
                Roles = staff.User.UserRoles.Select(role => new RoleDto
                {
                    Id = role.Role.Id,
                    Name = role.Role.Name,
                    Description = role.Role.Description

                }).ToList()


            };

        }

        public async Task<StaffDto> GetStaffByStaffcodeAsync(string staffCode)
        {
            var staff = await _staffRepository.GetStaffByStaffcodeAsync(staffCode);
            return new StaffDto
            {
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                Address = staff.Address,
                Email = staff.Email,
                PhoneNumber = staff.PhoneNumber,
                Id = staff.Id,
                StaffCode = staff.StaffCode,
                Roles = staff.User.UserRoles.Select(role => new RoleDto
                {
                    Id = role.Role.Id,
                    Name = role.Role.Name,
                    Description = role.Role.Description,
                }).ToList()
           
            };

        }

        public async  Task<bool> UpdateStaffAsync(int id, UpdateStaffRequestModel model)
        {
            var staff = await _staffRepository.GetStaffAsync(id);
            var user = await _userRepository.GetUserAsync(staff.UserId);

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.PhoneNumber = model.PhoneNumber;
            user.Email = model.Email;
            //user.Password = model.Password;
            user.Address = model.Address;

            staff.FirstName = model.FirstName;
            staff.LastName = model.LastName;
            staff.PhoneNumber = model.PhoneNumber;
            //staff.StaffCode = model.StaffCode;
            staff.Email = model.Email;
            

            await _staffRepository.UpdateStaffAsync(staff);
            await _userRepository.UpdateUserAsync(user);

            return true;
        }   
             

            
        
    }
}
