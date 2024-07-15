class RollableDough : Dough, IRollable
{
    public Storage Storage { get; set; } = new(5);
    public bool IsRolled { get; set; } = false;

    public RollableDough(Dough dough)
    {

    }
}