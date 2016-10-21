using System.Security.Cryptography;
using System.Text;

namespace PastebookBusinessLogic.Managers
{
    // source: http://www.codeproject.com/Articles/608860/Understanding-and-Implementing-Password-Hashing
    public class PasswordManager
    {
        HashComputer hashComputer = new HashComputer();

        public string GeneratePasswordHash(string password, out string salt)
        {
            salt = SaltGenerator.GetSaltString();
            string finalString = password + salt;
            return hashComputer.GetPasswordHashAndSalt(finalString);
        }

        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == hashComputer.GetPasswordHashAndSalt(finalString);
        }
    }

    public class HashComputer
    {
        public string GetPasswordHashAndSalt(string message)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Utility.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            // return the hash string to the caller
            return Utility.GetString(resultBytes);
        }
    }

    public class SaltGenerator
    {
        private static RNGCryptoServiceProvider cryptoServiceProvider = null;
        private const int SALT_SIZE = 24;

        static SaltGenerator()
        {
            cryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public static string GetSaltString()
        {
            // Lets create a byte array to store the salt bytes
            byte[] saltBytes = new byte[SALT_SIZE];

            // lets generate the salt in the byte array
            cryptoServiceProvider.GetNonZeroBytes(saltBytes);

            // Let us get some string representation for this salt
            string saltString = Utility.GetString(saltBytes);

            // Now we have our salt string ready lets return it to the caller
            return saltString;
        }
    }

    public static class Utility
    {
        public static byte[] GetBytes(string message)
        {
            return Encoding.ASCII.GetBytes(message);
        }

        public static string GetString(byte[] resultBytes)
        {
            return Encoding.ASCII.GetString(resultBytes);
        }
    }
}