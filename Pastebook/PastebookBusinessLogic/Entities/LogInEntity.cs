namespace PastebookBusinessLogic.Entities
{
    public class LogInEntity
    {        
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
