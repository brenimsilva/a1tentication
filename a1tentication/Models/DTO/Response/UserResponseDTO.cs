namespace a1tentication.Models.DTO.Response;

public class UserResponseDTO
{
    public string Name { get; set; }
    public string UserEmail { get; set; }
    public Guid? UserToken { get; set; } = null;
    public DateTime dt_nasc { get; set; }
    public DateTime created_at { get; set; }
}