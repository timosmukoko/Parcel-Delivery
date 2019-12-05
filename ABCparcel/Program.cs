using ABCParcelBussinesLogic;
using System;
using System.Collections.Generic;

namespace ABCparcel
{
    public class Program

    {
        //public List<Package> StandardPackages = new List<Package>();

        public static void Main(string[] args)
        {

            var postOffice = new PostOfficeControl();

            while (true)
            {
                postOffice.EntryPoint();
            }


        }


    }
}

