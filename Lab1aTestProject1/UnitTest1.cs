using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lab1a.Models;
using Microsoft.EntityFrameworkCore;
using Lab1a.Controllers;
using System.Threading.Tasks;

namespace Lab1aTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static Lab1aContext _lab1aContext;
        public static DealershipMgr _lab1aDealershipMger;

        [ClassInitialize]
        public static void Initialize(TestContext tc)
        {
            var options = new DbContextOptionsBuilder<Lab1aContext>()
                .UseInMemoryDatabase(databaseName: "MohawkTestDb").Options;
            _lab1aContext = new Lab1aContext(options);
            _lab1aDealershipMger = new DealershipMgr();


           //  Car Car1 = new Car { Id = 3, Make = "Chevy", Model = "Impala", Year = 2012, VIN = "123" };
           // Car Car2 = new Car { Id = 4, Make = "Chevy", Model = "Malibu", Year = 2010, VIN = "456" };
           // _lab1aContext.Car.AddRange(Car1, Car2);
           // _lab1aContext.SaveChanges();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Assert
            // get
            var dealerships = _lab1aDealershipMger.Get();
            int count = dealerships.Count();
            Assert.AreEqual(2, count);
            // get single
            Dealership dealership = _lab1aDealershipMger.Get(1);
            Assert.AreEqual(1, dealership.Id);
            Assert.AreEqual("Joshs Cars", dealership.Name);
            // post
            Dealership newDealership = new Dealership { Id = 3, Name = "Johns Cars", Email = "dealer@john.ca", PhoneNumber = "905-123-4567" };
            _lab1aDealershipMger.Post(newDealership);
            dealership = _lab1aDealershipMger.Get(3);
            Assert.AreEqual(3, dealership.Id);
            Assert.AreEqual("Johns Cars", dealership.Name);

        }
    }
}
