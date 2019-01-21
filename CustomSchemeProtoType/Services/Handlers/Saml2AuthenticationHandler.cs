using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
namespace CustomSchemeProtoType.Services.Handlers
{
    public class Saml2AuthenticationHandler : AuthenticationHandler<Saml2AuthenticationSchemeOptions>
    {
        public IServiceProvider ServiceProvider { get; set; }

        public Saml2AuthenticationHandler(IOptionsMonitor<Saml2AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IServiceProvider serviceProvider)
            : base(options, logger, encoder, clock)
        {
            ServiceProvider = serviceProvider;
        }
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {

            var headers = Request.Headers;
        
            
            // check saml2 assertions

            var claims = new[] { new Claim("saml2", "true") };
            var identity = new ClaimsIdentity(claims, nameof(Saml2AuthenticationHandler));
            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identity), this.Scheme.Name);
            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}