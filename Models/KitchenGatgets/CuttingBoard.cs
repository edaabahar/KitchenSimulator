class CuttingBoard : Storage<Meal>, IWashable, ITangible
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
        Goods? goods = (Goods?)Pop();
        if (goods == null)
        {
            return;
        }

        knife.Cut(goods);
        Add(goods);
        DirtyRatio += goods.DirtyEffect;
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

    public void Put(ITangible tangibleObject)
    {
        Meal? cm = (Meal?)Pop();
        if (cm == null || !cm.IsRollable)
        {
            Add((Meal)tangibleObject);
            return;
        }

        cm?.Storage.Add((Goods)tangibleObject);
        Add(cm);
    }
}