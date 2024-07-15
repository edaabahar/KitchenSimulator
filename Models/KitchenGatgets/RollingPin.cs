class RollingPin : KitchenObject, ITangibleObject
{
    public RollableDough RollOut(Dough dough)
    {
        return new RollableDough(dough);
    }

}