class Appliance(Storage storage) : KitchenObject, IInteractiveObject, IStorageObject
{
    public Storage Storage { get; set; } = storage;

    public void InvokeInteraction()
    {
        Storage.ListObjects();
    }

    public void InvokeInteraction(ITangibleObject tangibleObject)
    {
        Storage.Add(tangibleObject);
    }

    public bool HasStorage()
    {
        return true;
    }

    public KitchenObject? InvokeRetrieve(ITangibleObject tangibleObject)
    {
        return Storage.Get(tangibleObject);
    }

    public KitchenObject? InvokeRetrieve<T>()
    {
        return Storage.Get<T>();
    }
}