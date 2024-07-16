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
        CuttingBoard cuttingBoard = new();
        kitchen.cook.Interact(refrigerator);
        // Knife knife = new();
        Apple apple = new();
        Apple apple2 = new();
        Carrot carrot = new();
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
        // kitchen.cook.Grab(knife);
        // kitchen.cook.Interact(apple, cuttingBoard);
        // kitchen.cook.Cut(cuttingBoard).Cut(cuttingBoard).Cut(cuttingBoard).Cut(cuttingBoard);
        // kitchen.cook.Cut(cuttingBoard);

        // Dough dough = new();
        // RollingPin rollingPin = new();
        // kitchen.cook.Grab(rollingPin);
        // kitchen.cook.Grab(dough);
        // kitchen.cook.Interact(dough, cuttingBoard);
        // kitchen.cook.RollOut(cuttingBoard);

        Shelf shelf = new(10);

        // kitchen.cook.Interact(rollingPin, shelf);
        // kitchen.cook.Grab(apple);
        // kitchen.cook.Interact(apple, cuttingBoard);
        // kitchen.cook.Roll(cuttingBoard);


        Pot pot = new();
        Pot pot2 = new();
        Spoon spoon = new();
        kitchen.cook.Grab(spoon);
        kitchen.cook.Interact(apple, pot);
        kitchen.cook.Interact(apple2, pot);
        kitchen.cook.Interact(carrot, pot);
        kitchen.cook.Mix(pot);
        kitchen.cook.Mix(pot);
        kitchen.cook.Interact(spoon, shelf);
        kitchen.cook.Grab(pot2);
        kitchen.cook.Retrieve(pot);
        Console.WriteLine();

        Dishwasher dishwasher = new(50);

        kitchen.cook.Grab(spoon);
        kitchen.cook.Interact(spoon, dishwasher);
        kitchen.cook.Grab(pot);
        kitchen.cook.Interact(pot, dishwasher);
        dishwasher.Clean(10);

        Console.WriteLine();


    }
}
