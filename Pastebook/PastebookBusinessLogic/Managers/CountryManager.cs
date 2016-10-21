using PastebookDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PastebookBusinessLogic.Managers
{
    public class CountryManager : Repository<PASTEBOOK_DBEntities, REF_COUNTRY>
    {
        public List<REF_COUNTRY> RetrieveAllCountries()
        {
            List<REF_COUNTRY> countries = new List<REF_COUNTRY>();

            try
            {
                var result = Retrieve();

                foreach (var country in result)
                {
                    countries.Add(country);
                }
            }
            catch (Exception ex)
            {
                List<Exception> exceptionList = new List<Exception>();
                exceptionList.Add(ex);
            }

            return countries;
        }
}
}
