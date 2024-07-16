class Spoon : Utensil, IMixer
{
    public float MixEffect { get; set; } = 0.1f;

    public void Mix(ComplexMealStorage complexMealStorage)
    {
        if (complexMealStorage.ComplexMeal.Storage.kitchenObjects.Count == 0)
        {
            throw new Exception();
        }
        complexMealStorage.ComplexMeal.Mix(MixEffect);

        complexMealStorage.ComplexMeal.Storage.kitchenObjects.ForEach(ko =>
        {
            DirtyRatio += ((Goods)ko).DirtyEffect / complexMealStorage.ComplexMeal.Storage.kitchenObjects.Count;
        });
    }
}
