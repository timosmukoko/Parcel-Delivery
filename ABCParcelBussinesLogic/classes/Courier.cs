using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCParcelBussinesLogic
{
    public class Courier : Person
    {
        public string companyName { get; set; }



        public Courier(string CompanyName,string Name, string Address, string City, string State, string Zipcode) :base (Name, Address, City, State, Zipcode)
        {
            this.companyName = CompanyName;
            this.Address = Address;
            this.Name = Name;
            this.City = City;
            this.State = State;
            this.ZipCode = Zipcode;

        }


        
    }
}