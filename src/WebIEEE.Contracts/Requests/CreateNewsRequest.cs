namespace WebIEEE.Contracts.Requests;

public record CreateNewsRequest(string Title, string Description, string Author, Uri ImageLink);