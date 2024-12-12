namespace AdminSphere.Models;

public class ErrorResponse
{
    public bool Success { get; set; }
    public string ErrorMessage { get; set; }
    public string Message { get; set; }
    public string AdditionalData { get; set; }
    public List<ValidationError> Errors { get; set; } = new List<ValidationError>(); // Validasyon hataları
}

public class ValidationError
{
    public string PropertyName { get; set; } // Hatalı alanın adı
    public string ErrorMessage { get; set; } // Hata mesajı
}
