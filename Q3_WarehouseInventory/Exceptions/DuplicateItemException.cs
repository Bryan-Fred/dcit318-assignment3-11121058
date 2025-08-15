using System;

namespace dcit318_assignment3_11121058.Q3_WarehouseInventory.Exceptions
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }
    }
}
