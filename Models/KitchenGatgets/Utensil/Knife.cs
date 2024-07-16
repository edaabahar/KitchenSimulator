class Knife : Utensil
{
    public void Cut(Goods goods)
    {
        goods.Form.Cut();
        DirtyRatio += goods.DirtyEffect;
    }

    public void Peel(Goods goods)
    {
        goods.HasSkin = false;
        DirtyRatio += goods.DirtyEffect;
    }
}
