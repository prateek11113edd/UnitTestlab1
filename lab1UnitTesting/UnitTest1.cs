using lab1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace lab1UnitTesting
{
    [TestClass]
    public class UnitTest1
    {

        public void slotAvailability()
        {
            VehicleTracker vehicletracker = new VehicleTracker(2, "Keewatin");
            //Arrange
            Vehicle c1 = new Vehicle("AAA", true);
            Vehicle c2 = new Vehicle("BBB", true);
            //Act
            vehicletracker.AddVehicle(c1);
            vehicletracker.AddVehicle(c2);
            //Asssert
            Assert.ThrowsException<IndexOutOfRangeException>(() => vehicletracker.AddVehicle(c2));
        }
        [TestMethod]
        public void AddVehicle()
        {
            //Arrange
            VehicleTracker vehicletracker = new VehicleTracker(2, "Keewatinr");
            Vehicle c1 = new Vehicle("AAA", true);
            Vehicle c2 = new Vehicle("BBB", true);
            //Add
            vehicletracker.AddVehicle(c1);

            //Assert
            Assert.IsTrue(vehicletracker.VehicleList.ContainsValue(c2));
        }
    }
}