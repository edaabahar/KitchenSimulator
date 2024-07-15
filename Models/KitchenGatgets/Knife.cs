class Knife : KitchenObject, ITangibleObject, IInteractiveObject
{
    public bool HasStorage()
    {
        return false;
    }

    public void InvokeInteraction()
    {

    }

    public void InvokeInteraction(ITangibleObject kitchenObject)
    {

    }
    public void InvokeInteraction(Goods goods)
    {
        goods.Form.Cut();
    }
}
