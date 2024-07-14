namespace KitchenSimulator;

class Simulator
{
    static void Main(string[] args)
    {
        Kitchen kitchen = new(
            new Cook("Eda"),
            [
                Refrigerator.Create()
            ]
        );

        Refrigerator? refrigerator = (Refrigerator?)kitchen.GetKitchenObject<Refrigerator>();
        refrigerator?.Storage.ListObjects();
    }
}
