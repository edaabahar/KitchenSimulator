namespace KitchenSimulator;

class Simulator
{
    static void Main(string[] args)
    {
        Kitchen kitchen = new(
            new Cook("Eda"),
            [
            ]
        );

        CuttingBoard cuttingBoard = new();
        Shelf shelf = new(10);
        Pot pot = new();
        Dishwasher dishwasher = new(50);

        Meal apple = new Meal<Apple>();
        Meal apple2 = new Meal<Apple>();
        Meal carrot = new Meal<Carrot>();

        Console.WriteLine();
        kitchen.cook.Put(apple, pot);
        kitchen.cook.Put(apple2, pot);
        kitchen.cook.Put(carrot, pot);
        Console.WriteLine();

        kitchen.cook.Grab(pot);
        dishwasher.Clean(10);
        Console.WriteLine();


    }
}
