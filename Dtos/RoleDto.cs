using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

       //public ICollection<UserDto> UserRoles { get; set; } = new List<UserDto>();
    }


    public class CreateRoleRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

       // public ICollection<int> UserId { get; set; } = new List<int>();
    }

    public class UpdateRoleRequestModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

       // public ICollection<int> UserId { get; set; } = new List<int>();
    }

}
