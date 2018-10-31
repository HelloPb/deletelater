using ROR.Auth.Interfaces;
using ROR.DataAccess.Mongo.Models;
using System;

namespace ROR.Auth.Repo
{
    public class AuthRepo : IAuthRepo
    {
        public User Authenticate(User user)
        {
            User user1 = new User() { AJCP_ID = "" };

            if (user1.AJCP_ID == "")
            {
                user = new User { AJCP_ID = "" };
            }
            return user;
        }
    }
}
