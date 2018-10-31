using ROR.DataAccess.Mongo;
using System;

namespace ROR.Auth.Interfaces
{
    public interface ITokenRepo
    {
        string createToken(UserDto user);
    }
}
