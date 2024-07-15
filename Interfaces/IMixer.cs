interface IMixer
{
    public float MixEffect { get; set; }
    public void Mix(ComplexMealStorage complexMealStorage)
    {
        complexMealStorage.ComplexMeal.Mix(MixEffect);
    }
}