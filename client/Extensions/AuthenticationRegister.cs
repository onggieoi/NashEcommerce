using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace client.Extensions
{
    public static class AuthenticationRegister
    {
        public static void AddAuthenticationCustom(this IServiceCollection services, IConfiguration config)
        {
            var backendUrl = config.GetValue<string>("BackEndUrl");

            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            services.AddAuthentication(options =>
                {
                    options.DefaultScheme = "Cookies";
                    options.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies", options =>
                {
                    options.Cookie.Name = "MVC";
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = backendUrl;
                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true
                    };

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                });
        }
    }
}