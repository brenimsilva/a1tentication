using a1tentication.Models;
using Microsoft.EntityFrameworkCore;

namespace a1tentication.Context;

public class AuthContext : DbContext
{
    public AuthContext(DbContextOptions<AuthContext> opts) : base(opts)
    {
        
    } 
    public DbSet<User> Users { get; set; }
    public DbSet<Token> Tokens { get; set; }
}