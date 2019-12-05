namespace ABCParcelBussinesLogic
{/// <summary>
/// base class for package
/// </summary>
    public class Package
    {
        public Person
            Sender { get; set; }
        public Person Reciever { get; set; }
        public double Weight { get; set; }
        public double CostPerOunce { get; set; }

        ///
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="reciever"></param>
        /// <param name="weight"></param>
        /// <param name="costPerOunce"></param>
        public Package(Person sender, Person reciever, double weight, double costPerOunce)
        {
            this.Sender = sender;
            this.Reciever = reciever;
            this.Weight = weight.CheckForPositiveValue();
            this.CostPerOunce = costPerOunce.CheckForPositiveValue();
        }


        public Package( double weight, double costPerOunce)
        {
            this.Weight = weight.CheckForPositiveValue();
            this.CostPerOunce = costPerOunce.CheckForPositiveValue();
        }

        public virtual double CalculateCost()
        {
            return Weight * CostPerOunce;
        }
    }
}