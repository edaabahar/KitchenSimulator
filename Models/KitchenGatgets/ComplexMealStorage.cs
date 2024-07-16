class ComplexMealStorage : Storage, ITangible, IComplexMealStorage
{
    public ComplexMeal? ComplexMeal { get; set; } = new();
    public bool IsClean { get; set; } = true;
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
        if (ComplexMeal == null)
        {
            throw new Exception();
        }
        IsClean = false;
        ComplexMeal? tmp = ComplexMeal;
        ComplexMeal = null;
        return tmp;
    }
}