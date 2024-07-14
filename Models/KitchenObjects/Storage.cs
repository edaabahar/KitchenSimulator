

class Storage(int capacity) : KitchenObject
{
    int Capacity { get; set; } = capacity;
    public KitchenObject? Owner { get; set; }
    List<KitchenObject> kitchenObjects = [];

    public void ListObjects()
    {
        Console.WriteLine("Listing storage of " + Owner?.GetName());
        Console.WriteLine($"Capacity of storage is  {kitchenObjects.Count()} / {Capacity}");
        kitchenObjects.ForEach(ko => Console.WriteLine("====> " + ko.GetName()));
    }
}