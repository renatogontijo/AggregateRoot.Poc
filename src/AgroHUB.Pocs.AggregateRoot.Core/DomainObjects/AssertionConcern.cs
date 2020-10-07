using AggregateRoot.Core.Exceptions;

namespace AggregateRoot.Core.DomainObjects
{
    public static class AssertionConcern
    {
        public static void IsEqual(object obj1, object obj2, string message)
        {
            if (!obj1.Equals(obj2))
                throw new DomainException(message);
        }

        public static void NotEqual(object obj1, object obj2, string message)
        {
            if (obj1.Equals(obj2))
                throw new DomainException(message);
        }

        public static void NotEmpty(string value, string message)
        {
            if (string.IsNullOrEmpty(value))
                throw new DomainException(message);
        }

        public static void GreatherThan(decimal value, decimal greatherThanValue, string message)
        {
            if (value < greatherThanValue)
                throw new DomainException(message);
        }

        public static void MinimunLength(string value, int minLength, string message)
        {
            var length = value?.Length ?? 0;
            if (length < minLength)
                throw new DomainException(message);
        }

        public static void MaximunLength(string value, int maxLength, string message)
        {
            var length = value?.Length ?? 0;
            if (length > maxLength)
                throw new DomainException(message);
        }

        public static void IsTrue(bool value, string message)
        {
            if (!value)
                throw new DomainException(message);
        }
    }
}
