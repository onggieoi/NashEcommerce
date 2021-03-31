using System.Collections.Generic;
using backend.Configs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace backend.Extensions.ServiceCollection
{
    public static class IdentityServerRegister
    {
        public static void AddIdentityServerCustom(this IServiceCollection services,
            Dictionary<string, string> clientUrls)
        {
            services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            .AddInMemoryIdentityResources(IdentityServerConfig.Ids)
            .AddInMemoryApiResources(IdentityServerConfig.Apis)
            .AddInMemoryClients(IdentityServerConfig.Clients(clientUrls))
            .AddDeveloperSigningCredential();
        }
    }
}