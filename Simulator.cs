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

        // kitchen.cook.Grab(apple);
        // kitchen.cook.Interact(apple, refrigerator);
        // kitchen.cook.Interact(apple2, refrigerator);

        // // kitchen.cook.Interact(x, refrigerator);
        // kitchen.cook.Interact(refrigerator);
        // // kitchen.cook.Retrieve<Apple>(refrigerator);
        // kitchen.cook.Interact(refrigerator);
        // // kitchen.cook.Retrieve(x, refrigerator);
        // kitchen.cook.Interact(refrigerator);

        // Knife knife = new();
        CuttingBoard cuttingBoard = new();
        // kitchen.cook.Grab(knife);
        // kitchen.cook.Interact(apple, cuttingBoard);
        // kitchen.cook.Cut(cuttingBoard).Cut(cuttingBoard).Cut(cuttingBoard).Cut(cuttingBoard);
        // kitchen.cook.Cut(cuttingBoard);

        Dough dough = new();
        RollingPin rollingPin = new();
        kitchen.cook.Grab(rollingPin);
        kitchen.cook.Grab(dough);
        kitchen.cook.Interact(dough, cuttingBoard);
        kitchen.cook.RollOut(cuttingBoard);



    }
}
