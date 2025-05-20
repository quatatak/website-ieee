using WebIEEE.Contracts.Dtos;

namespace WebIEEE.Contracts.Responses;

public record GetNewsResponse(List<NewsDto> NewsDtos);