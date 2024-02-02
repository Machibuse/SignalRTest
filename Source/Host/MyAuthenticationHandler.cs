using System.Security.Claims;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace Host.Code;

public class MyAuthenticationHandler : AuthenticationHandler<MyAuthenticationOptions>
{
    public MyAuthenticationHandler(IOptionsMonitor<MyAuthenticationOptions> options, ILoggerFactory logger, UrlEncoder encoder) : base(options, logger, encoder)
    {
    }

    protected override Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(Options.TokenHeaderName, out var token))
        {
            return Task.FromResult(AuthenticateResult.Fail("Login invalid - no token"));
        }

        string? username = token;

        if (username == null)
        {
            return Task.FromResult(AuthenticateResult.Fail("Login invalid - no user"));
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, username)
        };

        var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(claims, Scheme.Name));

        return Task.FromResult(AuthenticateResult.Success(new AuthenticationTicket(claimsPrincipal, Scheme.Name)));
    }
}