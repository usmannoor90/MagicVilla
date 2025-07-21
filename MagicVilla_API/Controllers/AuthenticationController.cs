using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MagicVilla_API.Controllers;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[AllowAnonymous]
[ApiVersion("2.0", Deprecated = true)]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthenticationController(IConfiguration config)
    {
        _config = config;
    }

    public record AuthenticationData(string? UserName, string? Password);
    public record UserData(int UserId, string UserName, string Title, string EmployeeId);
    // api/Authentication/token
    [HttpPost("token")]
    public ActionResult<string> Authenticate([FromBody] AuthenticationData body)
    {
        var user = ValidateCrendetials(body);
        if (user == null)
        {
            return Unauthorized();
        }
        var token = GenerateToken(user);
        return Ok(token);
    }

    private string GenerateToken(UserData user)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetValue<string>("Authentication:SecretKey")));

        var signingCrendentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new();
        claims.Add(new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()));
        claims.Add(new(JwtRegisteredClaimNames.UniqueName, user.UserName));
        claims.Add(new("title", user.Title));
        claims.Add(new("employeeId", user.EmployeeId));

        var token = new JwtSecurityToken(
            _config.GetValue<string>("Authentication:Issuer"),
            _config.GetValue<string>("Authentication:Audience"),
            claims,
            DateTime.UtcNow, // when this token is created
            DateTime.UtcNow.AddMinutes(1), // when this token will expire i.e, after one minute.
            signingCrendentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private UserData? ValidateCrendetials(AuthenticationData data)
    {
        // this is not production code this only a demo and do not use in the real life applications.
        if (CompareValue(data.UserName, "usman") && CompareValue(data.Password, "Test123"))
        {
            return new UserData(1, data.UserName!, "Business Owner", "E001");

        }
        if (CompareValue(data.UserName, "storm") && CompareValue(data.Password, "Test123"))
        {
            return new UserData(2, data.UserName!, "head of Security", "E002");

        }
        return null;
    }

    private bool CompareValue(string? actual, string? expected)
    {
        if (actual is not null)
        {
            if (actual.Equals(expected))
            {
                return true;
            }
        }
        return false;

    }
}
