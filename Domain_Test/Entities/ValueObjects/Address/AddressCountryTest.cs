using Domain.Entities;
using NUnit.Framework;

namespace Domain_Test.Entities.ValueObjects.Address
{
    [TestFixture]
    public class AddressCountryTest
    {
        private AddressDTO NewAddress(string country)
        {
            return new AddressDTO(country: country, city: "Göteborg", street: "Ebbe Lieberathsgatan 18 c", zipCode: "41265", type: "Invoice", boxNo: null);
        }

        [Test]
        public void ThrowsExceptionIfCountryIsNull()
        {
            void CreateNewAddressWithCountry() => NewAddress(null);

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowsExceptionIfTheLenghtOfCountryIsLessThanFour()
        {
            void CreateNewAddressWithCountry() => NewAddress("Gua");

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfTheLenghtOfCountryIsGreaterThanThirtyTwo()
        {
            void CreateNewAddressWithCountry() => NewAddress("Sahrawi Arab Democratic Republicc");

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentException);
        }

        [TestCase("1Sweden")]
        [TestCase("Swe2den")]
        [TestCase("Sweden3")]
        public void ThrowsExceptionIfCountryContainsDigits(string country)
        {
            void CreateNewAddressWithCountry() => NewAddress(country);

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCountryContainsDot()
        {
            void CreateNewAddressWithCountry() => NewAddress("Swe.den");

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCountryContainsComma()
        {
            void CreateNewAddressWithCountry() => NewAddress("Swe,den");

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentException);
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
        public void ThrowsExceptionIfCountryContainsSpecialCharacter(char specialCharacter)
        {
            void CreateNewAddressWithCountry() => NewAddress("Swe" + specialCharacter + "den");

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCountryStartsWithWhiteSpace()
        {
            void CreateNewAddressWithCountry() => NewAddress(" Sweden");

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCountryEndsWithWhiteSpace()
        {
            void CreateNewAddressWithCountry() => NewAddress("Sweden ");

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCountryStartsWithLowerCase()
        {
            void CreateNewAddressWithCountry() => NewAddress("sweden");

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfCountryEndsWithUpperCase()
        {
            void CreateNewAddressWithCountry() => NewAddress("SwedeN");

            Assert.That(CreateNewAddressWithCountry, Throws.ArgumentException);
        }

        [Test]
        public void CountryCanContainAValueWithTheLengthOfFour()
        {
            string expected = "Guam";
            AddressDTO address = NewAddress(expected);

            Assert.That(address.Country, Is.EqualTo(expected));
        }

        [Test]
        public void CountryCanContainAValueWithTheLengthOfThirtyTwo()
        {
            string expected = "Sahrawi Arab Democratic Republic";
            AddressDTO address = NewAddress(expected);

            Assert.That(address.Country, Is.EqualTo(expected));
        }
    }
}