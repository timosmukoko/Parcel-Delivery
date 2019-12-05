using System;

namespace ABCParcelBussinesLogic
{
    public class TwoDayPackage : Package
    {
        private readonly double twoDayFee;

        public TwoDayPackage(Person reciever, Person sender, double weight, double costPerOunce, double stardardFee) : base(reciever, sender, weight, costPerOunce)
        {
            this.twoDayFee = stardardFee.CheckForPositiveValue();
        }

        public override double CalculateCost()
        {
            var standardCost = base.CalculateCost();
           
            return standardCost + twoDayFee;
        }



        public TwoDayPackage(double weight, double costPerOunce, double stardardFee) : base(weight, costPerOunce)
        {
            this.twoDayFee = stardardFee.CheckForPositiveValue();
        }


    }
}