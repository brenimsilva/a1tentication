namespace a1tentication.Models.DTO.Response;

public class UserResponseDTO
{
    public string Name { get; set; }
    public string UserEmail { get; set; }
    public Guid UserGuid { get; set; }
    public Guid? UserToken { get; set; } = null;
    public DateTime dt_nasc { get; set; }
    public DateTime created_at { get; set; }
    
    public UserResponseDTO() {}

    public UserResponseDTO(User u)
    {
        this.UserToken = u.UserToken.TokenGuid;
        this.UserGuid = u.UserGuid;
        UserEmail = u.UserEmail;
        created_at = u.created_at;
        dt_nasc = u.dt_nasc;
        Name = u.Name;
    }
}