using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ABCParcelBussinesLogic
{

    public class PostOfficeModel
    {
        public List<Package> StandardPackages { get; set; } = new List<Package>();
        public List<TwoDayPackage> TwoDayPackage { get; set; } = new List<TwoDayPackage>();
        public List<OverNightPackage> OverNightPackage{ get; set; } = new List<OverNightPackage>();
        public List<Courier> Couriers { get; set; } = new List<Courier>();

    }
}
 