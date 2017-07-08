using Domain.Entities;
using NUnit.Framework;

namespace Domain_Test.Entities.ValueObjects.PhoneNumber
{
    [TestFixture]
    public class PhoneNumberValueTest
    {
        private const char PhoneNumberStartingDigit = '0';

        private PhoneNumberDTO NewPhoneNumber(string value)
        {
            return new PhoneNumberDTO(value, "Mobile");
        }

        [Test]
        public void ThrowsExceptionIfValueIsNull()
        {
            void CreateNewPhoneNumberWithValue() => NewPhoneNumber(null);

            Assert.That(CreateNewPhoneNumberWithValue, Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowsExceptionIfLenghtOfValueIsLessThanEight()
        {
            void CreateNewPhoneNumberWithValue() => NewPhoneNumber(PhoneNumberStartingDigit + "123456");

            Assert.That(CreateNewPhoneNumberWithValue, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfLenghtOfValueIsGreaterThanTen()
        {
            void CreateNewPhoneNumberWithValue() => NewPhoneNumber(PhoneNumberStartingDigit + "1234567890");

            Assert.That(CreateNewPhoneNumberWithValue, Throws.ArgumentException);
        }

        [TestCase("qwertyuio")]
        [TestCase("!=#¤%&/()")]
        [TestCase("78k48612")]
        [TestCase("78948@12")]
        [TestCase("78.48612")]
        public void ThrowsExceptionIfValueContainsOtherCharactersThanDigits(string value)
        {
            void CreateNewPhoneNumberWithValue() => NewPhoneNumber(PhoneNumberStartingDigit + value);

            Assert.That(CreateNewPhoneNumberWithValue, Throws.ArgumentException);
        }

        [TestCase("178948612")]
        [TestCase("278948612")]
        [TestCase("378948612")]
        [TestCase("478948612")]
        [TestCase("578948612")]
        [TestCase("678948612")]
        [TestCase("778948612")]
        [TestCase("878948612")]
        [TestCase("978948612")]
        public void ThrowsExceptionIfValueDoesNotStartWithZero(string value)
        {
            void CreateNewPhoneNumberWithValue() => NewPhoneNumber(value);

            Assert.That(CreateNewPhoneNumberWithValue, Throws.ArgumentException);
        }

        [Test]
        public void AValueWithTheLengthOfEightIsValid()
        {
            string expected = PhoneNumberStartingDigit + "1234567";
            PhoneNumberDTO phoneNumber = NewPhoneNumber(expected);
            Assert.That(phoneNumber.Value, Is.EqualTo(expected));
        }

        [Test]
        public void AValueWithTheLengthOfTenIsValid()
        {
            string expected = PhoneNumberStartingDigit + "123456789";
            PhoneNumberDTO phoneNumber = NewPhoneNumber(expected);
            Assert.That(phoneNumber.Value, Is.EqualTo(expected));
        }
    }
}