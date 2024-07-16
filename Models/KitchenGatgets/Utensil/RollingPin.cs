class RollingPin : Utensil
{
    public RollableDough RollOut(Dough dough)
    {
        DirtyRatio += dough.DirtyEffect;
        return new RollableDough(dough);
    }

}