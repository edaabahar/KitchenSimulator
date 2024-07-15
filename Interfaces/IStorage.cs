interface IStorage
{
    public KitchenObject? InvokeRetrieve(ITangible tangibleObject);
    public KitchenObject? InvokeRetrieve<T>();
}