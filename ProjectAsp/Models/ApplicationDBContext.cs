using Microsoft.EntityFrameworkCore;



namespace ProjectAsp.Models;

public class ApplicationDBContext:DbContext
{

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
        
    }
   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Operation>().HasKey(b => new { b.Branch_Id, b.Prouduct_Id });
       
    }
    public DbSet<Company> Companies {get;set;}
       public DbSet<Branch> Branches { get; set;}
       public DbSet<Product> Products{get; set;}
       public DbSet<Operation> Operations {get; set;}
    
}