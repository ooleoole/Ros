using Data.DatabaseModels.CompleteModel;
using System.Data.Entity;

namespace Domain_Test.Repository.FakesStubAndSo
{
    internal class FakeContext : DbContext
    {
        public FakeDbset<User> FakeDbset { get; set; }

        public FakeContext(FakeDbset<User> fakeDbset)
        {
            FakeDbset = fakeDbset;
        }
    }
}