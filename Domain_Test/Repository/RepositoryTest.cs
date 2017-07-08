using Data.DatabaseModels.CompleteModel;
using Domain.Interfaces.Repositories;
using Domain.Repositories;
using Domain.Utilities;
using Domain_Test.Repository.FakesStubAndSo;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace Domain_Test
{
    [TestFixture]
    public class RepositoryTest
    {
        private IEagerDisconnectedRepository<User> _sut;
        private ObservableCollection<User> _testData;
        private FakeContext _fakeContext;

        [OneTimeSetUp]
        public void Setup()
        {
            var userOne = new User()
            {
                Id = 1,
                Active = true,
                Address = new Address()
                {
                    Id = 1,
                    Active = true,
                    BoxNo = 4,
                    City = "Gbg",
                    Clubs = new List<Club>(),
                    Country = "Swe",
                },
                AddressId = 1,
                Clubs_Users_UserRoles_Junctions = new List<Clubs_Users_UserRoles_Junctions>(),
                Entries = new List<Entry>(),
                //Events_Users_UserRoles_Junctions = new List<Events_Users_UserRoles_Junctions>(),
                FirstName = "Sven",
                ICE_Name = "Berra",
                ICE_PhoneNumber = "0706755407",
            };
            var userTwo = new User()
            {
                Id = 2,
                Active = true,
                Address = new Address()
                {
                    Id = 1,
                    Active = true,
                    BoxNo = 4,
                    City = "Gbg",
                    Clubs = new List<Club>(),
                    Country = "Swe",
                },
                AddressId = 1,
                Clubs_Users_UserRoles_Junctions = new List<Clubs_Users_UserRoles_Junctions>(),
                Entries = new List<Entry>(),
                //Events_Users_UserRoles_Junctions = new List<Events_Users_UserRoles_Junctions>(),
                FirstName = "Ola",
                ICE_Name = "Kalle",
                ICE_PhoneNumber = "0706755407",
            };
            var userThree = new User()
            {
                Id = 3,
                Active = true,
                Address = new Address()
                {
                    Id = 1,
                    Active = true,
                    BoxNo = 4,
                    City = "Gbg",
                    Clubs = new List<Club>(),
                    Country = "Swe",
                },
                AddressId = 1,
                Clubs_Users_UserRoles_Junctions = new List<Clubs_Users_UserRoles_Junctions>(),
                Entries = new List<Entry>(),
                //Events_Users_UserRoles_Junctions = new List<Events_Users_UserRoles_Junctions>(),
                FirstName = "Mari",
                ICE_Name = "poul",
                ICE_PhoneNumber = "0706755407",
            };

            _testData = new ObservableCollection<User>
            {
                userOne,userTwo,userThree
            };

            Database.SetInitializer(new CreateDatabaseIfNotExists<FakeContext>());
            _fakeContext = new FakeContext(new FakeDbset<User>(_testData));
            _sut = new EagerDisconnectedRepository<User>(new Context<User>(_fakeContext, _fakeContext.FakeDbset));
        }

        [Test]
        public void AddThrowsExeptionIfEntityIsNull()
        {
            void CheckFunc()
            {
                User entity = null;
                _sut.Add(entity);
            }

            Assert.Throws(typeof(ArgumentNullException), CheckFunc);
        }

        [Test]
        public void DisconnectedRepoAddTest()
        {
            var user = new User() { Id = 5, FirstName = "Ola" };
            _sut.Add(user);
            Assert.Contains(user, _sut.GetAll().ToArray());
        }

        [Test]
        public void FindByWorksWithLambda()
        {
            var userOne = _testData.FirstOrDefault(u => u.Id == 1);
            var user = _sut.FindBy(u => u.Id == 1).FirstOrDefault();
            Assert.IsTrue(user == userOne);
        }

        [Test]
        public void FindByReturnsAllAccurensesWherePredictIsMatching()
        {
            var users = _sut.FindBy(u => u.FirstName == "Ola");
            Assert.IsTrue(users.Count() == 1);
        }

        [Test]
        public void FindByThrowsExeptionIfLambdaIsNull()
        {
            void CheckFunc() => _sut.FindBy(null);

            Assert.Throws(typeof(ArgumentNullException), CheckFunc);
        }

        [Test]
        public void DeleteTest()
        {
            var user = _sut.GetAll().FirstOrDefault();
            _sut.Delete(user);
            Assert.IsFalse(_sut.GetAll().Contains(user));
        }

        [Test]
        public void DeleteThrowsExeptionIfEntityIsNull()
        {
            void CheckFunc()
            {
                User entity = null;
                _sut.Delete(entity);
            }

            Assert.Throws(typeof(ArgumentNullException), CheckFunc);
        }

        [Test]
        public void GetAllTest()
        {
            var fakeContext = new FakeContext(new FakeDbset<User>(_testData));
            var sut = new EagerDisconnectedRepository<User>(new Context<User>(fakeContext, fakeContext.FakeDbset));
            var entities = sut.GetAll();
            Assert.AreEqual(entities, _testData);
        }

        [Test]
        public void NoTrackingQueriesDoNotCacheObjects()
        {
            Assert.AreEqual(0, _fakeContext.ChangeTracker.Entries().Count());
        }
    }
}