class ComplexMeal : Meal, IMixable
{
    public float Homogeneity { get; set; } = 0;
    public Storage Storage { get; set; } = new(100);

    public ComplexMeal()
    {
    }

    public void Mix(float mixEffect)
    {
        if (Storage.kitchenObjects.Count == 1)
        {
            Homogeneity = 1;
            return;
        }
        Homogeneity += 2.0f / Storage.kitchenObjects.Count * mixEffect;
        if (Homogeneity >= 1)
        {
            Homogeneity = 1;
            return;
        }
    }
}