namespace NLayer.Core.Dto.ReturnTypes;

public class SuccessResponse : IErrorResponse
{
    public object Data { get; }
    public bool Success => true;
    public string ErrorMessage => null;

    public SuccessResponse(object data)
    {
        Data = data;
    }
    
}
