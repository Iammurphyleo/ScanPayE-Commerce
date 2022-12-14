using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Dtos
{
    public class BaseResponse<T>
    {

        public bool Successful { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
    }
}
