using PastebookBusinessLogic.Entities;
using PastebookDataAccess;

namespace PastebookBusinessLogic.Mappers
{
    public class CountryMapper
    {
        public static CountryEntity MapCountryEntityEFToCountryEntityUI(REF_COUNTRY countryEntityEF)
        {
            CountryEntity countryEntityUI = new CountryEntity()
            {
               CountryId = countryEntityEF.ID,
               Country = countryEntityEF.COUNTRY
            };

            return countryEntityUI;
        }
    }
}
