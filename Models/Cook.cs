
using System.Security.Cryptography.X509Certificates;

class Cook
{
    public string name;
    public ITangibleObject? leftHand;
    public ITangibleObject? rightHand;
    public Cook(string name)
    {
        this.name = name;
    }
    public Cook Grab(ITangibleObject? tangibleObject)
    {
        if (rightHand == null)
        {
            rightHand = tangibleObject;
        }
        else if (rightHand != null && leftHand == null)
        {
            leftHand = tangibleObject;
        }
        else if (rightHand != null && leftHand != null)
        {
            throw new CookInteractionException("Unable to grab " + tangibleObject?.GetName()); // todo: give the kitchen object as a parameter;
        }
        Console.WriteLine($"Cook grabbed the object; Right hand {rightHand?.GetName()}, Left hand {leftHand?.GetName()}");
        return this;
    }
    public Cook Interact(IInteractiveObject interactiveObject)
    {
        interactiveObject.InvokeInteraction();
        return this;
    }
    public Cook Interact(ITangibleObject tangibleObject, IInteractiveObject interactiveObject)
    {
        interactiveObject.InvokeInteraction(tangibleObject);
        if (interactiveObject.HasStorage())
        {
            if (leftHand?.Equals(tangibleObject) ?? false)
            {
                leftHand = null;
            }
            else if (rightHand?.Equals(tangibleObject) ?? false)
            {
                rightHand = null;
            }
        }
        return this;
    }
    public Cook Retrieve(ITangibleObject tangibleObject, IStorageObject storageObject)
    {
        ITangibleObject? to = (ITangibleObject?)storageObject.InvokeRetrieve(tangibleObject);
        Grab(to);
        return this;
    }
    public Cook Retrieve<T>(IStorageObject storageObject)
    {
        ITangibleObject? to = (ITangibleObject?)storageObject.InvokeRetrieve<T>();
        Grab(to);
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