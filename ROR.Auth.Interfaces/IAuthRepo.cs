using ROR.DataAccess.Mongo.Models;
using System;

namespace ROR.Auth.Interfaces
{
    public interface IAuthRepo
    {
        User Authenticate(User user);        
    }
}
