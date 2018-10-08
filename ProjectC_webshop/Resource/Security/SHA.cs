using System.Text;
using System.Security.Cryptography;

namespace Security
{
    public class SHA
    {
        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        public static bool Checkpassword(string password, string salt, string passwordUitDB)
        {
            string hashedpassword = GenerateSHA512String(salt + password);

            if (hashedpassword == passwordUitDB)
            {
                return true;
            }

            return false;
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }
    }
}