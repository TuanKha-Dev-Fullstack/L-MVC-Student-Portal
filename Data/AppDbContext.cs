using L_MVC_Student_Portal.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace L_MVC_Student_Portal.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
}