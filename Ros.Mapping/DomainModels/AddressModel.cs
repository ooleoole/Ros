using Domain.Interfaces.Entities;

namespace Ros.Mapping.DomainModels
{
    public class AddressModel : IAddress, Interfaces.IEntityModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int? BoxNo { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; } = true;
        public string sa_Info { get; set; }
    }
}