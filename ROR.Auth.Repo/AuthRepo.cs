using ROR.Auth.Interfaces;
using ROR.DataAccess.Mongo;
using System;

namespace ROR.Auth.Repo
{
    public class AuthRepo : IAuthRepo
    {
        private UserRepo _userRepo;

        public AuthRepo(UserRepo userRepo)
        { 
            _userRepo = userRepo;
        }

        public UserDto Authenticate(UserDto user)
        {
            var u = _userRepo.get(user.ajc_pid);

            if (user.ajc_pid == u.AJC_PID && user.password == u.PASSWORD)
            {
                user = new UserDto { ajc_pid = u.AJC_PID, password = u.PASSWORD, person_code = u.PERSON_CODE };
            } 

            return user;
        }
    }
}
