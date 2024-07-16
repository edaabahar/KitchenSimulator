class RollingPin : Utensil
{
    public RollableDough RollOut(ComplexMeal dough)
    {
        DirtyRatio += dough.DirtyEffect;
        return new RollableDough(dough);
    }

}