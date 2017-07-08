using Domain.Interfaces.Entities;
using System;
using System.Text.RegularExpressions;

namespace Domain.Entities
{
    public sealed class EmailDTO : IEntityDTO, IDboInfo, IEquatable<EmailDTO>
    {
        public int Id { get; private set; }
        public string Value { get; private set; }
        public string Type { get; private set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }

        public EmailDTO(string value, string type, string sa_Info = null)
        {
            if (EmailValueValidationCheck(value) && EmailTypeValidationCheck(type))
            {
                Id = 0;
                Value = value;
                Type = type;
                Active = true;
                this.sa_Info = sa_Info;
            }
        }

        public EmailDTO(IEmail email)
        {
            if (email.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(email.Id)} cannot be less than 0.");
            ValidateInParameters(email.Value, email.Type);

            Id = email.Id;
            Value = email.Value;
            Type = email.Type;
            Active = email.Active;
            sa_Info = email.sa_Info;
        }

        private void ValidateInParameters(string value, string type)
        {
            EmailValueValidationCheck(value);
            EmailTypeValidationCheck(type);
        }

        public static bool TryParse(string email, string type, out EmailDTO result)
        {
            try
            {
                result = new EmailDTO(email, type);
                return true;
            }
            catch (ArgumentException)
            {
                result = null;
                return false;
            }
        }

        public static bool EmailTypeValidationCheck(string type)
        {
            if (type == null)
                throw new ArgumentNullException("Cannot be empty!");
            if (!Regex.IsMatch(type, @"^[A-Za-z0-9]{2,10}$"))
                throw new ArgumentException("Can only contain characters A-Za-z. Lenght must be between 2-10 characters");
            return Regex.IsMatch(type, @"^[A-Za-z]{2,10}$");
        }

        public static bool EmailValueValidationCheck(string value)
        {
            if (value == null)
                throw new ArgumentNullException("Cannot be empty!");
            if (!Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z"))
                throw new ArgumentException("Invalid Email. Valid format is 'x(a-zA-Z)@x(a-zA-Z).2-3(a-zA-Z)'");
            return Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public override bool Equals(object obj)
        {
            try
            {
                return Equals((EmailDTO)obj);
            }
            catch
            {
                return false;
            }
        }

        public bool Equals(EmailDTO other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value) && string.Equals(Type, other.Type);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Value?.GetHashCode() ?? 0) * 397) ^ (Type?.GetHashCode() ?? 0);
            }
        }

        public static bool operator ==(EmailDTO left, EmailDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EmailDTO left, EmailDTO right)
        {
            return !Equals(left, right);
        }
    }
}