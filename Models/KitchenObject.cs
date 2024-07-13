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
    string name = "Kitchen object";



    public string GetName()
    {
        return name;
    }
}
