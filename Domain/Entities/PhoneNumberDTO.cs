using Domain.Interfaces.Entities;
using Domain.Utilities;
using System;
using System.Linq;

namespace Domain.Entities
{
    public sealed class PhoneNumberDTO : IEntityDTO, IDboInfo, IEquatable<PhoneNumberDTO>
    {
        public static readonly int ValueMinLength = 8;
        public static readonly int ValueMaxLength = 10;
        public static readonly int TypeMinLength = 3;
        public static readonly int TypeMaxLength = 10;

        public int Id { get; private set; }
        public string Value { get; private set; }
        public string Type { get; private set; }
        public bool Active { get; set; }
        public string sa_Info { get; set; }

        public PhoneNumberDTO(string value, string type, string sa_Info = null)
        {
            ValidateInParameters(value, type);

            Id = 0;
            Value = value;
            Type = type;
            Active = true;
            this.sa_Info = sa_Info;
        }

        public PhoneNumberDTO(IPhoneNumber phoneNumber)
        {
            if (phoneNumber.Id < 0)
                throw new ArgumentOutOfRangeException($"{nameof(phoneNumber.Id)} cannot be less than 0.");
            ValidateInParameters(phoneNumber.Value, phoneNumber.Type);

            Id = phoneNumber.Id;
            Value = phoneNumber.Value;
            Type = phoneNumber.Type;
            Active = phoneNumber.Active;
            sa_Info = phoneNumber.sa_Info;
        }

        private void ValidateInParameters(string value, string type)
        {
            ValidateValue(value);

            ValidateType(type);
        }

        private static void ValidateValue(string value)
        {
            NullCheck.ThrowArgumentNullEx(value);
            if (ValueMinLength > value.Length || value.Length > ValueMaxLength)
                throw new ArgumentException($"{nameof(value)} must have a length between {ValueMinLength} and {ValueMaxLength}.");
            if (ValueDoesNotContainOnlyDigits())
                throw new ArgumentException($"{nameof(value)} can only contain digits.");
            if (ValueDoesNotStartWithZero())
                throw new ArgumentException($"{nameof(value)} must start with zero.");

            bool ValueDoesNotContainOnlyDigits() => value.Any(valueCharacter => !char.IsDigit(valueCharacter));
            bool ValueDoesNotStartWithZero() => value[0] != '0';
        }

        private static void ValidateType(string type)
        {
            NullCheck.ThrowArgumentNullEx(type);
            if (TypeMinLength > type.Length || type.Length > TypeMaxLength)
                throw new ArgumentException($"{nameof(type)} must have a length between {TypeMinLength} and {TypeMaxLength}.");
            if (TypeStartsWithWhiteSpace())
                throw new ArgumentException($"{nameof(type)} cannot start with a white-space character.");
            if (TypeEndsWithWhiteSpace())
                throw new ArgumentException($"{nameof(type)} cannot end with a white-space character.");
            if (TypeStartsWithDigit())
                throw new ArgumentException($"{nameof(type)} cannot start with a digit.");
            if (TypeContainsIllegalCharacters())
                throw new ArgumentException($"{nameof(type)} can only contain letters, digits and white-space characters.");

            bool TypeStartsWithWhiteSpace() => type[0] == ' ';
            bool TypeEndsWithWhiteSpace() => type[type.Length - 1] == ' ';
            bool TypeStartsWithDigit() => char.IsDigit(type[0]);
            bool TypeContainsIllegalCharacters() => type.Any(typeCharacter =>
                                                             !char.IsLetter(typeCharacter) &&
                                                             !char.IsDigit(typeCharacter) &&
                                                             typeCharacter != ' ');
        }

        public override bool Equals(object obj)
        {
            try
            {
                return Equals((PhoneNumberDTO)obj);
            }
            catch
            {
                return false;
            }
        }

        public bool Equals(PhoneNumberDTO other)
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

        public static bool operator ==(PhoneNumberDTO left, PhoneNumberDTO right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PhoneNumberDTO left, PhoneNumberDTO right)
        {
            return !Equals(left, right);
        }
    }
}