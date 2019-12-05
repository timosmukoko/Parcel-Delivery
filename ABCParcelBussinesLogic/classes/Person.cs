using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCParcelBussinesLogic
{/// <summary>
 /// the person class represents sender and receiver
 /// </summary>
    public  class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public Person(string name, string address, string city, string state, string zipcode)

        {

            this.Name = name;
            this.Address = address;
            this.City = city;
            this.State = state;
            this.ZipCode = zipcode;

           
        }

        
    }


}

