class CuttingBoard : Storage
{

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
    public CuttingBoard() : base(1)
    {

    }
}