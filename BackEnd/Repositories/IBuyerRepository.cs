using System.Collections.Generic;
using System.Threading.Tasks;

public interface IBuyerRepository
{
    Task<List<Buyer>> GetBuyersAsync(int page, string search);
    Task<Buyer> GetBuyerByIdAsync(int id);
    Task AddBuyerAsync(Buyer buyer);
    Task UpdateBuyerAsync(Buyer buyer);
    Task<bool> EmailExistsAsync(string email);
    Task<bool> CpfCnpjExistsAsync(string cpfCnpj);
    Task<bool> StateRegistrationExistsAsync(string stateRegistration);
}
