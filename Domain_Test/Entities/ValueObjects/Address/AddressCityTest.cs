using Domain.Entities;
using NUnit.Framework;

namespace Domain_Test.Entities.ValueObjects.Address
{
    [TestFixture]
    public class AddressCityTest
    {
        private AddressDTO NewAddress(string city)
        {
            return new AddressDTO(country: "Sweden", city: city, street: "Ebbe Lieberathsgatan 18 c", zipCode: "41265", type: "Invoice", boxNo: null);
        }

        [Test]
        public void ThrowsExceptionIfCityIsNull()
        {
            void CreateNewAddressWithCity() => NewAddress(null);

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowsExceptionIfTheLenghtOfCityIsLessThanOne()
        {
            void CreateNewAddressWithCity() => NewAddress("");

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfTheLenghtOfCityIsGreaterThanFifteen()
        {
            void CreateNewAddressWithCity() => NewAddress("Skinnskattebergg");

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentException);
        }

        [TestCase("1Göteborg")]
        [TestCase("Göte2borg")]
        [TestCase("Göteborg3")]
        public void ThrowsExceptionIfCityContainsDigits(string country)
        {
            void CreateNewAddressWithCity() => NewAddress(country);

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCityContainsDot()
        {
            void CreateNewAddressWithCity() => NewAddress("Göte.borg");

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCityContainsComma()
        {
            void CreateNewAddressWithCity() => NewAddress("Göte,borg");

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentException);
        }

        [TestCase('!')]
        [TestCase('"')]
        [TestCase('#')]
        [TestCase('¤')]
        [TestCase('%')]
        [TestCase('&')]
        [TestCase('/')]
        [TestCase('(')]
        [TestCase(')')]
        [TestCase('=')]
        [TestCase('+')]
        [TestCase('\'')]
        [TestCase('*')]
        [TestCase(':')]
        [TestCase(';')]
        [TestCase('<')]
        [TestCase('>')]
        [TestCase('@')]
        [TestCase('£')]
        [TestCase('$')]
        [TestCase('€')]
        [TestCase('{')]
        [TestCase('[')]
        [TestCase(']')]
        [TestCase('}')]
        [TestCase('\\')]
        [TestCase('|')]
        [TestCase('€')]
        [TestCase('_')]
        [TestCase('-')]
        [TestCase('^')]
        [TestCase('~')]
        public void ThrowsExceptionIfCityContainsSpecialCharacter(char specialCharacter)
        {
            void CreateNewAddressWithCity() => NewAddress("Göte" + specialCharacter + "borg");

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCityStartsWithWhiteSpace()
        {
            void CreateNewAddressWithCity() => NewAddress(" Göteborg");

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCityEndsWithWhiteSpace()
        {
            void CreateNewAddressWithCity() => NewAddress("Göteborg ");

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCityStartsWithLowerCase()
        {
            void CreateNewAddressWithCity() => NewAddress("göteborg");

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCityEndsWithUpperCase()
        {
            void CreateNewAddressWithCity() => NewAddress("GöteborG");

            Assert.That(CreateNewAddressWithCity, Throws.ArgumentException);
        }

        [Test]
        public void CityCanContainAValueWithTheLengthOfOne()
        {
            string expected = "Ö";
            AddressDTO address = NewAddress(expected);

            Assert.That(address.City, Is.EqualTo(expected));
        }

        [Test]
        public void CityCanContainAValueWithTheLengthOfFifteen()
        {
            string expected = "Skinnskatteberg";
            AddressDTO address = NewAddress(expected);

            Assert.That(address.City, Is.EqualTo(expected));
        }

        [Test]
        public void CityCanContainWhiteSpace()
        {
            string expected = "Dals Långed";
            AddressDTO address = NewAddress(expected);

            Assert.That(address.City, Is.EqualTo(expected));
        }
    }
}