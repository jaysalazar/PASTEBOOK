using System.Security.Cryptography;

namespace PastebookBusinessLogic.BusinessLogic
{
    // sources: http://www.codeproject.com/Articles/608860/Understanding-and-Implementing-Password-Hashing
    //          https://www.owasp.org/index.php/.NET_Security_Cheat_Sheet
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
}