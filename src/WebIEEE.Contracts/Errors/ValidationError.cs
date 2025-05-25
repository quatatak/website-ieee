using System.Runtime;

namespace WebIEEE.Contracts.Errors;

public class ValidationError
{
    public string PropertyName { get; set; }
    public string ErrorMessage { get; set; }
}