using System;

namespace dcit318_assignment3_11121058.Q3_WarehouseInventory.Exceptions
{
    public class InvalidQuantityException : Exception
    {
        public InvalidQuantityException(string message) : base(message) { }
    }
}
