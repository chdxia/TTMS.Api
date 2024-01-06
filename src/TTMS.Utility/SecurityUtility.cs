using System.Security.Cryptography;
using System.Text;

namespace TTMS.Utility
{
    public static class SecurityUtility
    {
        public static string HashWithSalt(string input, string salt)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] saltBytes = Convert.FromBase64String(salt);

            byte[] combinedBytes = new byte[inputBytes.Length + saltBytes.Length];
            Buffer.BlockCopy(inputBytes, 0, combinedBytes, 0, inputBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, combinedBytes, inputBytes.Length, saltBytes.Length);

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] hashBytes = sha256Hash.ComputeHash(combinedBytes);
                string hashedValue = Convert.ToBase64String(hashBytes);
                return hashedValue;
            }
        }

        public static (string hashedValue, string salt) HashWithNewSalt(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] saltBytes = new byte[16]; // 生成16字节的盐值
            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes); // 填充盐值字节数组
            }

            byte[] combinedBytes = new byte[inputBytes.Length + saltBytes.Length];
            Buffer.BlockCopy(inputBytes, 0, combinedBytes, 0, inputBytes.Length);
            Buffer.BlockCopy(saltBytes, 0, combinedBytes, inputBytes.Length, saltBytes.Length);

            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] hashBytes = sha256Hash.ComputeHash(combinedBytes);
                string hashedValue = Convert.ToBase64String(hashBytes);
                string salt = Convert.ToBase64String(saltBytes); // 将盐值转换为Base64字符串
                return (hashedValue, salt);
            }
        }

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}