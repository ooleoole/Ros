using Domain.Entities;
using Domain.Services.AggregatRoots.UserServices;
using NUnit.Framework;
using System.Linq;

namespace Domain_Test.Utilities.Permissions
{
    public class PermissionsGetEntryAdminPermissions
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
        public void ThrowsExceptionIfClubDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetEntryAdminPermissons<ClubDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfRegattaDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetEntryAdminPermissons<RegattaDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfRaceEventDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetEntryAdminPermissons<RaceEventDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfSocialEventDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetEntryAdminPermissons<SocialEventDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfResultDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetEntryAdminPermissons<ResultDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void UserHasAdminPremissionsToEntries()
        {
            var socialEventList = _user.Permissions.GetEntryAdminPermissons<EntryDTO>();
            Assert.That(socialEventList.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void UserHasAdminPremissionsToBoats()
        {
            var raceEventList = _user.Permissions.GetEntryAdminPermissons<BoatDTO>();
            Assert.That(raceEventList.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void UserHasAdminPremissionsToTeams()
        {
            var resultList = _user.Permissions.GetEntryAdminPermissons<TeamDTO>();
            Assert.That(resultList.Count(), Is.GreaterThan(0));
        }
    }
}