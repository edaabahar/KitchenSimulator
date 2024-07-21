class RollingPin : Utensil
{
    public void RollOut(ComplexMeal cm)
    {
        DirtyRatio += cm.DirtyEffect;
        cm.IsRollable = true;
    }

}