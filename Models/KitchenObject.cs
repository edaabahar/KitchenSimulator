class KitchenObject : IKitchenObject
{

    KitchenObjectFeatures Features { get; set; } // TODO get all from this class
    // string material = string.Empty;
    // List<float> position;

    // float durability;
    // string texture = string.Empty;
    // float age;
    // float volume;
    public float Temperature { get; set; }
    public float Mass { get; set; }
    public virtual bool IsTangible { get; set; } = true;
    public string GetName()
    {
        return GetType().ToString();
    }
}
