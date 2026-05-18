using Microsoft.EntityFrameworkCore;
using StudentCRUD.Models.Entities;

namespace StudentCRUD.Models.Context;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasData(
            new Student {Id = 1, FirstName = "Shivang", LastName = "Chauhan", Age = 22, Address = "Vadodara, Gujarat", Mobile = "9313193998"},
            new Student {Id = 2, FirstName = "Bhautik", LastName = "Ranpara", Age = 22, Address = "Rajkot, Gujarat", Mobile = "9313193998"},
            new Student {Id = 3, FirstName = "Meet", LastName = "Rajpal", Age = 21, Address = "Rajkot, Gujarat", Mobile = "9313193998"},
            new Student {Id = 4, FirstName = "Sujal", LastName = "Myatra", Age = 21, Address = "Kutch, Gujarat", Mobile = "9313193998"}
        );
    }
}