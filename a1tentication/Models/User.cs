using System.ComponentModel.DataAnnotations;

namespace a1tentication.Models;

public class User
{
    [Key] public int UserId { get; set; }
    [StringLength(120)] public Guid UserGuid { get; set; }
    [StringLength(120)] public string UserEmail { get; set; }
    [StringLength(120)] public string UserPassword { get; set; }
    public virtual Token UserToken { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
}