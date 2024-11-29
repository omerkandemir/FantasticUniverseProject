namespace NLayer.Core.Security.Hashing;

public interface IHashingService
{
    string HashPassword(string password);
    bool VerifyPassword(string password, string hashedPassword);
}
