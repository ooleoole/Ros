using Domain.Entities;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace Domain_Test.Entities.ValueObjects.Email
{
    [TestFixture]
    public class EmailValueTest
    {
        private EmailDTO NewEmail(string value)
        {
            return new EmailDTO(value, "Personal");
        }

        [Test]
        public void ThrowsExceptionIfNull()
        {
            void CreateNewEmailWithValue() => NewEmail(null);

            Assert.That(CreateNewEmailWithValue, Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowsExceptionIfNotValid()
        {
            void CreateNewEmailWithValue() => NewEmail("#¤%/@test.com");

            Assert.That(CreateNewEmailWithValue, Throws.ArgumentException);
        }

        [Test]
        public void ChecksThatValidValuePasses()
        {
            string input = "test@test.com";
            string regEx = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            Assert.IsTrue(Regex.IsMatch(input, regEx));
        }
    }
}