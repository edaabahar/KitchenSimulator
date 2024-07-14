interface IStorageObject
{
    public KitchenObject? InvokeRetrieve(ITangibleObject tangibleObject);
    public KitchenObject? InvokeRetrieve<T>();
}