using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccces;

public class EfDbContext: DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;
                                          Database=SoapToRestDb;
                                          User Id= SA;
                                          Password=1245a22521A;
                                          TrustServerCertificate=True;
                                          Encrypt=false");
    }

    public DbSet<Account> Accounts { get; set; }
}