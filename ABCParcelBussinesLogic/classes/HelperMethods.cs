using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCParcelBussinesLogic
{
public static class HelperMethods
    {

        public static Courier PersonToCourierConverter(this Person person, String companyNmae) {
            var curier = new Courier(companyNmae,
                person.Name,
                person.Address,
                person.City,
                person.State,
                person.ZipCode

                );

            return curier;
        }
    }
}
