using System;

namespace Domain.Utilities
{
    public static class NullCheck
    {
        public static void ThrowArgumentNullEx(params object[] inputs)
        {
            foreach (var input in inputs)
                if (input == null)
                    throw new ArgumentNullException(nameof(input));
        }
    }
}