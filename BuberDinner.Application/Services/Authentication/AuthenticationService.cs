using BuberDinner.Application.Common.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    public AuthenticationResult Login(string email, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), "first", "last","email@email.com", "token");
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        //check if user already exists
        
        //create user(generate unique id)
        
        //create jwt
        var token = _jwtTokenGenerator.GenerateToken(Guid.NewGuid(), firstName, lastName);
        
        return new AuthenticationResult(Guid.NewGuid(), "first", "last","email@email.com", token);
    }
}