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
        public static CountryModel MapCountryEntityToCountryModel(CountryEntity countryEntity)
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