using NUnit.Framework;
using System;
using CarManager;

namespace CarManager.Tests
{
    [TestFixture]
    public class CarTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            //public Car(string make, string model, double fuelConsumption, double fuelCapacity);
            string make = "aaa";
            string model = "bbb";
            double fuelConsumption = 5;
            double fuelCapacity = 40;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }
        [Test]
        public void ModelShouldThrowArgExWhenNameIsNull()
        {
            string make = "aaa";
            string model = null;
            double fuelConsumption = 5;
            double fuelCapacity = 40;
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
        [Test]
        public void FuelCapacityShouldThrowArgExWhenIsZero()
        {
            //Arange
            string make = "aaa";
            string model = "aaa";
            double fuelConsumption = 5;
            double fuelCapacity = 0;
            var act = Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
            string ex = "Fuel capacity cannot be zero or negative!";
            Assert.AreEqual(ex, act.Message);
        }
        [Test]
        public void FuelConsumptionShouldThrowArgExWhenIsZero()
        {
            string make = "aaa";
            string model = "bbb";
            double fuelConsumption = 0;
            double fuelCapacity = 40;
            var act = Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
            string ex = "Fuel consumption cannot be zero or negative!";
            Assert.AreEqual(ex, act.Message);


        }
        [TestCase(null,"bbb",5,200)]
        [TestCase("", "bbb", 5, 200)]
        [TestCase("bbb", null, 5, 200)]
        [TestCase("bbb", "", 5, 200)]
        [TestCase("aaa", "bbb", -5, 200)]
        [TestCase("aaa", "bbb", 0, 200)]
        [TestCase("aaa", "bbb", 5, -200)]
        [TestCase("aaa", "bbb", 5, 0)]
        public void ValidateAllProperties(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }


        [Test]
        public void ShouldRefuelNormally()
        {
            int fuelToRefuel=30;
            string make = "aaa";
            string model = "bbb";
            double fuelConsumption = 5;
            double fuelCapacity = 40;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(30, car.FuelAmount);
        }

        [Test]
        public void ShouldRefuelUntillTotalFuelCapacity()
        {
            int fuelToRefuel = 60;
            string make = "aaa";
            string model = "bbb";
            double fuelConsumption = 5;
            double fuelCapacity = 40;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            car.Refuel(fuelToRefuel);
            Assert.AreEqual(40, car.FuelAmount);
        }
        [TestCase (-5)]
        public void ShouldRefuelThrowArgExWhenInputAmountIsBellowZero(double inputAmount)
        {
            string make = "aaa";
            string model = "bbb";
            double fuelConsumption = 20;
            double fuelCapacity = 40;
            double fuelAmount = 20;
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);
            string exp = "Fuel amount cannot be zero or negative!";
            var act = Assert.Throws<ArgumentException>(() => car.Refuel(inputAmount)) ;
            Assert.AreEqual(exp, act.Message);
        }

        [Test]
        public void ShouldDriveNormally()
        {
            Car car = new Car("Vw", "Golf", 2, 100);
            //TO DO
        }

        [Test]
        public void DriveShouldThrowInvalidOperationExceptionWhenFuelAmountIsNotEnough()
        {
            //TO DO
        }
    }

}
