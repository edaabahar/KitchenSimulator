class Refrigerator : Appliance<KitchenObject>
{
    public static Refrigerator Create()
    {
        Refrigerator refrigerator = new(100);
        return refrigerator;
    }

    public Refrigerator(int capacity) : base(capacity)
    {

    }
}