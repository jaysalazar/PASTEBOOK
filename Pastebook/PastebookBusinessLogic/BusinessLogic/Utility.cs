using System.Text;

namespace PastebookBusinessLogic.BusinessLogic
{
    // source: http://www.codeproject.com/Articles/608860/Understanding-and-Implementing-Password-Hashing
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