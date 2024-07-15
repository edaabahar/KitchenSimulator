

class Storage(int capacity) : KitchenObject, IInteractiveObject, IStorageObject
{
    //TODO generic storage type (storage<T>)
    int Capacity { get; set; } = capacity;
    public KitchenObject? Owner { get; set; }
    public List<KitchenObject> kitchenObjects = [];

    public void ListObjects()
    {
        Console.WriteLine("Listing storage of " + Owner?.GetName());
        Console.WriteLine($"Capacity of storage is  {kitchenObjects.Count} / {Capacity}");
        kitchenObjects.ForEach(ko => Console.WriteLine("====> " + ko.GetName()));
    }

    public void Add(ITangibleObject tangibleObject)
    {
        if (Capacity == kitchenObjects.Count)
        {
            throw new StorageException("Storage is full");
        }
        if (kitchenObjects.Find(ko => ko.Equals(tangibleObject)) != null)
        {
            throw new StorageException("Kitchen object exists in the storage");
        }
        kitchenObjects.Add((KitchenObject)tangibleObject);
    }

    public KitchenObject? Get<T>()
    {
        KitchenObject? ko = kitchenObjects.Find(ko => ko.GetType() == typeof(T));
        RemoveObject(ko);
        return ko;
    }
    public KitchenObject? Pop()
    {
        KitchenObject? kitchenObject = kitchenObjects.FirstOrDefault();
        RemoveObject(kitchenObject);
        return kitchenObject;
    }
    public KitchenObject? Get(ITangibleObject tangibleObject)
    {
        KitchenObject? ko = kitchenObjects.Find(ko => ko.Equals(tangibleObject));
        RemoveObject(ko);
        return ko;
    }

    private void RemoveObject(KitchenObject? ko)
    {
        if (ko != null)
        {
            kitchenObjects.Remove(ko);
        }
    }

    public void InvokeInteraction()
    {
        ListObjects();
    }

    public void InvokeInteraction(ITangibleObject tangibleObject)
    {
        Add(tangibleObject);
    }

    public void InvokeInteraction(Goods goods)
    {
        Add(goods);
    }

    public bool HasStorage()
    {
        return true;
    }

    public KitchenObject? InvokeRetrieve(ITangibleObject tangibleObject)
    {
        return Get(tangibleObject);
    }

    public KitchenObject? InvokeRetrieve<T>()
    {
        return Get<T>();
    }
}