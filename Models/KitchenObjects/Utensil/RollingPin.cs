class RollingPin : Utensil
{
    public void RollOut(Meal cm)
    {
        DirtyRatio += cm.DirtyEffect;
        cm.IsRollable = true;
    }

}