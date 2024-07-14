using System.Collections.Generic;

class KitchenObject : IKitchenObject
{
    string material = string.Empty;
    List<float> position;

    float durability;
    string texture = string.Empty;
    float age;
    float capacity;
    float volume;
    float temperature;

    public string GetName()
    {
        return this.GetType().ToString();
    }
}
