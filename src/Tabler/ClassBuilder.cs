using System;
using System.Collections.Generic;
using System.Linq;

namespace Tabler
{
    public class ClassBuilder
    {
        public List<string> ClassNames = new List<string>();

        public ClassBuilder(string classNames = null)
        {
            if (!string.IsNullOrWhiteSpace(classNames))
                ClassNames = classNames
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Distinct()
                    .ToList();
        }

        public ClassBuilder Add(string className)
        {
            if (!string.IsNullOrWhiteSpace(className) && !ClassNames.Contains(className))
                ClassNames.Add(className);

            return this;
        }

        public ClassBuilder AddIf(string className, bool isOk)
        {
            return isOk ? Add(className) : this;
        }

        public ClassBuilder AddCompare<T>(T compare, Dictionary<T, string> with)
        {
            foreach (var kvp in with)
            {
                AddCompare(kvp.Value, compare, kvp.Key);
            }

            return this;
        }
        public ClassBuilder AddCompare<T>(string className, T compare, T with)
        {
            return AddIf(className, compare.Equals(with));
        }

        public ClassBuilder Remove(string className)
        {
            ClassNames.RemoveAll(c => c.Equals(className, StringComparison.InvariantCultureIgnoreCase));
            return this;
        }

        public override string ToString()
        {
            return string.Join(" ", ClassNames
                .Distinct()
                .Where(c => !string.IsNullOrWhiteSpace(c)));
        }
    }
}