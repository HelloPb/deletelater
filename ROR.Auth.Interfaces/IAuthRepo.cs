using ROR.DataAccess.Mongo;
using System;

namespace ROR.Auth.Interfaces
{
    public interface IAuthRepo
    {
        UserDto Authenticate(UserDto user);        
    }
}
