using Xunit;
using AdressBook.Models;
using AdressBook.Services;
using System;
using System.Linq;
namespace AdressBook
{
    public class UnitTest
    {

        private readonly AdressRepository ar;
        public UnitTest()
        {
            ar = new AdressRepository();
        }

        [Fact]
        public void TestArePostedEqualToSaved()
        {
            // Arrange
            var newAddress = new Adress { Name = "Test", Street = "Ładna" };
            
            // Act
            
            ar.Add(newAddress);
            // Assert
            
            var lastAddedAddress = ar.GetLastAdded();
            lastAddedAddress.Name.Equals("Test");
            lastAddedAddress.Street.Equals("Ładna");
        }

        [Fact]
        public void TestGetEmptyAddressBook()
        {
            //Arrange
            var result = ar.GetLastAdded();
            
            //Act
            
            //Assert
            
            Assert.Null(result);


        }
        [Fact]
        public void TestWillBeExceptionIfWePostNull()
        {
            //Arrange
            Adress newAddress = null;
            
            //Act
            var exception = Assert.Throws<ArgumentNullException>(() => ar.Add(newAddress));
            
            //Assert
            Assert.Equal("Value cannot be null. (Parameter 'adress')", exception.Message);

        }
        [Fact]
        public void IsEqualToDataPosted()
        {
            //Arrange

            var newAddress      = new Adress { Name = "Test",  Street = "Ładna", City = "Kozy" };
            var newAddressTwo   = new Adress { Name = "Test2", Street = "ABC",   City = "Kozy" };
            var newAddressThree = new Adress { Name = "Test3", Street = "CDE",   City = "Kozy" };
            var newAddressFour  = new Adress { Name = "Test4", Street = "FGH",   City = "Bielsko" };
            var newAddressFive  = new Adress { Name = "Test5", Street = "IJK",   City = "Bielsko" };

            //Act
            ar.Add(newAddress);
            ar.Add(newAddressTwo);
            ar.Add(newAddressThree);
            ar.Add(newAddressFour);
            ar.Add(newAddressFive);


            //Assert
            var count = ar.GetAdressesIn("Kozy").Count();
            Assert.Equal(3, count);
        }


    }
}


