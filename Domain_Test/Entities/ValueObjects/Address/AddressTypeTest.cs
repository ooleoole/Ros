using Domain.Entities;
using NUnit.Framework;

namespace Domain_Test.Entities.ValueObjects.Address
{
    public class AddressTypeTest
    {
        private AddressDTO NewAddress(string type)
        {
            return new AddressDTO(country: "Sweden", city: "Göteborg", street: "Ebbe Lieberathsgatan 18 c", zipCode: "41265", type: type, boxNo: null);
        }

        [Test]
        public void ThrowsExceptionIfTypeIsNull()
        {
            void CreateNewAddressWithType() => NewAddress(null);

            Assert.That(CreateNewAddressWithType, Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowsExceptionIfLenghtOfTypeIsLessThanThree()
        {
            void CreateNewAddressWithType() => NewAddress("He");

            Assert.That(CreateNewAddressWithType, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfLenghtOfTypeIsGreaterThanTen()
        {
            void CreateNewAddressWithType() => NewAddress("Invoice 111");

            Assert.That(CreateNewAddressWithType, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfTypeContainsDot()
        {
            void CreateNewAddressWithType() => NewAddress("Invo.ice");

            Assert.That(CreateNewAddressWithType, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfTypeContainsComma()
        {
            void CreateNewAddressWithType() => NewAddress("Invo,ice");

            Assert.That(CreateNewAddressWithType, Throws.ArgumentException);
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
        public void ThrowsExceptionIfTypeContainsSpecialCharacter(char specialCharacter)
        {
            void CreateNewAddressWithType() => NewAddress("Invo" + specialCharacter + "ice");

            Assert.That(CreateNewAddressWithType, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfTypeStartsWithWhiteSpace()
        {
            void CreateNewAddressWithType() => NewAddress(" Invoice");

            Assert.That(CreateNewAddressWithType, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfTypeEndsWithWhiteSpace()
        {
            void CreateNewAddressWithType() => NewAddress("Invoice ");

            Assert.That(CreateNewAddressWithType, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfTypeStartsWithWhiteDigit()
        {
            void CreateNewAddressWithType() => NewAddress("9Invoice");

            Assert.That(CreateNewAddressWithType, Throws.ArgumentException);
        }

        [Test]
        public void TypeCanContainAValueWithTheLengthOfThree()
        {
            string expected = "Hem";
            AddressDTO address = NewAddress(expected);
            Assert.That(address.Type, Is.EqualTo(expected));
        }

        [Test]
        public void TypeCanContainAValueWithTheLengthOfTen()
        {
            string expected = "Invoice 11";
            AddressDTO address = NewAddress(expected);
            Assert.That(address.Type, Is.EqualTo(expected));
        }

        [TestCase("Office")]
        [TestCase("Invoice")]
        public void TypeCanContainLetters(string expected)
        {
            AddressDTO address = NewAddress(expected);
            Assert.That(address.Type, Is.EqualTo(expected));
        }

        [TestCase("Office13")]
        [TestCase("Invoice45")]
        public void TypeCanContainDigits(string expected)
        {
            AddressDTO address = NewAddress(expected);
            Assert.That(address.Type, Is.EqualTo(expected));
        }

        [TestCase("Office 13")]
        [TestCase("Invoice 45")]
        public void TypeCanContainWhiteSpace(string expected)
        {
            AddressDTO address = NewAddress(expected);
            Assert.That(address.Type, Is.EqualTo(expected));
        }
    }
}