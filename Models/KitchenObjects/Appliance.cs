class Appliance(Storage storage) : KitchenObject, IInteractiveObject
{
    public Storage Storage { get; set; } = storage;

    public void InvokeInteraction()
    {
        throw new NotImplementedException();
    }

    public void InvokeInteraction(IKitchenObject kitchenObject)
    {
        throw new NotImplementedException();
    }

    public bool HasStorage()
    {
        return true;
    }
}