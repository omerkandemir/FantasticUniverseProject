namespace NLayer.Core.Dto.Abstracts;

public interface IResponse
{
    bool Success { get; }
    string Message { get; }
}
