using IdentityManager;
using IdentityManager.AspNetIdentity;
using IdentityManager.Configuration;
using Security.IdentityServer.AspNetIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Security.IdentityServer.IdentityManager
{
    public static class CustomIdentityManagerServiceWithIntKeysExtensions
    {
        public static void ConfigureCustomIdentityManagerServiceWithIntKeys(this IdentityManagerServiceFactory factory, string connectionString)
        {
            factory.Register(new Registration<CustomContext>(resolver => new CustomContext(connectionString)));
            factory.Register(new Registration<CustomUserStore>());
            factory.Register(new Registration<CustomRoleStore>());
            factory.Register(new Registration<CustomUserManager>());
            factory.Register(new Registration<CustomRoleManager>());
            factory.IdentityManagerService = new Registration<IIdentityManagerService, CustomIdentityManagerServiceWithIntKeys>();
        }
    }

    public class CustomIdentityManagerServiceWithIntKeys : AspNetIdentityManagerService<CustomUser, int, CustomRole, int>
    {
        public CustomIdentityManagerServiceWithIntKeys(CustomUserManager userMgr, CustomRoleManager roleMgr)
            : base(userMgr, roleMgr)
        {
        }
    }
}