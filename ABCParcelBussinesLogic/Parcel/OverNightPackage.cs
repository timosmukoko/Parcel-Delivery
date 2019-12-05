namespace ABCParcelBussinesLogic
{
    public class OverNightPackage : Package
    {
        public Courier deliveryMan { get; set; }
        private double overnightCharge;        
        private double pricePerOunce;
  
        public OverNightPackage(Person reciever, 
            Person sender, 
            double costPerOunce, 
            double weight, 
            double overnightCharge, 
            Courier deliveryMan) : base(reciever, sender, weight, costPerOunce)
        {

            this.overnightCharge = overnightCharge.CheckForPositiveValue();
            this.deliveryMan = deliveryMan;
        }


        public OverNightPackage(double costPerOunce, double weight, double overnightCharge) : base( weight, costPerOunce)
        {
            this.overnightCharge = overnightCharge.CheckForPositiveValue();         
        }

        public override double CalculateCost()
        {
            var standardCost = base.CalculateCost();
            return overnightCharge * Weight + standardCost;
        }
    }
}