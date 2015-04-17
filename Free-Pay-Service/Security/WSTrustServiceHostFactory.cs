using System;
using System.Collections.Generic;
using System.IdentityModel.Configuration;
using System.IdentityModel.Tokens;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Security;
using System.Web;

namespace FreePayService.Security
{
    public class WSTrustServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            var config = new UserSecurityTokenServiceConfiguration();
            var host = new WSTrustServiceHost(config, baseAddresses);
            return host;
        }
        public override ServiceHostBase CreateServiceHost(string constructorString, Uri[] baseAddresses)
        {
            var config = new UserSecurityTokenServiceConfiguration();
            var host = new WSTrustServiceHost(config, baseAddresses);
            return host;
        }

    }
}