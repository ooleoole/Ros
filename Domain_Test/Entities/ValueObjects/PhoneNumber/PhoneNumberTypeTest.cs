using Domain.Entities;
using NUnit.Framework;

namespace Domain_Test.Entities.ValueObjects.PhoneNumber
{
    [TestFixture]
    public class PhoneNumberTypeTest
    {
        private PhoneNumberDTO NewPhoneNumber(string type)
        {
            return new PhoneNumberDTO("012345678", type);
        }

        [Test]
        public void ThrowsExceptionIfTypeIsNull()
        {
            void CreateNewPhoneNumberWithType() => NewPhoneNumber(null);

            Assert.That(CreateNewPhoneNumberWithType, Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowsExceptionIfLenghtOfTypeIsLessThanThree()
        {
            void CreateNewPhoneNumberWithType() => NewPhoneNumber("He");

            Assert.That(CreateNewPhoneNumberWithType, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfLenghtOfTypeIsGreaterThanTen()
        {
            void CreateNewPhoneNumberWithType() => NewPhoneNumber("House phone");

            Assert.Throws(typeof(System.ArgumentException), CreateNewPhoneNumberWithType);
        }

        [Test]
        public void ThrowsExceptionIfTypeContainsDot()
        {
            void CreateNewPhoneNumberWithType() => NewPhoneNumber("Ho.me");

            Assert.Throws(typeof(System.ArgumentException), CreateNewPhoneNumberWithType);
        }

        [Test]
        public void ThrowsExceptionIfTypeContainsComma()
        {
            void CreateNewPhoneNumberWithType() => NewPhoneNumber("Ho,me");

            Assert.Throws(typeof(System.ArgumentException), CreateNewPhoneNumberWithType);
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
            void CreateNewPhoneNumberWithType() => NewPhoneNumber("Ho" + specialCharacter + "me");

            Assert.Throws(typeof(System.ArgumentException), CreateNewPhoneNumberWithType);
        }

        [Test]
        public void ThrowsExceptionIfTypeStartsWithWhiteSpace()
        {
            void CreateNewPhoneNumberWithType() => NewPhoneNumber(" Home");

            Assert.Throws(typeof(System.ArgumentException), CreateNewPhoneNumberWithType);
        }

        [Test]
        public void ThrowsExceptionIfTypeEndsWithWhiteSpace()
        {
            void CreateNewPhoneNumberWithType() => NewPhoneNumber("Home ");

            Assert.Throws(typeof(System.ArgumentException), CreateNewPhoneNumberWithType);
        }

        [Test]
        public void ThrowsExceptionIfTypeStartsWithWhiteDigit()
        {
            void CreateNewPhoneNumberWithType() => NewPhoneNumber("9Home");

            Assert.Throws(typeof(System.ArgumentException), CreateNewPhoneNumberWithType);
        }

        [TestCase("Home")]
        [TestCase("Work")]
        [TestCase("Office")]
        [TestCase("Mobile")]
        public void TypeCanContainLetters(string expected)
        {
            PhoneNumberDTO phoneNumber = NewPhoneNumber(expected);
            Assert.That(phoneNumber.Type, Is.EqualTo(expected));
        }

        [TestCase("Home1")]
        [TestCase("Work2")]
        [TestCase("Office13")]
        [TestCase("Mobile45")]
        public void TypeCanContainDigits(string expected)
        {
            PhoneNumberDTO phoneNumber = NewPhoneNumber(expected);
            Assert.That(phoneNumber.Type, Is.EqualTo(expected));
        }

        [TestCase("Home 1")]
        [TestCase("Work 2")]
        [TestCase("Office 13")]
        [TestCase("Mobile 45")]
        public void TypeCanContainWhiteSpace(string expected)
        {
            PhoneNumberDTO phoneNumber = NewPhoneNumber(expected);
            Assert.That(phoneNumber.Type, Is.EqualTo(expected));
        }
    }
}