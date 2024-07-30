using AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Buyer, BuyerDto>().ReverseMap();
    }
}
