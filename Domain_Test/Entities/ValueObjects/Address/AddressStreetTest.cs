using Domain.Entities;
using NUnit.Framework;

namespace Domain_Test.Entities.ValueObjects.Address
{
    [TestFixture]
    public class AddressStreetTest
    {
        private AddressDTO NewAddress(string street)
        {
            return new AddressDTO(country: "Sweden", city: "Göteborg", street: street, zipCode: "41265", type: "Invoice", boxNo: null);
        }

        //"Ebbe Lieberathsgatan 18 c"

        [Test]
        public void ThrowsExceptionIfStreetIsNull()
        {
            void CreateNewAddressWithStreet() => NewAddress(null);

            Assert.That(CreateNewAddressWithStreet, Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowsExceptionIfTheLenghtOfStreetIsLessThanFive()
        {
            void CreateNewAddressWithStreet() => NewAddress("Li 1");

            Assert.That(CreateNewAddressWithStreet, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfTheLenghtOfStreetIsGreaterThanThirtyFive()
        {
            void CreateNewAddressWithStreet() => NewAddress("Katarina östra kyrkogårdsgränd 1200B");

            Assert.That(CreateNewAddressWithStreet, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfStreetContainsDot()
        {
            void CreateNewAddressWithStreet() => NewAddress("Ebbe Lie.berathsgatan 18 c");

            Assert.That(CreateNewAddressWithStreet, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfStreetContainsComma()
        {
            void CreateNewAddressWithStreet() => NewAddress("Ebbe, Lieberathsgatan 18 c");

            Assert.That(CreateNewAddressWithStreet, Throws.ArgumentException);
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
        public void ThrowsExceptionIfStreetContainsSpecialCharacter(char specialCharacter)
        {
            void CreateNewAddressWithStreet() => NewAddress("Ebbe Lieber" + specialCharacter + "athsgatan 18 c");

            Assert.That(CreateNewAddressWithStreet, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfStreetStartsWithWhiteSpace()
        {
            void CreateNewAddressWithStreet() => NewAddress(" Ebbe Lieberathsgatan 18 c");

            Assert.That(CreateNewAddressWithStreet, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfStreetEndsWithWhiteSpace()
        {
            void CreateNewAddressWithStreet() => NewAddress("Ebbe Lieberathsgatan 18 c ");

            Assert.That(CreateNewAddressWithStreet, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfStreetStartsWithADigit()
        {
            void CreateNewAddressWithStreet() => NewAddress("9Ebbe Lieberathsgatan 18 c");

            Assert.That(CreateNewAddressWithStreet, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfStreetDoesNotContainAtLeastOneWhiteSpace()
        {
            void CreateNewAddressWithStreet() => NewAddress("EbbeLieberathsgatan18c");

            Assert.That(CreateNewAddressWithStreet, Throws.ArgumentException);
        }

        [Test]
        public void StreetCanContainAValueWithTheLengthOfFive()
        {
            string expected = "Lia 1";
            AddressDTO address = NewAddress(expected);

            Assert.That(address.Street, Is.EqualTo(expected));
        }

        [Test]
        public void StreetCanContainAValueWithTheLengthOfThirtyFive()
        {
            string expected = "Katarina östra kyrkogårdsgränd 120B";
            AddressDTO address = NewAddress(expected);

            Assert.That(address.Street, Is.EqualTo(expected));
        }
    }
}