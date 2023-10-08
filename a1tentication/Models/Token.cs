using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace a1tentication.Models;

public class Token
{
    [Key] public int TokenId { get; set; }
    [StringLength(120)] public string TokenGuid { get; set; }
    [ForeignKey("User")] public int UserId { get; set; }
    public DateTime expires_at { get; set; }
}