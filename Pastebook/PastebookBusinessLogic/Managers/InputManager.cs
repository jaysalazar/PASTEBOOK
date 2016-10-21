namespace PastebookBusinessLogic.Managers
{
    public static class InputManager
    {
        public static string Trim(string input)
        {
            return input.Trim();
        }

        public static string Capitalize(string name)
        {
            return name.Substring(0, 1).ToUpper() + name.Substring(1);
        }
    }
}
