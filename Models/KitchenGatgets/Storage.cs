

class Storage(int capacity) : KitchenObject, IInteractive, IStorage
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

    public virtual void Add(ITangible tangibleObject)
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
    public KitchenObject? Get(ITangible tangibleObject)
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

    public virtual void InvokeInteraction(ITangible tangibleObject)
    {
        Add(tangibleObject);
    }

    public bool HasStorage()
    {
        return true;
    }

    public virtual KitchenObject? InvokeRetrieve(ITangible tangibleObject)
    {
        return Get(tangibleObject);
    }

    public virtual KitchenObject? InvokeRetrieve<T>()
    {
        return Get<T>();
    }
}