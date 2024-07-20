

class Storage<T>(int capacity) : KitchenObject, IInteractive, IStorage<T> where T : KitchenObject
{
    //TODO generic storage type (storage<T>)
    int Capacity { get; set; } = capacity;
    public KitchenObject? Owner { get; set; }
    public List<T> kitchenObjects = [];

    public void ListObjects()
    {
        Console.WriteLine("Listing storage of " + Owner?.GetName());
        Console.WriteLine($"Capacity of storage is  {kitchenObjects.Count} / {Capacity}");
        kitchenObjects.ForEach(ko => Console.WriteLine("====> " + ko.GetName()));
    }

    public virtual void Add(T t)
    {
        if (Capacity == kitchenObjects.Count)
        {
            throw new StorageException("Storage is full");
        }
        if (kitchenObjects.Find(ko => ko.Equals(t)) != null)
        {
            throw new StorageException("Kitchen object exists in the storage");
        }
        kitchenObjects.Add(t);
    }

    public T? Get<Z>()
    {
        T? ko = kitchenObjects.Find(ko => ko.GetType() == typeof(Z));
        RemoveObject(ko);
        return ko;
    }
    public T? Pop()
    {
        T? kitchenObject = kitchenObjects.FirstOrDefault();
        RemoveObject(kitchenObject);
        return kitchenObject;
    }
    public T? Get(ITangible tangibleObject)
    {
        T? ko = kitchenObjects.Find(ko => ko.Equals(tangibleObject));
        RemoveObject(ko);
        return ko;
    }

    private void RemoveObject(T? ko)
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

    public virtual void InvokeInteraction(T t)
    {
        Add(t);
    }

    public bool HasStorage()
    {
        return true;
    }

    public virtual T? InvokeRetrieve(ITangible tangibleObject)
    {
        return Get(tangibleObject);
    }

    public virtual T? InvokeRetrieve<Z>()
    {
        return Get<Z>();
    }
}