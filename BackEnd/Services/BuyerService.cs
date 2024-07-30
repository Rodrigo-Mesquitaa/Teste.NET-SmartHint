using AutoMapper;
using System.Threading.Tasks;

public class BuyerService : IBuyerService
{
    private readonly IBuyerRepository _repository;
    private readonly IMapper _mapper;

    public BuyerService(IBuyerRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<PagedResult<BuyerDto>> GetBuyersAsync(int page, string search)
    {
        var buyers = await _repository.GetBuyersAsync(page, search);
        var buyerDtos = _mapper.Map<List<BuyerDto>>(buyers);

        return new PagedResult<BuyerDto>
        {
            Results = buyerDtos,
            Total = buyers.Count
        };
    }

    public async Task<BuyerDto> GetBuyerByIdAsync(int id)
    {
        var buyer = await _repository.GetBuyerByIdAsync(id);
        return _mapper.Map<BuyerDto>(buyer);
    }

    public async Task AddBuyerAsync(BuyerDto buyerDto)
    {
        if (await _repository.EmailExistsAsync(buyerDto.Email))
            throw new ArgumentException("E-mail já cadastrado.");

        if (await _repository.CpfCnpjExistsAsync(buyerDto.CpfCnpj))
            throw new ArgumentException("CPF/CNPJ já cadastrado.");

        if (!string.IsNullOrEmpty(buyerDto.StateRegistration) && await _repository.StateRegistrationExistsAsync(buyerDto.StateRegistration))
            throw new ArgumentException("Inscrição Estadual já cadastrada.");

        var buyer = _mapper.Map<Buyer>(buyerDto);
        await _repository.AddBuyerAsync(buyer);
    }

    public async Task UpdateBuyerAsync(int id, BuyerDto buyerDto)
    {
        if (id != buyerDto.Id)
            throw new ArgumentException("ID não corresponde.");

        if (await _repository.EmailExistsAsync(buyerDto.Email))
            throw new ArgumentException("E-mail já cadastrado.");

        if (await _repository.CpfCnpjExistsAsync(buyerDto.CpfCnpj))
            throw new ArgumentException("CPF/CNPJ já cadastrado.");

        if (!string.IsNullOrEmpty(buyerDto.StateRegistration) && await _repository.StateRegistrationExistsAsync(buyerDto.StateRegistration))
            throw new ArgumentException("Inscrição Estadual já cadastrada.");

        var buyer = _mapper.Map<Buyer>(buyerDto);
        buyer.Id = id;
        await _repository.UpdateBuyerAsync(buyer);
    }
}
