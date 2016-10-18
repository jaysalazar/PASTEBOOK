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
                PASSWORD = userEntityUI.PasswordHash,
                FIRST_NAME = userEntityUI.FirstName,
                LAST_NAME = userEntityUI.LastName,
                GENDER = userEntityUI.Gender,
                EMAIL_ADDRESS = userEntityUI.EmailAddress,
                BIRTHDAY = userEntityUI.Birthday,
                COUNTRY_ID = userEntityUI.CountryId,
                MOBILE_NO = userEntityUI.MobileNumber
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
                PasswordHash = userEntityEF.PASSWORD,
                FirstName = userEntityEF.FIRST_NAME,
                LastName = userEntityEF.LAST_NAME,
                Gender = userEntityEF.GENDER,
                EmailAddress = userEntityEF.EMAIL_ADDRESS,
                Birthday = userEntityEF.BIRTHDAY,
                CountryId = (int)userEntityEF.COUNTRY_ID,
                MobileNumber = userEntityEF.MOBILE_NO
            };

            return userEntityUI;
        }
    }
}