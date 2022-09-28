using Scanpay.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.AuthenticationAndAuthorization
{
    public interface IJwtAuthenticationManager
    {
        public string GenerateToken(UserDto user);
    }
}
