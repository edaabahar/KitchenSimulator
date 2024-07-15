class Pot : Storage, ITangibleObject, IMixable
{
    public float Homogeneity { get; set; } = 0;

    public Pot() : base(3)
    {

    }
    public override KitchenObject? InvokeRetrieve(ITangibleObject tangibleObject)
    {
        return base.InvokeRetrieve(tangibleObject);
    }

    public override KitchenObject? InvokeRetrieve<T>()
    {
        return base.InvokeRetrieve<T>();
    }
}