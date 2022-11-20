using Hangar.Restaurant.Helpers;
using Hangar.Restaurant.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Hangar.Restaurant.UnitTest.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void CorrectMenuId()
        {
            // Arrange
            var menuId = 1;
            var quantity = 2;

            //unit price is 

            // Act
            var totalPrice = CartHelper.CalculateTotal(menuId,quantity);


            // Assert
            Assert.AreEqual(totalPrice, 650);
        }


        [TestMethod]

        public void IncorrectMenuId()
        {
            // Arrange
            var menuId = 10;
            var quantity = 2;

            //unit price is 

            // Act
            var totalPrice = CartHelper.CalculateTotal(menuId, quantity);


            // Assert
            Assert.AreEqual(totalPrice, 0);
        }

       
    }
}
