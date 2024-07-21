
class CuttingBoard : Storage<Meal>, IWashable
{
    public CuttingBoard() : base(1)
    {

    }
    public float DirtyRatio { get; set; } = 0f;
    public bool IsClean()
    {
        return DirtyRatio < 1;
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
        Meal? rollable = (Meal?)Pop();
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
        Meal? cm = (Meal?)First();
        if (cm == null)
        {
            return false;
        }

        return cm.IsRollable;
    }

    public void Put(Meal m)
    {
        Meal? cm = Pop();
        if (cm == null || !cm.IsRollable)
        {
            Add(m);
            return;
        }

        cm?.Expand(m);
        Add(cm);
    }
}