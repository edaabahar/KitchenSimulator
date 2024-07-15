class Refrigerator(int capacity) : Appliance(capacity)
{
    public static Refrigerator Create()
    {
        Refrigerator refrigerator = new(100);
        return refrigerator;
    }
}