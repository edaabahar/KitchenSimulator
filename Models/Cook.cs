
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
    public Cook Knead(IKneadable<Goods> goods)
    {
        Thread.Sleep(1000);
        goods.Knead();
        return this;
    }
    // hamur açma ya da köfte yuvarlama
    public Cook Roll(CuttingBoard cuttingBoard)
    {
        if (!cuttingBoard.HasRollable())
        {
            return this;
        }
        if (!IsHandsFree())
        {
            throw new CookInteractionException("Both hands should be free!");
        }

        cuttingBoard.Roll();
        return this;
    }
    public Cook RollOut(CuttingBoard cuttingBoard)
    {
        RollingPin rollingPin = (RollingPin)GetHandObject<RollingPin>();
        cuttingBoard.RollOut(rollingPin);
        return this;
    }
    public Cook Cut()
    {
        Knife knife = (Knife)GetHandObject<Knife>();
        Goods goods = (Goods)GetHandObject<Goods>();
        if (!goods.Form.IsCuttableByHand())
        {
            return this;
        }
        knife.Cut(goods);
        return this;
    }
    public Cook Cut(CuttingBoard cuttingBoard)
    {
        Knife knife = (Knife)GetHandObject<Knife>();

        cuttingBoard.Cut(knife);
        return this;
    }
    public Cook Peel()
    {
        Knife knife = (Knife)GetHandObject<Knife>();
        Goods goods = (Goods)GetHandObject<Goods>();

        knife.Peel(goods);
        return this;
    }
    public Cook Mix()
    {
        Thread.Sleep(1000);
        return this;
    }

    private KitchenObject GetHandObject<T>()
    {
        if (leftHand?.GetType() == typeof(T))
        {
            return (KitchenObject)leftHand;
        }
        if (rightHand?.GetType() == typeof(T))
        {
            return (KitchenObject)rightHand;
        }
        if (leftHand is Goods)
        {
            return (KitchenObject)leftHand;
        }
        if (rightHand is Goods)
        {
            return (KitchenObject)rightHand;
        }

        throw new CookInteractionException($"{typeof(T)} does not exist");
    }

    private bool IsHandsFree()
    {
        return leftHand == null && rightHand == null;
    }
}