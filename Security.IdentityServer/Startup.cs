using IdentityManager.Configuration;
using IdentityServer3.Core.Configuration;
using Owin;
using Security.IdentityServer.Configuration;
using Security.IdentityServer.IdentityManager;

namespace Security.IdentityServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/admin", adminApp =>
            {
                var factory = new IdentityManagerServiceFactory();
                //factory.ConfigureSimpleIdentityManagerService("AspId");
                factory.ConfigureCustomIdentityManagerServiceWithIntKeys("AspId_CustomPK");

                adminApp.UseIdentityManager(new IdentityManagerOptions()
                {
                    Factory = factory,                  
                });
            });

            app.Map("/identity", coreApp =>
            {
                var factory = Factory.Configure("IdentityServerConfig");
                factory.ConfigureUserService("AspId");
                    
                var options = new IdentityServerOptions
                {
                    Factory = factory,
                    SigningCertificate = Cerfificate.LoadCertificate(),
                    SiteName = "Security Server STS",
                    IssuerUri = "https://securityframework/identity",
                    PublicOrigin = "https://localhost:44320",
                    AuthenticationOptions = new AuthenticationOptions
                    {
                        EnablePostSignOutAutoRedirect = true
                    }
                };

                coreApp.UseIdentityServer(options);
            });   
        }
    }
}