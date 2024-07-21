class Spoon : Utensil, IMixer
{
    public float MixEffect { get; set; } = 0.1f;

    public void Mix(MealStorage mealStorage)
    {
        if (!mealStorage.HasMeal())
        {
            throw new Exception();
        }
        mealStorage.items.ForEach(m =>
        {
            m.ApplyMix(MixEffect);
            DirtyRatio += m.DirtyEffect;
        });
    }

    public void Mix()
    {
        throw new NotImplementedException();
    }
}
