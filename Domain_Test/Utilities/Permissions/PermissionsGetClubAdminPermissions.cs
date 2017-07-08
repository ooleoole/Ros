using Domain.Entities;
using Domain.Services.AggregatRoots.UserServices;
using NUnit.Framework;
using System.Linq;

namespace Domain_Test.Utilities.Permissions
{
    [TestFixture]
    public class PermissionsGetClubAdminPermissions
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
            void TestMethod() => _user.Permissions.GetClubAdminPermissons<EntryDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfBoatDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetClubAdminPermissons<BoatDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfTeamDTOIsUsed()
        {
            void TestMethod() => _user.Permissions.GetClubAdminPermissons<TeamDTO>();

            Assert.That(TestMethod, Throws.ArgumentException);
        }

        [Test]
        public void UserHasAdminPremissionsToClubs()
        {
            var clubList = _user.Permissions.GetClubAdminPermissons<ClubDTO>();
            Assert.That(clubList.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void UserHasAdminPremissionsToRegattas()
        {
            var regattaList = _user.Permissions.GetClubAdminPermissons<RegattaDTO>();
            Assert.That(regattaList.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void UserHasAdminPremissionsToRaceEvents()
        {
            var raceEventList = _user.Permissions.GetClubAdminPermissons<RaceEventDTO>();
            Assert.That(raceEventList.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void UserHasAdminPremissionsToSocialEvents()
        {
            var socialEventList = _user.Permissions.GetClubAdminPermissons<SocialEventDTO>();
            Assert.That(socialEventList.Count(), Is.GreaterThan(0));
        }

        [Test]
        public void UserHasAdminPremissionsToResults()
        {
            var resultList = _user.Permissions.GetClubAdminPermissons<ResultDTO>();
            Assert.That(resultList.Count(), Is.GreaterThan(0));
        }
    }
}