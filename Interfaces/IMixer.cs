interface IMixer
{
    public float MixEffect { get; set; }
    public void Mix(ComplexMealStorage complexMealStorage)
    {
        if (complexMealStorage.ComplexMeal.Storage.kitchenObjects.Count == 0)
        {
            throw new Exception();
        }
        complexMealStorage.ComplexMeal.Mix(MixEffect);
    }
}