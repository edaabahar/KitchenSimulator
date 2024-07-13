using System.Security.Cryptography.X509Certificates;
using System.Threading;
using KitchenSimulator;

class Cook
{
    public string name;
    public IKitchenObject? leftHand;
    public IKitchenObject? rightHand;

    public Cook(string name)
    {
        this.name = name;
    }
    public Cook GrabWithLeftHand(IKitchenObject kitchenObject)
    {
        if (this.leftHand != null)
        {
            throw new CookInteractionException("Unable to grip " + kitchenObject.GetName());
        }
        this.leftHand = kitchenObject;
        return this;
    }
    public Cook GrabWithRightHand(IKitchenObject kitchenObject)
    {
        if (this.rightHand != null)
        {
            throw new CookInteractionException("Unable to grip " + kitchenObject.GetName());
        }
        this.rightHand = kitchenObject;
        return this;
    }
    private void InteractWithKitchenObject(IKitchenObject? kitchenObject, IInteractiveObject interactiveObject)
    {
        if (kitchenObject == null)
        {
            throw new CookInteractionException("Unable to interact with " + interactiveObject.GetName());
        }
        interactiveObject.Interact(kitchenObject);
    }
    public Cook InteractWithLeftHandObject(IInteractiveObject interactiveObject)
    {
        this.InteractWithKitchenObject(leftHand, interactiveObject);
        if (interactiveObject.HasStorage())
        {
            this.leftHand = null;
        }
        return this;
    }
    public Cook InteractWithRightHandObject(IInteractiveObject interactiveObject)
    {
        this.InteractWithKitchenObject(rightHand, interactiveObject);
        if (interactiveObject.HasStorage())
        {
            this.rightHand = null;
        }
        return this;
    }
    public Cook Interact(IInteractiveObject interactiveObject)
    {
        interactiveObject.Interact();
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