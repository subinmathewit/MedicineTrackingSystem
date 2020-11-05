using Moq;
using MTAPI.Controllers;
using MTAPI.Services;
using MTAPI.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MTAPI.Test
{
    public class MedicineControllerTest
    {
        private MedicineController controller;
        private Mock<IMedicineService> medicineServiceMock;
        private List<MedicineView> items;
        [SetUp]
        public void Setup()
        {
             medicineServiceMock = new Mock<IMedicineService>();
            //arrange
            items = new List<MedicineView>()
            {
                new MedicineView
                {
                    Id=1,
                    Name="Medicine",
                    Price=18,
                    Quantity=1,
                    Brand="Medicine brand",
                    ExpiryDate=DateTime.Now
                }
            };

            var saveItem = new MedicineViewWithNotes
            {
                Id = 1,
                Name = "Medicine",
                Price = 18,
                Quantity = 1,
                Brand = "Medicine brand",
                ExpiryDate = DateTime.Now,
                Notes = "Notes"
            };
            medicineServiceMock.Setup(c => c.GetAllMedicines()).Returns(items);
            medicineServiceMock.Setup(c => c.SaveMedicineDetails(saveItem)).Returns(1);
            controller = new MedicineController(medicineServiceMock.Object);
        }

        [Test]
        public  void GetAllMedicinesTest()
        {
            dynamic result = controller.Get();
            dynamic val = result.Value[0];
            Assert.AreEqual(val.Name, items[0].Name);
        }

        [Test]
        public void SaveMedicine()
        {
            var saveItem = new MedicineViewWithNotes
            {
                Id = 1,
                Name = "Medicine",
                Price = 18,
                Quantity = 1,
                Brand = "Medicine brand",
                ExpiryDate = DateTime.Now,
                Notes = "Notes"
            };
            dynamic result = controller.Post(saveItem);          
            Assert.AreEqual(result.StatusCode, 200);
        }
    }
}