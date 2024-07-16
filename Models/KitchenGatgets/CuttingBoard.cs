class CuttingBoard : Storage, IWashable, ITangible
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
        ComplexMeal? dough = (ComplexMeal?)Pop();
        if (dough == null)
        {
            return;
        }
        Add(rollingPin.RollOut(dough));
        DirtyRatio += dough.DirtyEffect;
    }

    public bool HasRollable()
    {

        IRollable? rollable = (IRollable?)kitchenObjects.Find(x => x is IRollable);

        return rollable != null && !rollable.IsRolled;
    }
    public void Roll()
    {
        IRollable? rollable = (IRollable?)Pop();
        if (rollable == null)
        {
            return;
        }
        rollable.IsRolled = true;
        Add((ITangible)rollable);
        DirtyRatio += ((Goods)rollable).DirtyEffect;
    }


    public override void InvokeInteraction(ITangible tangibleObject)
    {
        if (!HasRollable())
        {
            Add(tangibleObject);
            return;
        }

        IRollable? rollable = (IRollable?)Pop();
        rollable?.Storage.Add(tangibleObject);
        Add((ITangible)rollable);
    }
}