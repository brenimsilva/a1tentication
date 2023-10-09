using System.ComponentModel.DataAnnotations;
using a1tentication.Models.DTO.Request;
using a1tentication.Util;

namespace a1tentication.Models;

public class User
{
    [Key] public int UserId { get; set; }
    [StringLength(120)] public Guid UserGuid { get; set; }
    [StringLength(34)] public string Name { get; set; }
    [StringLength(120)] public string UserEmail { get; set; }
    [StringLength(120)] public string UserPassword { get; set; }
    public virtual Token? UserToken { get; set; } = null;
    public DateTime dt_nasc { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }

    public User()
    {
        
    }
    public User(UserRequestDTO dto)
    {
        this.UserGuid = Guid.NewGuid();
        this.Name = dto.Name;
        this.UserEmail = dto.UserEmail;
        this.UserPassword = StringUtilities.Hash(dto.UserPassword);
        this.dt_nasc = dto.dt_nasc;
        this.created_at = DateTime.Now;
        this.updated_at = DateTime.Now;
    }

    public User(string name, string email, string password, DateTime dt_nasc)
    {
        this.UserGuid = Guid.NewGuid();
        this.Name = name;
        this.UserEmail = email;
        this.UserPassword = StringUtilities.Hash(password);
        this.dt_nasc = dt_nasc;
        this.created_at = DateTime.Now;
        this.updated_at = DateTime.Now;
    }
}
    
