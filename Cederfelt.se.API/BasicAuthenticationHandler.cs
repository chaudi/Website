using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cederfelt.se.API
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IConfiguration _config;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            IConfiguration config,
            UrlEncoder urlEncoder, ISystemClock clock) : base(options, logger, urlEncoder, clock)
        {
            _config = config;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing headers");
            }

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];

                var expectedPassword = _config.GetSection("Authentication").GetChildren().First(x => x.Key == "Password").Value;
                var expectedUsername = _config.GetSection("Authentication").GetChildren().First(x => x.Key == "Username").Value;
                if (username == expectedUsername && password == expectedPassword)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, "apiuser") };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return AuthenticateResult.Success(ticket);
                }

                return AuthenticateResult.Fail("Invalid Auth");
            }
            catch (Exception e)
            {
                Logger.LogError(new EventId(1, ""), e, "Exception in AuthenticationHandler");
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }
        }
    }
}
