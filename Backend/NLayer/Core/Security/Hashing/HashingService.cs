namespace NLayer.Core.Security.Hashing;

public class HashingService : IHashingService
{
    public string HashPassword(string password)
    {
        // Şifreyi hash'ler
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hashedPassword)
    {
        // Şifreyi doğrular
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
