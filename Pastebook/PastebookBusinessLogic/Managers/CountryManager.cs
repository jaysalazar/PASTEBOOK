using PastebookBusinessLogic.Entities;
using PastebookBusinessLogic.Mappers;
using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.BusinessLogic
{
    public class CountryManager
    {
        List<Exception> exceptionList;

        public List<CountryEntity> RetrieveAllCountries()
        {
            List<CountryEntity> countryEntityList = new List<CountryEntity>();
            CountryEntity countryEntity = new CountryEntity();

            using (var context = new PASTEBOOK_DBEntities())
            {
                try
                {
                    var result = context.REF_COUNTRY.ToList();

                    foreach (var country in result)
                    {
                        countryEntity = CountryMapper.MapCountryEntityEFToCountryEntityUI(country);
                        countryEntityList.Add(countryEntity);
                    }
                }
                catch (Exception ex)
                {
                    exceptionList = new List<Exception>();
                    exceptionList.Add(ex);
                }
            }

            return countryEntityList;
        }
    }
}
