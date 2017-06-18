using GuildWars2.REST.Auth;
using GuildWars2.REST.Authentication;
using GuildWars2.REST.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.REST
{
    public partial class Startup
    {
        public SymmetricSecurityKey signingKey;

        private void ConfigureAuth(IApplicationBuilder app) {

            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.GetSection("TokenAuthentication:SecretKey").Value));
            var signInManager = app.ApplicationServices.GetService(typeof(SignInManager<AppUser>)) as SignInManager<AppUser>;

            var tokenProviderOptions = new TokenProviderOptions {
                Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
                Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = (username, password) => GetIdentity(signInManager, username, password)
            };

            var tokenValidationParameters = new TokenValidationParameters {
                
                ValidateIssuerSigningKey = true,    // The signing key must match!
                IssuerSigningKey = signingKey,      // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,     // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                ValidateLifetime = false,           // Validate the token expiry
                ClockSkew = TimeSpan.Zero           // If you want to allow a certain amount of clock drift, set that here:
            };

            app.UseCookieAuthentication(new CookieAuthenticationOptions {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                AuthenticationScheme = "Cookie",
                CookieName = Configuration.GetSection("TokenAuthentication:CookieName").Value,
                TicketDataFormat = new JwtDataFormat(
                    SecurityAlgorithms.HmacSha256,
                    tokenValidationParameters)
            });

            app.UseJwtBearerAuthentication(new JwtBearerOptions {
                AutomaticAuthenticate = true,
                AutomaticChallenge = true,
                TokenValidationParameters = tokenValidationParameters
            });

            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(tokenProviderOptions));
        }

        private async Task<ClaimsIdentity> GetIdentity(SignInManager<AppUser> signInManager, string username, string password) {
            var result = await signInManager.PasswordSignInAsync(username, password, false, false);
            if (result.Succeeded) {
                return new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { });
            }
            return null;
        }
    }
}
