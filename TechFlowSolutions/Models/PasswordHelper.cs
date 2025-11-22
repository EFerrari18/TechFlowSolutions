using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Models
{
    public static class PasswordHelper
    {
        public static string Hash(string senha)
        {
            using var sha = SHA256.Create();
            return Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(senha)));
        }

        public static bool Verify(string senha, string hash)
        {
            return Hash(senha) == hash;
        }
    }
}
