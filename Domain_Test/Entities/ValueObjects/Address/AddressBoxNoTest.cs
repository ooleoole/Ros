using Domain.Entities;
using NUnit.Framework;
using System;

namespace Domain_Test.Entities.ValueObjects.Address
{
    [TestFixture]
    public class AddressBoxNoTest
    {
        private AddressDTO NewAddress(int? boxNo)
        {
            return new AddressDTO(country: "Sweden", city: "Göteborg", street: "Ebbe Lieberathsgatan 18 c", zipCode: "41265", type: "Invoice", boxNo: boxNo);
        }

        [Test]
        public void ThrowsExceptionIfBoxNoIsLessThanOne()
        {
            void CreateNewAddressWithBoxNo() => NewAddress(0);

            Assert.Throws(typeof(ArgumentOutOfRangeException), CreateNewAddressWithBoxNo);
        }

        [Test]
        public void ThrowsExceptionIfBoxNoIsGreaterThanTenThousand()
        {
            void CreateNewAddressWithBoxNo() => NewAddress(10001);

            Assert.Throws(typeof(ArgumentOutOfRangeException), CreateNewAddressWithBoxNo);
        }

        [Test]
        public void BoxNoCanBeNull()
        {
            int? boxNo = null;
            AddressDTO address = NewAddress(boxNo);

            Assert.That(address.BoxNo, Is.Null);
        }

        [Test]
        public void BoxNoCanBeOne()
        {
            int? boxNo = 1;
            AddressDTO address = NewAddress(boxNo);

            Assert.That(address.BoxNo, Is.EqualTo(boxNo));
        }

        [Test]
        public void BoxNoCanBeTenThousand()
        {
            int? boxNo = 10000;
            AddressDTO address = NewAddress(boxNo);

            Assert.That(address.BoxNo, Is.EqualTo(10000));
        }
    }
}