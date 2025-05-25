namespace WebIEEE.Contracts.Requests;

public record UpdateNewsRequest(int Id, string Title, string Description, string Author, Uri ImageLink);