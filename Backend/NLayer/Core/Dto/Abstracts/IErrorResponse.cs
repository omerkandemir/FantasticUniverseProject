namespace NLayer.Core.Dto.Abstracts;

public interface IErrorResponse : IResponse
{
    string ErrorMessage { get; }
}
