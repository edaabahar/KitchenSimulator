class ComplexMealStorage : Storage, ITangible, IComplexMealStorage, IWashable
{
    public ComplexMeal? ComplexMeal { get; set; } = new();
    public float DirtyRatio { get; set; } = 0.0f;
    public bool IsClean()
    {
        return DirtyRatio < 1;
    }
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
        DirtyRatio = 1f;
        ComplexMeal? tmp = ComplexMeal;
        ComplexMeal = null;
        return tmp;
    }
}