class CuttingBoard : Storage
{

    public CuttingBoard() : base(1)
    {

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
    }
    public void RollOut(RollingPin rollingPin)
    {
        Dough? dough = (Dough?)Pop();
        if (dough == null)
        {
            return;
        }
        Add(rollingPin.RollOut(dough));
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
        Add((ITangibleObject)rollable);
    }


    public override void InvokeInteraction(ITangibleObject tangibleObject)
    {
        if (!HasRollable())
        {
            Add(tangibleObject);
            return;
        }

        IRollable? rollable = (IRollable?)Pop();
        rollable?.Storage.Add(tangibleObject);
        Add((ITangibleObject)rollable);
    }
}