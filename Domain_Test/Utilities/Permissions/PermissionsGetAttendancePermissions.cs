using Domain.Entities;
using Domain.Services.AggregatRoots.UserServices;
using NUnit.Framework;
using System.Linq;

namespace Domain_Test.Utilities.Permissions
{
    [TestFixture]
    public class PermissionsGetAttendancePermissions
    {
        private UserDTO _user;

        [SetUp]
        public void SetUp()
        {
            using (var userService = new UserService())
            {
                _user = userService.EagerDisconnectedService.FindBy(u => u.Id == 1).First();
            }
        }

        [Test]
        public void ThrowsExceptionIfEntryDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetAttendancePermissions<EntryDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfBoatDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetAttendancePermissions<BoatDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfTeamDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetAttendancePermissions<TeamDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfClubDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetAttendancePermissions<ClubDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfRegattaDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetAttendancePermissions<RegattaDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void UserHasAttendancePremissionsToRaceEvents()
        {
            var raceEventList = _user.Permissions.GetClubAdminPermissons<RaceEventDTO>();
            Assert.That(raceEventList.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void UserHasAttendancePremissionsToSocialEvents()
        {
            var socialEventList = _user.Permissions.GetClubAdminPermissons<SocialEventDTO>();
            Assert.That(socialEventList.Count(), Is.GreaterThan(0));
        }
    }
}