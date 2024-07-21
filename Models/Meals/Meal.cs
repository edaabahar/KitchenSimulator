class Meal<T> : Meal where T : Goods, new()
{
    public Meal()
    {
        T t = new();
        Storage.Add(t);
    }
}

class Meal : KitchenObject, IMixable
{
    // float durability;
    // float temperature;
    // float quantity;
    // MeasurementUnits measurementUnit;
    public float Homogeneity { get; set; } = 0;
    public Storage<Goods> Storage { get; set; } = new(100);
    public bool? IsLiquidMixture { get; set; } = null; // todo: think about it again
    public float Consistency { get; set; } = 0;
    // Todo: public float Color {get; set; } = 0;
    public bool IsRolled { get; set; } = false;
    public bool HasRollOutFeatures { get; set; } = false;
    public bool IsRollable { get; set; } = false;

    public new float Temperature
    {
        get
        {
            if (Storage.items.Count == 0)
            {
                return 0.0f;
            }
            float sum = 0.0f;
            float totalMass = Storage.items.Sum(goods => goods.Mass);
            Storage.items.ForEach(goods => sum += goods.Temperature * goods.Mass / totalMass);
            return sum;
        }
    }
    public float DirtyEffect
    {
        get
        {
            if (Storage.items.Count == 0)
            {
                return 0;
            }
            float sum = 0;
            Storage.items.ForEach(ko => sum += ko.DirtyEffect);
            return sum / Storage.items.Count;
        }
    }

    public override bool IsTangible
    {
        get
        {
            return Storage.items.Count == 1 || IsRolled;
        }
    }

    public Meal()
    {

    }

    public void Expand(Meal meal)
    {
        meal.Storage.items.ForEach(g => Storage.Add(g));
    }

    public void ForEach(Action<Goods> action)
    {
        Storage.items.ForEach(action);
    }
    public void ApplyMix(float mixEffect)
    {
        if (Storage.items.Count == 1)
        {
            Homogeneity = 1;
            return;
        }
        Homogeneity += 2.0f / Storage.items.Count * mixEffect;
        if (Homogeneity >= 1)
        {
            Homogeneity = 1;
        }
        for (int i = 0; i < Storage.items.Count; i++)
        {
            Goods goods1 = Storage.items[i];
            for (int y = i + 1; y < Storage.items.Count; y++)
            {
                Goods goods2 = Storage.items[y];
                if (goods1.IsDissolvable(goods2))
                {
                    IsLiquidMixture = true;
                    continue;
                }
                if (goods1.IsCohesive(goods2))
                {
                    HasRollOutFeatures = true;
                    // Add more parameter, Temperature.
                    Consistency += mixEffect;
                    continue;
                }
            }
        }
    }
}