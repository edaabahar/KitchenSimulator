class RollingPin : KitchenObject, ITangible
{
    public RollableDough RollOut(Dough dough)
    {
        return new RollableDough(dough);
    }

}