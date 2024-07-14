class Refrigerator(Storage storage) : Appliance(storage)
{
    public static Refrigerator Create()
    {
        Storage storage = new(100);
        Refrigerator refrigerator = new(storage);
        refrigerator.Storage.Owner = refrigerator;
        return refrigerator;
    }
}