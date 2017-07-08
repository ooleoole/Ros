using Domain.Entities;
using NUnit.Framework;

namespace Domain_Test.Entities.ValueObjects.Address
{
    [TestFixture]
    public class AddressZipCodeTest
    {
        private AddressDTO NewAddress(string zipCode)
        {
            return new AddressDTO(country: "Sweden", city: "Göteborg", street: "Ebbe Lieberathsgatan 18 c", zipCode: zipCode, type: "Invoice", boxNo: null);
        }

        [Test]
        public void ThrowsExceptionIfZipCodeIsNull()
        {
            void CreateNewAddressWithZipCode() => NewAddress(null);

            Assert.That(CreateNewAddressWithZipCode, Throws.ArgumentNullException);
        }

        [TestCase("1234")]
        [TestCase("123456")]
        public void ThrowsExceptionIfLenghtOfZipCodeIsNotEqualToFive(string zipCode)
        {
            void CreateNewAddressWithZipCode() => NewAddress(zipCode);

            Assert.That(CreateNewAddressWithZipCode, Throws.ArgumentException);
        }

        [TestCase(" 1234")]
        [TestCase("1234&")]
        [TestCase("1.234")]
        [TestCase("1234,")]
        [TestCase("12Q34")]
        [TestCase("123a4")]
        public void ThrowsExceptionIfZipCodeContainsOtherCharactersThanDigits(string zipCode)
        {
            void CreateNewAddressWithZipCode() => NewAddress(zipCode);

            Assert.That(CreateNewAddressWithZipCode, Throws.ArgumentException);
        }

        [TestCase("41265")]
        [TestCase("12345")]
        [TestCase("09876")]
        public void ZipCodeCanContainDigits(string expected)
        {
            AddressDTO address = NewAddress(expected);

            Assert.That(address.ZipCode, Is.EqualTo(expected));
        }
    }
}