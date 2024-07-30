using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BuyerRepository : IBuyerRepository
{
    private readonly BuyerDbContext _context;

    public BuyerRepository(BuyerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Buyer>> GetBuyersAsync(int page, string search)
    {
        return await _context.Buyers
            .Where(b => string.IsNullOrEmpty(search) || b.Name.Contains(search) || b.Email.Contains(search))
            .Skip((page - 1) * 20)
            .Take(20)
            .ToListAsync();
    }

    public async Task<Buyer> GetBuyerByIdAsync(int id)
    {
        return await _context.Buyers.FindAsync(id);
    }

    public async Task AddBuyerAsync(Buyer buyer)
    {
        _context.Buyers.Add(buyer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBuyerAsync(Buyer buyer)
    {
        _context.Entry(buyer).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Buyers.AnyAsync(b => b.Email == email);
    }

    public async Task<bool> CpfCnpjExistsAsync(string cpfCnpj)
    {
        return await _context.Buyers.AnyAsync(b => b.CpfCnpj == cpfCnpj);
    }

    public async Task<bool> StateRegistrationExistsAsync(string stateRegistration)
    {
        return await _context.Buyers.AnyAsync(b => b.StateRegistration == stateRegistration);
    }
}
