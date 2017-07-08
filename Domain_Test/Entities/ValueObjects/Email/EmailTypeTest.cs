using Domain.Entities;
using NUnit.Framework;

namespace Domain_Test.Entities.ValueObjects.Email
{
    [TestFixture]
    public class EmailTypeTest
    {
        private EmailDTO NewEmail(string type)
        {
            return new EmailDTO("test@test.com", type);
        }

        [Test]
        public void ThrowsExceptionIfNull()
        {
            void CreateNewEmailWithType() => NewEmail(null);

            Assert.That(CreateNewEmailWithType, Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowsExceptionIfInvalidCharacters()
        {
            void CreateNewEmailWithType() => NewEmail("#¤%&");

            Assert.That(CreateNewEmailWithType, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfToFewCharacters()
        {
            void CreateNewEmailWithType() => NewEmail("p");

            Assert.That(CreateNewEmailWithType, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfToManyCharacters()
        {
            void CreateNewEmailWithType() => NewEmail("PersonalPappa");

            Assert.That(CreateNewEmailWithType, Throws.ArgumentException);
        }

        [Test]
        public void CheckThatValidTypePasses()
        {
            string input = "Personal";
            var email = NewEmail(input);
        }
    }
}