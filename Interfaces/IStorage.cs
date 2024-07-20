interface IStorage<T>
{
    public T? InvokeRetrieve(ITangible tangibleObject);
    public T? InvokeRetrieve<Z>();
}