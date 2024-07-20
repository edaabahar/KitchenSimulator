class ComplexMeal : Meal, IMixable
{
    public float Homogeneity { get; set; } = 0;
    public Storage<Goods> Storage { get; set; } = new(100);
    public bool? IsLiquidMixture { get; set; } = null;
    public float Consistency { get; set; } = 0;
    // Todo: public float Color {get; set; } = 0;

    public float DirtyEffect
    {
        get
        {
            if (Storage.kitchenObjects.Count == 0)
            {
                return 0;
            }
            float sum = 0;
            Storage.kitchenObjects.ForEach(ko => sum += ko.DirtyEffect);
            return sum / Storage.kitchenObjects.Count;
        }
    }

    public void ApplyMix(float mixEffect)
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
        }
        for (int i = 0; i < Storage.kitchenObjects.Count; i++)
        {
            Goods goods1 = Storage.kitchenObjects[i];
            for (int y = i + 1; y < Storage.kitchenObjects.Count; y++)
            {
                Goods goods2 = Storage.kitchenObjects[y];
                if (goods1.IsDissolvable(goods2))
                {
                    IsLiquidMixture = true;
                    continue;
                }
                if (goods1.IsCohesive(goods2))
                {
                    // Add more parameter, Temperature.
                    Consistency += mixEffect;
                    continue;
                }
            }
        }
    }
}