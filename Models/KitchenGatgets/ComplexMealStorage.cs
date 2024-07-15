class ComplexMealStorage : Storage, ITangible, IComplexMealStorage
{
    public ComplexMeal ComplexMeal { get; set; } = new();
    public ComplexMealStorage() : base(100)
    {

    }

    public override void Add(ITangible tangibleObject)
    {
        if (ComplexMeal == null)
        {
            ComplexMeal = new();
        }
        ComplexMeal.Storage.Add(tangibleObject);
    }
    public override KitchenObject? InvokeRetrieve(ITangible tangibleObject)
    {
        return InvokeRetrieve();
    }

    public override KitchenObject? InvokeRetrieve<T>()
    {
        return InvokeRetrieve();
    }

    public ComplexMeal? InvokeRetrieve()
    {
        return ComplexMeal;
    }
}