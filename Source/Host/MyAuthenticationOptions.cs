using Microsoft.AspNetCore.Authentication;

namespace Host.Code;

public class MyAuthenticationOptions : AuthenticationSchemeOptions
{
    public const string DefaultScheme = "MyAuthenticationScheme";
    public string TokenHeaderName { get; set; } = "X-AuthToken";
}