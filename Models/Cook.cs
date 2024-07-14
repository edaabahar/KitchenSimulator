
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
        if (rightHand == null)
        {
            rightHand = kitchenObject;
        }
        else if (rightHand != null && leftHand == null)
        {
            leftHand = kitchenObject;
        }
        else if (rightHand != null && leftHand != null)
        {
            throw new CookInteractionException("Unable to grab " + kitchenObject.GetName()); // todo: give the kitchen object as a parameter;
        }
        return this;
    }
    public Cook Interact(IInteractiveObject interactiveObject)
    {
        interactiveObject.InvokeInteraction();
        return this;
    }
    public Cook Interact(IKitchenObject kitchenObject, IInteractiveObject interactiveObject)
    {
        interactiveObject.InvokeInteraction(kitchenObject);
        if (interactiveObject.HasStorage())
        {
            if (leftHand?.Equals(kitchenObject) ?? false)
            {
                leftHand = null;
            }
            else if (rightHand?.Equals(kitchenObject) ?? false)
            {
                rightHand = null;
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