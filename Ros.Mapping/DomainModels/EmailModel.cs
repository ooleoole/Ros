﻿using Domain.Interfaces.Entities;

namespace Ros.Mapping.DomainModels
{
    internal class EmailModel : IEmail, Interfaces.IEntityModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public string Type { get; set; }
        public bool Active { get; set; } = true;
        public string sa_Info { get; set; }
    }
}