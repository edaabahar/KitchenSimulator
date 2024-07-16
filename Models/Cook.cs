
using System.Security.Cryptography.X509Certificates;

class Cook
{
    public string name;
    public ITangible? leftHand;
    public ITangible? rightHand;
    public Cook(string name)
    {
        this.name = name;
    }
    public Cook Grab(ITangible? tangibleObject)
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
    public Cook Interact(IInteractive interactiveObject)
    {
        interactiveObject.InvokeInteraction();
        return this;
    }
    public Cook Interact(ITangible tangibleObject, IInteractive interactiveObject)
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
    public Cook Retrieve(ITangible tangibleObject, IStorage storageObject)
    {
        ITangible? to = (ITangible?)storageObject.InvokeRetrieve(tangibleObject);
        Grab(to);
        return this;
    }
    public Cook Retrieve<T>(IStorage storageObject)
    {
        ITangible? to = (ITangible?)storageObject.InvokeRetrieve<T>();
        Grab(to);
        return this;
    }
    public Cook Retrieve(ComplexMealStorage complexMealStorage)
    {
        ComplexMealStorage cms = (ComplexMealStorage)GetHandObject<ComplexMealStorage>();
        if (!cms.IsClean)
        {
            throw new Exception();
        }
        ComplexMeal? cm = complexMealStorage.InvokeRetrieve();
        TransferMeal(cm, cms);
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
    public Cook Mix(ComplexMealStorage complexMealStorage)
    {
        IMixer mixer = (IMixer)GetHandObject<IMixer>();

        mixer.Mix(complexMealStorage);
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
        if (leftHand is T)
        {
            return (KitchenObject)leftHand;
        }
        if (rightHand is T)
        {
            return (KitchenObject)rightHand;
        }

        throw new CookInteractionException($"{typeof(T)} does not exist");
    }

    private bool IsHandsFree()
    {
        return leftHand == null && rightHand == null;
    }

    private void TransferMeal(ComplexMeal? complexMeal, ComplexMealStorage complexMealStorage)
    {
        if (complexMeal == null)
        {
            throw new Exception();
        }
        complexMealStorage.ComplexMeal = complexMeal;
    }
}