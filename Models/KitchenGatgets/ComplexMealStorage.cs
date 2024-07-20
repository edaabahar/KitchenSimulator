class ComplexMealStorage : KitchenObject, IWashable, ITangible
{
    public ComplexMeal? ComplexMeal { get; set; } = new();
    public float DirtyRatio { get; set; } = 0.0f;
    public bool IsClean()
    {
        return DirtyRatio < 1;
    }
    public void Add(Goods tangibleObject)
    {
        ComplexMeal ??= new();
        ComplexMeal.Storage.Add(tangibleObject);
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