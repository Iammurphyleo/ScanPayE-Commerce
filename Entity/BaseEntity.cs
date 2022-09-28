using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime Datecreated { get; set; } = DateTime.Now;

        public DateTime DateModified { get; set; }

        public bool IsDeleted { get; set; }
    }
}
