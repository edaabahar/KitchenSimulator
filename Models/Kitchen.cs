class Kitchen(Cook cook, List<KitchenObject> kitchenObjects)
{
    public List<KitchenObject> kitchenObjects = kitchenObjects;
    public Cook cook = cook;


    public KitchenObject? GetKitchenObject<T>()
    {
        return kitchenObjects.Find(kitchenObject => kitchenObject.GetType() == typeof(T));
    }
}