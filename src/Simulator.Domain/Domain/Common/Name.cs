using System;
using System.Linq;
using EventFlow.ValueObjects;

namespace Simulator.Domain.Common
{
    public sealed class Name : SingleValueObject<string>
    {
        public Name(string value) : base(ValidateAndConvert(value)) { }

        public override string ToString()
        {
            return string.Join(" ", this.Value
                .Split(' ')
                .Select(token => char.ToUpper(token[0]) + token.Substring(1)));
        }

        private static string ValidateAndConvert(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) throw new ArgumentNullException(nameof(value));
            return value.ToLower();
        }

        public static implicit operator Name(string value)
        {
            return new Name(value);
        }

        public static implicit operator string(Name name)
        {
            return name.Value;
        }
    }
}