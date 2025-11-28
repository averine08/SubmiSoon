
namespace SubmiSoonApi.Services
{
    public class PasswordService
    {
        // Hash password pakai BCrypt
        public string Hash(string password)
        {
            // workFactor default bisa 10, cukup aman
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 10);
        }

        // Verifikasi password
        public bool Verify(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(password, passwordHash);
        }
    }
}
