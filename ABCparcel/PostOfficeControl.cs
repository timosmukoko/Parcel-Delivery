using ABCParcelBussinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABCparcel
{

public class PostOfficeControl
    {

        private PostOfficeModel postOfficeModel = new PostOfficeModel();
      
        private const double COSTPERONCE = 12.3;
        private const double OVERNIGHCHARGE = 2.3;
        private const double STANDARDFEE = 5;


        public PostOfficeControl()
        {
            storedCouriers();
        }

        public void EntryPoint()
        {
            Console.Clear();
            DisplayMainManu();
          
            var option =(MainProgramOptionsEnum) GetIntegerOptionFromUser(1, 5);
            switch (option)
            {
                case MainProgramOptionsEnum.SetupPackage:
                    SetupPackage();
                    break;
                case MainProgramOptionsEnum.ViewShippingDetails:
                    DisplayShippingDetails();
                    break;
                case MainProgramOptionsEnum.CostBreakdown:
                    DisplayCostBreakDown();
                    break;
                case MainProgramOptionsEnum.ListCouriers:
                                       
                    DisplayCourier();
                    break;
                case MainProgramOptionsEnum.Exit:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

            // this is here to stop refreshing screen
            Console.WriteLine("\tPress enter to continue...");
            Console.ReadLine();
        }

        private void DisplayCostBreakDown()
        {
            double overnightCost = 0;
            foreach (var item in postOfficeModel.OverNightPackage)
            {
                overnightCost += item.CalculateCost();
            }

            double standatd = 0;
            foreach (var item in postOfficeModel.StandardPackages)
            {
                standatd += item.CalculateCost();
            }

            double twoDays = 0;
            foreach (var item in postOfficeModel.TwoDayPackage)
            {
                twoDays += item.CalculateCost();
            }

            var total = standatd + twoDays + overnightCost;
            if (total == 0) {
                Console.WriteLine("\tNo shipping costs....");
                return;
            }

            var overnightPrc = (overnightCost / total) * 100;
            var twoDaysPrc = (twoDays / total) * 100;
            var standatdPrc = (standatd / total) * 100;

            Console.WriteLine(" \t------------ COST ANALYSIS ----------- ");
            Console.WriteLine();
            Console.WriteLine($"\t- Standard sum:{standatd}, gives {standatdPrc}% of total");
            Console.WriteLine($"\t- Two day sum:{twoDays}, gives {twoDaysPrc}% of total");
            Console.WriteLine($"\t- Overnight sum:{ overnightCost}, gives {overnightPrc}% of total");
            Console.WriteLine($"\t- Total shipping cost:{total}");


        }

        private void DisplayShippingDetails()
        {
            Console.WriteLine();
            foreach( var item in postOfficeModel.StandardPackages)
            {
                Console.WriteLine("\t ___________________________________________");
                Console.WriteLine("\t|              STANDARD PACKAGE             |");
                Console.WriteLine("\t|___________________________________________|");
                Console.WriteLine();
                //Console.WriteLine($"Form: {item.Sender.Name}, to:{item.Reciever.Name}, cost: {item.CalculateCost()} ");
                Console.WriteLine("\t---------- SENDER ----------");
                Console.WriteLine($"\t Name: {item.Sender.Name} \n\t Address: {item.Sender.Address} \n\t City: {item.Sender.City} \n\t State: {item.Sender.State} \n\t ZipCode: {item.Sender.ZipCode} \n\t Weight: {item.Weight}");
                Console.WriteLine();
                Console.WriteLine("\t---------- RECEIVER ---------");
                Console.WriteLine($"\t Name: {item.Reciever.Name} \n\t Address: {item.Reciever.Address} \n\t City: {item.Reciever.City} \n\t State: {item.Reciever.State} \n\t ZipCode: {item.Reciever.ZipCode} \n\t Cost: {item.CalculateCost()}");
                Console.WriteLine();
            }

            foreach (var item in postOfficeModel.OverNightPackage)
            {
                Console.WriteLine("\t ___________________________________________");
                Console.WriteLine("\t|             OVERNIGHT PACKAGE             |");
                Console.WriteLine("\t|___________________________________________|");
                Console.WriteLine();
                Console.WriteLine("\t---------- SENDER ----------");
                Console.WriteLine($"\t Name: {item.Sender.Name} \n\t Address: {item.Sender.Address} \n\t City: {item.Sender.City} \n\t State: {item.Sender.State} \n\t ZipCode: {item.Sender.ZipCode} \n\t Weight: {item.Weight}");
                Console.WriteLine();
                Console.WriteLine("\t---------- RECEIVER ---------");
                Console.WriteLine($"\t Name: {item.Reciever.Name} \n\t Address: {item.Reciever.Address} \n\t City: {item.Reciever.City} \n\t State: {item.Reciever.State} \n\t ZipCode: {item.Reciever.ZipCode} \n\t Cost: {item.CalculateCost()}");
                Console.WriteLine();
            }


            foreach(var item in postOfficeModel.TwoDayPackage)
            {
                Console.WriteLine("\t ___________________________________________");
                Console.WriteLine("\t|              TWO DAY PACKAGE              |");
                Console.WriteLine("\t|___________________________________________|");
                Console.WriteLine();
                Console.WriteLine("\t---------- SENDER ----------");
                Console.WriteLine($"\t Name: {item.Sender.Name} \n\t Address: {item.Sender.Address} \n\t City: {item.Sender.City} \n\t State: {item.Sender.State} \n\t ZipCode: {item.Sender.ZipCode} \n\t Weight: {item.Weight}");
                Console.WriteLine();
                Console.WriteLine("\t---------- RECEIVER ---------");
                Console.WriteLine($"\t Name: {item.Reciever.Name} \n\t Address: {item.Reciever.Address} \n\t City: {item.Reciever.City} \n\t State: {item.Reciever.State} \n\t ZipCode: {item.Reciever.ZipCode} \n\t Cost: {item.CalculateCost()}");
                Console.WriteLine();
            }

        }

        private void SetupPackage()
        {
            var sender = GetPersonDetails("Sender");
            var receiver = GetPersonDetails("Receiver");
            double weight = GetWeightDetails();

            Console.WriteLine("\tPlease enter 1 to create a Standard packages");
            Console.WriteLine("\tPlease enter 2 to create a Two days package");
            Console.WriteLine("\tPlease enter 3 to create an Overnight package");
            Console.WriteLine();
            var packageOption = (PackageOptionsEnum)GetIntegerOptionFromUser(1, 3);

            switch (packageOption)
            {
                case PackageOptionsEnum.Standard:
                    var package = new Package(sender, receiver, weight,COSTPERONCE);
                    postOfficeModel.StandardPackages.Add(package);

                    break;
                case PackageOptionsEnum.TwoDays:
                    var twoDays = new TwoDayPackage(sender, receiver, weight, COSTPERONCE, STANDARDFEE);
                    postOfficeModel.TwoDayPackage.Add(twoDays);
                    break;
                case PackageOptionsEnum.OverNight:
                    Console.WriteLine("\tPlease provide company name:");
                    var company = Console.ReadLine();
                    var courier = GetPersonDetails("Courier").PersonToCourierConverter(company);
                    var overnightPackage = new OverNightPackage(sender, receiver, COSTPERONCE, weight, OVERNIGHCHARGE, courier);
                    postOfficeModel.OverNightPackage.Add(overnightPackage);
                    postOfficeModel.Couriers.Add(courier);

                    break;
                default:
                    break;
            }

            Console.WriteLine("\t**********You have successfully setup a package to sent************ \n");

        }

        private double GetWeightDetails()
        {
            Console.WriteLine("\tPlease enter package weight");

            var userInput = Console.ReadLine();
            var retry = true;
            double option;
            //chec user input
            while (retry)
            {
                var parseResult = double.TryParse(userInput, out option);
                if (parseResult)
                {
                    //check min max as inpru is valid                   
                        retry = false; // return terminate loop 
                        return option;                
                }

                Console.WriteLine("\tPlease provide valid input.");
                userInput = Console.ReadLine();

            }

            throw new IndexOutOfRangeException();
        }

        private Person GetPersonDetails(string type)
        {
            Console.WriteLine();
            Console.WriteLine($"\tProvide {type} details:");
            Console.WriteLine();
            Console.WriteLine($"\tEnter {type} Name: ");
            string sNAME = Console.ReadLine();

            Console.WriteLine($"\tEnter {type} Address: ");
            string sADDRESS = Console.ReadLine();

            Console.WriteLine($"\tEnter {type} City ");
            string sCITY = Console.ReadLine();

            Console.WriteLine($"\tEnter {type} State");
            string sSTATE = Console.ReadLine();

            Console.WriteLine($"\tEnter {type} ZipCode");
            string senderZipCode = Console.ReadLine();
            
            var person = new Person(sNAME, sADDRESS, sCITY, sSTATE, senderZipCode);
            return person;

        }

        public int GetIntegerOptionFromUser(int minValue, int maxValues) {


            var userInput = Console.ReadLine();
            var retry = true;
            int option;
            //chec user input
            while (retry)
            {
                var parseResult = int.TryParse(userInput, out option);
                if (parseResult)
                {
                    //check min max as inpru is valid
                    if (minValue <= option && option <= maxValues)
                    {
                        retry = false; // return terminate loop 
                        return option;
                    }

                }           

                    Console.WriteLine("\tPlease provide valid input.");
                    userInput = Console.ReadLine();
                
            }

            throw new IndexOutOfRangeException();               
        }

        public void DisplayMainManu()
        {
            Console.WriteLine("\n\n\n\n\t\t\t\tABC PARCEL DELIVERY");
            Console.WriteLine("\t--------------------------------------------------------------");
            Console.WriteLine("\t\t1. Create Parcels");
            Console.WriteLine("\t\t2. Display Shipping Details including cost");
            Console.WriteLine("\t\t3. Analyse Cost Breakdown");
            Console.WriteLine("\t\t4. Display List of Couriers Required for Parcel Delivery");
            Console.WriteLine("\t\t5. Exit");
            Console.WriteLine("\t--------------------------------------------------------------");
            Console.WriteLine("\n\t\tOption: ");
         
        }



        public void storedCouriers()
        {
            Courier deliveryMan = new Courier("DHL", "Tony", " Dublin 2 - Ireland", "Dublin", "limerick", "237E");
            Courier DeliveryWoman = new Courier("Ampost", "Leah", "Henry street", "Limerick", "Munster", "E2ERR");
            postOfficeModel.Couriers.Add(deliveryMan);
            postOfficeModel.Couriers.Add(DeliveryWoman);           

        }
        public void DisplayCourier()
        {
            Console.WriteLine("\t----------- LIST OF COURIERS REQUIRED FOR PARCEL DELIVERIES ------------- \n");

            foreach (var item in postOfficeModel.Couriers) 
            {
                Console.WriteLine($"\tCompany Name: {item.companyName} \n\t Agent name: {item.Name} \n\t Address:{item.Address} \n\t City:{item.City} \n\t State: {item.State} \n\t ZipCode: {item.ZipCode} \n");
            }
           
        }
    }
}
