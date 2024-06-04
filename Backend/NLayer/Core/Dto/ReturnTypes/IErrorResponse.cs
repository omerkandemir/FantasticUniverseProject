namespace NLayer.Core.Dto.ReturnTypes;

public interface IErrorResponse
{
    bool Success { get; }
    string ErrorMessage { get; }
}
