

class Storage<T>(int capacity) : KitchenObject, IInteractive where T : KitchenObject
{
    //TODO generic storage type (storage<T>)
    int Capacity { get; set; } = capacity;
    public KitchenObject? Owner { get; set; }
    public List<T> items = [];
    public float ThermalConductivity { get; set; } = 100;
    public void ListObjects()
    {
        Console.WriteLine("Listing storage of " + Owner?.GetName());
        Console.WriteLine($"Capacity of storage is  {items.Count} / {Capacity}");
        items.ForEach(ko => Console.WriteLine("====> " + ko.GetName()));
    }

    public virtual void Add(T t)
    {
        if (Capacity == items.Count)
        {
            throw new StorageException("Storage is full");
        }
        if (items.Find(ko => ko.Equals(t)) != null)
        {
            throw new StorageException("Kitchen object exists in the storage");
        }
        items.Add(t);
    }

    public virtual T? Get<Z>()
    {
        T? ko = items.Find(ko => ko.GetType() == typeof(Z));
        RemoveObject(ko);
        return ko;
    }
    public virtual T? Get(T t)
    {
        T? ko = items.Find(ko => ko.Equals(t));
        RemoveObject(ko);
        return ko;
    }

    public T? First()
    {
        return items.FirstOrDefault();
    }

    public T? Pop()
    {
        T? kitchenObject = items.FirstOrDefault();
        RemoveObject(kitchenObject);
        return kitchenObject;
    }
    private void RemoveObject(T? ko)
    {
        if (ko != null)
        {
            items.Remove(ko);
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

    public virtual T? InvokeRetrieve(T t)
    {
        return Get(t);
    }

    public virtual T? InvokeRetrieve<Z>()
    {
        return Get<Z>();
    }

    public void UpdateTemperature()
    {
        items.ForEach(ko =>
        {
            float diff = ko.Temperature - Temperature;
            int signature = diff < 0 ? -1 : 1;
            ko.Temperature -= signature * MathF.Log10(MathF.Abs(diff) + 1) / ko.Mass;
            Temperature += signature * MathF.Log10(MathF.Abs(diff) + 1) / ThermalConductivity;
        });
    }
}