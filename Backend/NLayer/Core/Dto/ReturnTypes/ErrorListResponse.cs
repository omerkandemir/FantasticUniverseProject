using NLayer.Core.Dto.Abstracts;

namespace NLayer.Core.Dto.ReturnTypes;

public class ErrorListResponse : IErrorResponse
{
    public bool Success => false;
    public string ErrorMessage { get; }
    public ErrorListResponse(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}
