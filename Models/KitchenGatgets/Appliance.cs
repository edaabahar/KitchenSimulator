class Appliance<T>(int capacity) : Storage<T>(capacity) where T : KitchenObject
{
    public bool IsPowerOn { get; set; } = false;
}