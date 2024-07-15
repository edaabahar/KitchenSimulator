class RollableDough : Dough, IRollable
{
    public Storage Storage { get; set; } = new(5);

    public RollableDough(Dough dough)
    {

    }
}