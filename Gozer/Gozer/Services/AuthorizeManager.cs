using Gozer.Configuration;
using Gozer.Contract.Communication;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Gozer.Contract;

namespace Gozer.Services
{
    public class AuthorizeManager : IAuthorizeManager
    {
        private readonly ILogger _logger;
        private readonly GozerServerOptions _options;

        public AuthorizeManager(ILogger<AuthorizeManager> logger, GozerServerOptions options)
        {
            _logger = logger;
            _options = options;
        }

        public bool IsSignitureValid(IServiceDelivery serviceRegister)
        {
            bool isValid = true;

            if (_options.Secrutiy.UseCertificateForRegistration)
            {
                using (RSA rsa = _options.Secrutiy.x509Certificate2.GetRSAPublicKey())
                {
                    var endpointBytes = ASCIIEncoding.ASCII.GetBytes(serviceRegister.EndpointAdress);
                    isValid = rsa.VerifyData(endpointBytes, serviceRegister.Signature, HashAlgorithmName.SHA1,
                        RSASignaturePadding.Pkcs1);
                }
            }

            return isValid;
        }

        public bool IsHostAllowed(IServiceDelivery serviceRegister)
        {
            bool isAllowed = true;

            if (_options.Secrutiy.AllowedHosts.Any())
            {
                Uri myUri = new Uri(serviceRegister.EndpointAdress);
                string host = myUri.Host;

                isAllowed = _options.Secrutiy.AllowedHosts.Any(x => x == host);
            }

            return isAllowed;
        }
    }
}