using ABCParcelBussinesLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ABCParcelTests
{
    [TestClass]
    public class PackageTests
    {
        private Person sPerson = new Person("James", "1 Henry Str", "Munster", "limerick", "237E");

        private Person rPerson = new Person("Tony", " Dublin 2 - Ireland", "Dublin", "limerick", "237E");

        private Courier deliveryMan = new Courier("DHL", "Tony", " Dublin 2 - Ireland", "Dublin", "limerick", "237E");

        private double weight = 5.25;
        private double pricePerOunce = 23.2;
        private double overnightCharge = 11.25;
        private double twoDayCharge = 33.3;

        [TestMethod]
        public void CheckStandardParcelCost()
        {
            var parcel = new Package(sPerson, rPerson, weight, pricePerOunce);
            var expectedCost = weight * pricePerOunce;
            Assert.AreEqual(expectedCost, parcel.CalculateCost());
        }

        [TestMethod]
        public void CheckTwoDayarcelCost()
        {
            var parcel = new TwoDayPackage(sPerson, rPerson, weight, pricePerOunce, twoDayCharge);
            var expectedCost = weight * pricePerOunce + twoDayCharge;
            Assert.AreEqual(expectedCost, parcel.CalculateCost());
        }

        [TestMethod]
        public void CheckOvernightParcelCost()
        {
            var parcel = new OverNightPackage(sPerson, rPerson, pricePerOunce, weight, overnightCharge, deliveryMan);
            var expectedCost = weight * (pricePerOunce + overnightCharge);
            Assert.AreEqual(expectedCost, parcel.CalculateCost());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckWeightValue()
        {
            var parcel = new OverNightPackage(sPerson, rPerson, pricePerOunce, -weight, overnightCharge,deliveryMan);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckPricePerOnceValue()
        {
            var parcel = new OverNightPackage(sPerson, rPerson, -pricePerOunce, weight, overnightCharge, deliveryMan);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckOvernightChargeValue()
        {
            var parcel = new OverNightPackage(sPerson, rPerson, pricePerOunce, weight, -overnightCharge, deliveryMan);
        }
    }
}