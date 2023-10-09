using a1tentication.Context;
using a1tentication.Models;
using a1tentication.Models.DTO.Response;
using Microsoft.EntityFrameworkCore;

namespace a1tentication.Services;

public class AuthService 
{
    AuthContext _ctx;
    
    public AuthService(AuthContext ctx) {
        this._ctx = ctx;
    }

    public async Task<UserResponseDTO> LogIn(string email, string senha)
    {
        string senhaCrypto = Util.StringUtilities.Hash(senha);
        User u = await _ctx.Users.Include(e => e.UserToken).FirstOrDefaultAsync(e => e.UserEmail == email && e.UserPassword == senhaCrypto);
        var t = await SetToken(u);
        UserResponseDTO res = new UserResponseDTO
        {
            UserToken = u.UserToken.TokenGuid,
            UserEmail = u.UserEmail,
            created_at = u.created_at,
            dt_nasc = u.dt_nasc,
            Name = u.Name
        };
        await _ctx.SaveChangesAsync();
        return res;
    }
    public async Task<UserResponseDTO> LogInByToken(Guid token)
    {
        User u = await _ctx.Users.Include(e => e.UserToken).FirstOrDefaultAsync(e => e.UserToken.TokenGuid == token);
        if (u.UserToken.expires_at < DateTime.Now || u is null)
        {
            throw new Exception("Token Expirado ou Nao encontrado");
        }
        var t = await SetToken(u);
        UserResponseDTO res = new UserResponseDTO
        {
            UserToken = u.UserToken.TokenGuid,
            UserEmail = u.UserEmail,
            created_at = u.created_at,
            dt_nasc = u.dt_nasc,
            Name = u.Name
        };
        await _ctx.SaveChangesAsync();
        return res;
    }

    public async Task<bool> CheckToken(Guid token) {
        Token t = await _ctx.Tokens.FirstOrDefaultAsync(e => e.TokenGuid == token);
        if(t is not null && t.expires_at > DateTime.Now) {
            return true;
        }
        return false;
    }

    public async Task<Token> SetToken(User user) {
        Guid randomguid = Guid.NewGuid();
        Token t = new Token()
        {
            TokenId = 0,
            TokenGuid = randomguid,
            expires_at = DateTime.Now.AddMinutes(5),
            UserId = user.UserId
        };
        await _ctx.Tokens.AddAsync(t);
        return t;
    }
}