using PastebookBusinessLogic.Entities;
using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
