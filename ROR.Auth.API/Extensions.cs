using Microsoft.Extensions.DependencyInjection;
using ROR.Auth.Interfaces;
using ROR.Auth.Repo;
using ROR.DataAccess.Mongo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROR.Auth.API
{
    public static class Extensions
    {
        /// <summary>
        /// Registers the types for DI.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddDI(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepo, AuthRepo>();
            services.AddScoped<ITokenRepo, JwtRepo>();
            services.AddScoped<UserRepo>();
        }
    }
}
