class RollableDough : ComplexMeal, IRollable
{
    public bool IsRolled { get; set; } = false;

    public RollableDough(ComplexMeal dough)
    {
        Storage.Add(dough);
    }
}