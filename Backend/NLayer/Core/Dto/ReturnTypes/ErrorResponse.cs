namespace NLayer.Core.Dto.ReturnTypes;

public class ErrorResponse : IErrorResponse
{
    public bool Success => false;
    public string ErrorMessage { get; }

    public ErrorResponse(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}
