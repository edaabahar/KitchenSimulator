class Goods : Meal
{
    public Form Form { get; set; } = new(1);
    // public string Name { get; set; } = name;
    public bool? IsWaterBased { get; set; } = null;
    public bool? IsOilBased { get; set; } = null;
    public bool? IsIonized { get; set; } = null;
    float heatCapacity;
    float heatCoefficient;
    CookingMethods cookingMethod;
    public bool HasSkin { get; set; } = true;

    public float DirtyEffect { get; set; } = 0.01f;
    public float Temperature { get; set; } = 25.0f;

    public bool IsDissolvable(Goods goods)
    {
        if (
            (Form.Type == FormTypes.Grained && goods.Form.Type == FormTypes.Liquid && (IsIonized ?? false)) ||
            (Form.Type == FormTypes.Liquid && goods.Form.Type == FormTypes.Grained && (goods.IsIonized ?? false)))
        {
            return true;
        }
        if (Form.Type == FormTypes.Liquid && goods.Form.Type == FormTypes.Liquid)
        {
            return ((IsOilBased ?? false) && (goods.IsOilBased ?? false)) || ((IsWaterBased ?? false) && (goods.IsWaterBased ?? false));
        }
        return false;
    }

    public bool IsCohesive(Goods goods)
    {
        if (
            (Form.Type == FormTypes.Grained && goods.Form.Type == FormTypes.Liquid && !(IsIonized ?? false)) ||
            (Form.Type == FormTypes.Liquid && goods.Form.Type == FormTypes.Grained && !(goods.IsIonized ?? false)))
        {
            return true;
        }
        return false;
    }

}