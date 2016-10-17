using PastebookBusinessLogic.Entities;
using PastebookEntities;

namespace PastebookBusinessLogic.Mappers
{
    public static class UserMapper
    {
        //modelUI to modelEF
        public static PB_USER MapUserEntityUIToUserEntityEF(LogInEntity userEntityUI)
        {
            PB_USER userEntityEF = new PB_USER()
            {
                USER_NAME = userEntityUI.Username,
                SALT = userEntityUI.Salt,
                PASSWORD = userEntityUI.PasswordHash
            };

            return userEntityEF;
        }

        //modelEF to modelUI
        public static LogInEntity MapUserEntityEFToUserEntityUI(PB_USER userEntityEF)
        {
            LogInEntity userEntityUI = new LogInEntity()
            {
                Username = userEntityEF.USER_NAME,
                Salt = userEntityEF.SALT,
                PasswordHash = userEntityEF.PASSWORD
            };

            return userEntityUI;
        }
    }
}