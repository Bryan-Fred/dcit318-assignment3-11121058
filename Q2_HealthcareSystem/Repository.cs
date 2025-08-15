using System;
using System.Collections.Generic;
using System.Linq;

namespace dcit318_assignment3_11121058.Q2_HealthcareSystem
{
    // Generic repository for any reference type entity
    public class Repository<T> where T : class
    {
        private readonly List<T> items = new();

        public void Add(T item) => items.Add(item);

        public List<T> GetAll() => new List<T>(items);

        // Returns first match or null
        public T? GetById(Func<T, bool> predicate) => items.FirstOrDefault(predicate);

        // Removes first item matching predicate; returns true if removed
        public bool Remove(Func<T, bool> predicate)
        {
            var idx = items.FindIndex(x => predicate(x));
            if (idx >= 0)
            {
                items.RemoveAt(idx);
                return true;
            }
            return false;
        }
    }
}
