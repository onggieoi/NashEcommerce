using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Net.Http;
using IdentityModel.Client;

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
                .AddCookie("Cookies", options =>
                {
                    options.Events = new CookieAuthenticationEvents
                    {
                        OnValidatePrincipal = async cookieCtx =>
                        {
                            var now = DateTimeOffset.UtcNow;
                            var expiresAt = cookieCtx.Properties.GetTokenValue("expires_at");
                            var accessTokenExpiration = DateTimeOffset.Parse(expiresAt);
                            var timeRemaining = accessTokenExpiration.Subtract(now);
                            // TODO: Get this from configuration with a fall back value.
                            var refreshThresholdMinutes = 10;
                            var refreshThreshold = TimeSpan.FromMinutes(refreshThresholdMinutes);

                            if (timeRemaining < refreshThreshold)
                            {
                                var discoveryDocument = await new HttpClient().GetDiscoveryDocumentAsync(backendUrl);

                                var refreshToken = cookieCtx.Properties.GetTokenValue("refresh_token");

                                var response = await new HttpClient().RequestRefreshTokenAsync(new RefreshTokenRequest
                                {
                                    Address = discoveryDocument.TokenEndpoint,
                                    ClientId = "mvc",
                                    ClientSecret = "secret",
                                    RefreshToken = refreshToken
                                });

                                if (!response.IsError)
                                {
                                    var expiresInSeconds = response.ExpiresIn;
                                    var updatedExpiresAt = DateTimeOffset.UtcNow.AddSeconds(expiresInSeconds);
                                    cookieCtx.Properties.UpdateTokenValue("expires_at", updatedExpiresAt.ToString());
                                    cookieCtx.Properties.UpdateTokenValue("access_token", response.AccessToken);
                                    cookieCtx.Properties.UpdateTokenValue("refresh_token", response.RefreshToken);

                                    cookieCtx.ShouldRenew = true;
                                }
                                else
                                {
                                    cookieCtx.RejectPrincipal();
                                    await cookieCtx.HttpContext.SignOutAsync("Cookies");
                                }
                            }
                        }
                    };
                })
                .AddOpenIdConnect("oidc", options =>
                {
                    options.Authority = backendUrl;
                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = "name",
                        RoleClaimType = "role"
                    };

                    options.SaveTokens = true;
                    options.GetClaimsFromUserInfoEndpoint = true;
                    options.UseTokenLifetime = false;

                    options.Scope.Add("testScope");
                    options.Scope.Add("offline_access");
                    options.Scope.Add("api");

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