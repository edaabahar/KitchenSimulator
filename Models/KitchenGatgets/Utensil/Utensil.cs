
class Utensil : KitchenObject, IWashable, ITangible
{
    public bool IsClean()
    {
        return DirtyRatio < 1;
    }
    public float DirtyRatio { get; set; } = 0.0f;
}