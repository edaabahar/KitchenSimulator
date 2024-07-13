namespace KitchenSimulator;

class Simulator
{
    static void Main(string[] args)
    {
        Kitchen kitchen = new();
        kitchen.kitchenObjects = new List<KitchenObject>();
        kitchen.cook = new Cook("Eda");
    }
}
