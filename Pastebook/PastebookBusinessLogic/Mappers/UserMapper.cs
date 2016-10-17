using PastebookBusinessLogic.Entities;
using PastebookDataAccess;

namespace PastebookBusinessLogic.Mappers
{
    public static class UserMapper
    {
        //modelUI to modelEF
        public static PB_USER MapUserEntityUIToUserEntityEF(UserEntity userEntityUI)
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
        public static UserEntity MapUserEntityEFToUserEntityUI(PB_USER userEntityEF)
        {
            UserEntity userEntityUI = new UserEntity()
            {
                Username = userEntityEF.USER_NAME,
                Salt = userEntityEF.SALT,
                PasswordHash = userEntityEF.PASSWORD
            };

            return userEntityUI;
        }
    }
}