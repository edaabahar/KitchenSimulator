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
        kitchen.cook.Interact(refrigerator);
        Apple apple = new();
        Apple apple2 = new();
        // Goods x = new();

        // kitchen.cook.Grab(apple);
        // kitchen.cook.Grab(apple2);

        kitchen.cook.Grab(apple);
        // kitchen.cook.Interact(apple, refrigerator);
        // kitchen.cook.Interact(apple2, refrigerator);

        // // kitchen.cook.Interact(x, refrigerator);
        // kitchen.cook.Interact(refrigerator);
        // // kitchen.cook.Retrieve<Apple>(refrigerator);
        // kitchen.cook.Interact(refrigerator);
        // // kitchen.cook.Retrieve(x, refrigerator);
        // kitchen.cook.Interact(refrigerator);

        Knife knife = new();
        kitchen.cook.Grab(knife);
        kitchen.cook.Cutting().Cutting().Cutting().Cutting();
        kitchen.cook.Cutting();
    }
}
