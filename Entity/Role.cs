﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
       public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
