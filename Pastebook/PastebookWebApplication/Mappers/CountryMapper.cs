using PastebookBusinessLogic.Entities;
using PastebookWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PastebookWebApplication.Mappers
{
    public class CountryMapper
    {
        public static CountryModel MapCountryEntityEFToCountryEntityUI(CountryEntity countryEntity)
        {
            CountryModel countryModel = new CountryModel()
            {
                CountryId = countryEntity.CountryId,
                Country = countryEntity.Country
            };

            return countryModel;
        }
    }
}