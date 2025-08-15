namespace dcit318_assignment3_11121058.Q3_WarehouseInventory.Interfaces
{
    public interface IInventoryItem
    {
        int Id { get; }
        string Name { get; }
        int Quantity { get; set; }
    }
}
