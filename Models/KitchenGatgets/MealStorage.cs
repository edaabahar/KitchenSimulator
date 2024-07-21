class MealStorage() : Storage<Meal>(1), IWashable
{
    public float DirtyRatio { get; set; } = 0.0f;
    public bool IsClean()
    {
        return DirtyRatio < 1;
    }

    public bool HasMeal()
    {
        return items.Count != 0;
    }
    public override void Add(Meal meal)
    {
        if (!HasMeal())
        {
            base.Add(meal);
            return;
        }
        Meal? m = Pop();
        m?.Expand(meal);
        Add(m);
    }
}
