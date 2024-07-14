
class Cook
{
    public string name;
    public IKitchenObject? leftHand;
    public IKitchenObject? rightHand;
    public Cook(string name)
    {
        this.name = name;
    }
    public Cook Grab(IKitchenObject kitchenObject)
    {
        if (this.rightHand == null)
        {
            this.rightHand = kitchenObject;
        }
        else if (this.rightHand != null && this.leftHand == null)
        {
            this.leftHand = kitchenObject;
        }
        else if (this.rightHand != null && this.leftHand != null)
        {
            throw new CookInteractionException("Unable to grab " + kitchenObject.GetName()); // todo: give the kitchen object as a parameter;
        }
        return this;
    }
    public Cook Interact(IInteractiveObject interactiveObject)
    {
        interactiveObject.Interact();
        return this;
    }
    public Cook Interact(IKitchenObject kitchenObject, IInteractiveObject interactiveObject)
    {
        interactiveObject.Interact(kitchenObject);
        if (interactiveObject.HasStorage())
        {
            if (this.leftHand?.Equals(kitchenObject) ?? false)
            {
                this.leftHand = null;
            }
            else if (this.rightHand?.Equals(kitchenObject) ?? false)
            {
                this.rightHand = null;
            }
        }
        return this;
    }
    public Cook Kneading(IKneadable<Goods> goods)
    {
        Thread.Sleep(1000);
        goods.Knead();
        return this;
    }
    // hamur açma ya da köfte yuvarlama
    public Cook Rolling(List<Goods> goods)
    {
        Thread.Sleep(1000);
        return this;
    }
    public Cook Cutting(List<Goods> goods)
    {
        Thread.Sleep(1000);
        return this;
    }
    public Cook Peeling(List<Goods> goods)
    {
        Thread.Sleep(1000);
        return this;

    }
    public Cook Mixing(List<Goods> goods)
    {
        Thread.Sleep(1000);
        return this;
    }
}