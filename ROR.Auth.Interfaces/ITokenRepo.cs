using ROR.DataAccess.Mongo.Models;
using System;

namespace ROR.Auth.Interfaces
{
    public interface ITokenRepo
    {
        string createToken(User user);
    }
}
