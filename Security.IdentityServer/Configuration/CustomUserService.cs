using IdentityServer3.AspNetIdentity;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Security.IdentityServer.AspNetIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Security.IdentityServer.Configuration
{
    public static class CustomUserServiceExtensions
    {
        public static void ConfigureCustomUserService(this IdentityServerServiceFactory factory, string connString)
        {
            factory.UserService = new Registration<IUserService, CustomUserService>();
            factory.Register(new Registration<CustomUserManager>());
            factory.Register(new Registration<CustomUserStore>());
            factory.Register(new Registration<CustomContext>(resolver => new CustomContext(connString)));
        }
    }

    public class CustomUserService : AspNetIdentityUserService<CustomUser, int>
    {
        public CustomUserService(CustomUserManager userMgr)
            : base(userMgr)
        {
        }
    }
}