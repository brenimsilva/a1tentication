using a1tentication.Context;
using a1tentication.Models;
using a1tentication.Models.DTO.Request;
using a1tentication.Models.DTO.Response;
using Microsoft.EntityFrameworkCore;

namespace a1tentication.Services;

public class UserService
{
    private AuthContext _ctx;

    public UserService(AuthContext ctx)
    {
        this._ctx = ctx;
    }

    public async Task<UserResponseDTO> GetUserByGuid(Guid guid)
    {
        User u = await _ctx.Users.FirstOrDefaultAsync(e => e.UserGuid == guid);
        UserResponseDTO res = new UserResponseDTO()
        {
            UserToken = u.UserToken.TokenGuid,
            UserEmail = u.UserEmail,
            created_at = u.created_at,
            dt_nasc = u.dt_nasc,
            Name = u.Name
        };
        return res;
    }

    public async Task<UserResponseDTO> CreateNewUser(UserRequestDTO user)
    {
        User u = new User(user);
        await _ctx.Users.AddAsync(u);
        await _ctx.SaveChangesAsync();
        UserResponseDTO res = new UserResponseDTO
        {
            UserToken = u.UserToken?.TokenGuid,
            UserEmail = u.UserEmail,
            created_at = u.created_at,
            dt_nasc = u.dt_nasc,
            Name = u.Name
        };
        return res;
    }
}