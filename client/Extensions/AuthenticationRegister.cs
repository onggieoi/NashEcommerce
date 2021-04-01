using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace client.Extensions
{
    public static class AuthenticationRegister
    {
        public static void AddAuthenticationCustom(this IServiceCollection services, IConfiguration config)
        {
            var backendUrl = config.GetValue<string>("BackEndUrl");

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = backendUrl;
                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    // options.TokenValidationParameters = new TokenValidationParameters
                    // {
                    //     ValidateIssuer = true
                    // };

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.Scope.Add("testScope");
                    options.Scope.Add("offline_access");

                    options.ClaimActions.MapUniqueJsonKey("TestedScope", "testScope");

                    options.Events = new OpenIdConnectEvents
                    {
                        OnRemoteFailure = context =>
                        {
                            context.Response.Redirect("/");
                            context.HandleResponse();

                            return Task.CompletedTask;
                        },
                        OnAuthorizationCodeReceived = context =>
                        {
                            return Task.CompletedTask;
                        },
                        OnTicketReceived = context =>
                        {
                            return Task.CompletedTask;
                        },
                    };

                });
        }
    }
}