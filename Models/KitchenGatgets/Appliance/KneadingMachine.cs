class KneadingMachine : ComplexMealStorage, IMixer
{
    public float MixEffect { get; set; }

    public void Mix(ComplexMealStorage complexMealStorage)
    {
        throw new NotImplementedException();
    }

    public void Mix()
    {
        if (ComplexMeal == null)
        {
            throw new Exception();
        }
        ComplexMeal.ApplyMix(MixEffect);
    }
}