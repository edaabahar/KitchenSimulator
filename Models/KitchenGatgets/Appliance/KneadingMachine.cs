class KneadingMachine() : Appliance<Meal>(1, false), IMixer
{
    public float MixEffect { get; set; }

    public void Mix()
    {
        items.ForEach(m => m.ApplyMix(MixEffect));
    }

    public void Mix(MealStorage mealStorage)
    {
        throw new NotImplementedException();
    }
}