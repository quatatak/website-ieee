using Mapster;
using WebIEEE.Contracts.Responses;
using WebIEEE.Domain.Entities;

namespace WebIEEE.Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<News>, GetNewsResponse>.NewConfig()
            .Map(dest => dest.NewsDtos, src => src);
    }
    
}