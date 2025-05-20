namespace WebIEEE.Contracts.Dtos;

public record NewsDto(
    int Id,
    string Title,
    string Description,
    Uri ImageLink,
    string Author,
    DateTime CreatedAt);