using Microsoft.EntityFrameworkCore;

public class BuyerDbContext : DbContext
{
    public BuyerDbContext(DbContextOptions<BuyerDbContext> options) : base(options) { }

    public DbSet<Buyer> Buyers { get; set; }
}
