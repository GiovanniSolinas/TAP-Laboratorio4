using System;
using System.Collections.Generic;

namespace MacroExpansion
{
    public static class ExpansionMethod
    {
        public static IEnumerable<T> MacroExpansion<T>(this IEnumerable<T> sequence, T value, IEnumerable<T> newValues)
        {
            if (sequence == null)
                throw new ArgumentNullException($"{nameof(sequence)} cannot be null");
            if (newValues == null)
                throw new ArgumentNullException($"{nameof(newValues)} cannot be null");
            return SafeMacroExpansion();

            IEnumerable<T> SafeMacroExpansion()
            {
                foreach (var elem in sequence)
                if (elem.Equals(value))
                    foreach (var x in newValues)
                        yield return x;
                else
                    yield return elem;
            }
        }
    }
}
