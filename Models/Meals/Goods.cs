using System.Runtime.InteropServices;

class Goods : Meal
{
    public Form Form { get; set; }
    float heatCapacity;
    float heatCoefficient;
    CookingMethods cookingMethod;
    public bool HasSkin { get; set; } = true;

    public float DirtyEffect { get; set; } = 0.01f;

    public Goods()
    {
        Form = new Form(1);
    }
    public Goods(float cutCoefficient)
    {
        Form = new Form(cutCoefficient);
    }

    public void Merge(Goods goods)
    {
        if (Form.Type != FormTypes.Grained || Form.Type != FormTypes.Liquid)
        {
            return;
        }


        return;
    }
}