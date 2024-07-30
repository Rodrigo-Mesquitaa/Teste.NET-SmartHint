using System.Threading.Tasks;

public interface IBuyerService
{
    Task<PagedResult<BuyerDto>> GetBuyersAsync(int page, string search);
    Task<BuyerDto> GetBuyerByIdAsync(int id);
    Task AddBuyerAsync(BuyerDto buyerDto);
    Task UpdateBuyerAsync(int id, BuyerDto buyerDto);
}
