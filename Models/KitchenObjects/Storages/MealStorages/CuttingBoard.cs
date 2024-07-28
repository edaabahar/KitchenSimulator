
class CuttingBoard : MealStorage, IWashable
{
    public CuttingBoard()
    {

    }
    public void Cut(Knife knife)
    {
        Meal? meal = Pop();
        if (meal == null)
        {
            return;
        }
        meal.ForEach(g =>
        {
            knife.Cut(g);
            DirtyRatio += g.DirtyEffect;
        });
        Add(meal);
    }
    public void RollOut(RollingPin rollingPin)
    {
        Meal? cm = Pop();
        if (cm == null || !cm.HasRollOutFeatures)
        {
            return;
        }
        rollingPin.RollOut(cm);
        Add(cm);
        DirtyRatio += cm.DirtyEffect;
    }
    public void Roll()
    {
        Meal? rollable = Pop();
        if (rollable == null || !rollable.IsRollable)
        {
            return;
        }
        rollable.IsRolled = true;
        Add(rollable);
        DirtyRatio += rollable.DirtyEffect;
    }

    public bool HasRollable()
    {
        Meal? cm = items.FirstOrDefault();
        if (cm == null)
        {
            return false;
        }

        return cm.IsRollable;
    }

    public void Put(Meal meal)
    {
        if (!HasRollable())
        {
            return;
        }
        Add(meal);
    }
}