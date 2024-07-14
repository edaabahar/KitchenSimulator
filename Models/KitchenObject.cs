using System.Collections.Generic;

class KitchenObject : IKitchenObject
{

    KitchenObjectFeatures Features { get; set; } // TODO get all from this class
    // string material = string.Empty;
    // List<float> position;

    // float durability;
    // string texture = string.Empty;
    // float age;
    // float volume;
    // float temperature;

    public string GetName()
    {
        return GetType().ToString();
    }
}
