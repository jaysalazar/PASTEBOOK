using PastebookBusinessLogic.BusinessLogic;
using PastebookBusinessLogic.Entities;
using PastebookWebApplication.Mappers;
using PastebookWebApplication.Models;
using System.Collections.Generic;

namespace PastebookWebApplication.Managers
{
    public class PasteBookManager
    {
        LogInManager logInManager = new LogInManager();
        PasswordManager passwordManager = new PasswordManager();
        CountryManager countryManager = new CountryManager();

        public int CreateUser(UserModel userModel)
        {
            UserEntity userEntity = new UserEntity();

            string salt = "";
            userModel.PasswordHash = passwordManager.GeneratePasswordHash(userModel.PasswordHash, out salt);
            userModel.Salt = salt;
            
            userEntity = UserMapper.MapUserModelToUserEntity(userModel);

            int result = logInManager.CreateUser(userEntity);

            return result;
        }

        public UserModel RetrieveUser(string emailAddress)
        {
            UserModel userModel = new UserModel();
            UserEntity userEntity = new UserEntity();

            userEntity = logInManager.RetrieveUser(emailAddress);

            userModel = UserMapper.MapUserEntityToUserModel(userEntity);

            return userModel;
        }

        public List<CountryModel> RetrieveAllCountries()
        {
            List<CountryEntity> countryList = new List<CountryEntity>();
            CountryModel countryModel = new CountryModel();
            List<CountryModel> Countries = new List<CountryModel>();

            countryList = countryManager.RetrieveAllCountries();

            foreach (var country in countryList)
            {
                countryModel = CountryMapper.MapCountryEntityEFToCountryEntityUI(country);
                Countries.Add(countryModel);
            }

            return Countries;
        }

        public bool CheckEmailAddress(string emailAddress)
        {
            bool result = logInManager.CheckEmailAddress(emailAddress);

            return result;
        }

        public bool CheckUsername(string username)
        {
            bool result = logInManager.CheckUsername(username);

            return result;
        }
    }
}