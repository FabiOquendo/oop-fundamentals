using ACM.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BLTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //-- Arrange
            Customer customer = new Customer();
            customer.FirstName = "Fabio";
            customer.LastName = "Oquendo";

            string expected = "Oquendo, Fabio";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameFirstNameEmpty()
        {
            //-- Arrange
            Customer customer = new Customer
            {
                LastName = "Oquendo"
            };

            string expected = "Oquendo";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //-- Arrange
            Customer customer = new Customer
            {
                FirstName = "Fabio"
            };

            string expected = "Fabio";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StaticTest()
        {
            //-- Arrange
            Customer c1 = new Customer();
            c1.FirstName = "Fabio";
            Customer.InstanceCount += 1;

            Customer c2 = new Customer();
            c1.FirstName = "Paulo";
            Customer.InstanceCount += 1;

            Customer c3 = new Customer();
            c1.FirstName = "Felipe";
            Customer.InstanceCount += 1;

            int expected = 3;

            //-- Act
            int actual = Customer.InstanceCount;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateValid()
        {
            //-- Arrange
            var customer = new Customer
            {
                LastName = "Oquendo",
                EmailAddress = "fabio@oquendo.com"
            };

            bool expected = true;

            //-- Act
            bool actual = customer.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingLastName()
        {
            //-- Arrange
            var customer = new Customer
            {
                EmailAddress = "fabio@oquendo.com"
            };

            bool expected = false;

            //-- Act
            bool actual = customer.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
