using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class StaffDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string StaffCode { get; set; }
        public IList<RoleDto> Roles { get; set; } = new List<RoleDto>();

        //public int UserId { get; set; }

    }

    public class CreateStaffRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        //public string StaffCode { get; set; }

        //public string Password { get; set; }

        public int UserId { get; set; }

        public IList<int> RoleIds { get; set; } = new List<int>();



    }

    public class UpdateStaffRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        //public string StaffCode { get; set; }

        //public string Password { get; set; }

        

        

       

       
    }
}
