class ComplexMeal : Meal, IMixable
{
    public float Homogeneity { get; set; } = 0;
    public Storage Storage { get; set; } = new(100);

    public float DirtyEffect
    {
        get
        {
            if (Storage.kitchenObjects.Count == 0)
            {
                return 0;
            }
            float sum = 0;
            Storage.kitchenObjects.ForEach(ko => sum += ((Goods)ko).DirtyEffect);
            return sum / Storage.kitchenObjects.Count;
        }
    }
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