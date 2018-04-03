using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Gozer.Options
{
    public class Secrutiy
    {
        public List<string> AllowedHosts { get; set; }
        public X509Certificate2 x509Certificate2 { get; set; }
        public bool UseCertificateForRegistration { get; set; }

        public Secrutiy()
        {
            AllowedHosts = new List<string>();
            UseCertificateForRegistration = false;
            x509Certificate2 = null;
        }
    }
}
