using System;
using System.Security.Cryptography.X509Certificates;

namespace Security.IdentityServer.Configuration
{
    public class Cerfificate
    {
        public static X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                string.Format(@"{0}\Certificates\idsrv3test.pfx",
                AppDomain.CurrentDomain.BaseDirectory), "idsrv3test");
        }
    }
}