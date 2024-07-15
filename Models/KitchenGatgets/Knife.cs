class Knife : KitchenObject, ITangibleObject
{
    public void Cut(Goods goods)
    {
        goods.Form.Cut();
    }

    public void Peel(Goods goods)
    {
        goods.HasSkin = false;
    }
}
