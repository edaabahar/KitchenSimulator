class Cook
{
    public string name;
    public KitchenObject? leftHand;
    public KitchenObject? rightHand;
    public Cook(string name)
    {
        this.name = name;
    }
    public Cook Grab(KitchenObject ko)
    {
        if (!ko.IsTangible)
        {
            throw new CookInteractionException();
        }
        if (rightHand == null)
        {
            rightHand = ko;
        }
        else if (rightHand != null && leftHand == null)
        {
            leftHand = ko;
        }
        else if (rightHand != null && leftHand != null)
        {
            throw new CookInteractionException("Unable to grab " + ko?.GetName()); // todo: give the kitchen object as a parameter;
        }
        Console.WriteLine($"Cook grabbed the object; Right hand {rightHand?.GetName()}, Left hand {leftHand?.GetName()}");
        return this;
    }
    public Cook Put<T>(T ko, Storage<T> storage) where T : KitchenObject
    {
        storage.Add(ko);

        if (leftHand?.Equals(ko) ?? false)
        {
            leftHand = null;
        }
        else if (rightHand?.Equals(ko) ?? false)
        {
            rightHand = null;
        }

        return this;
    }

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
    public Cook Cut(CuttingBoard cuttingBoard)
    {
        Knife knife = (Knife)GetHandObject<Knife>();

        cuttingBoard.Cut(knife);
        return this;
    }
    public Cook Peel()
    {
        Knife knife = (Knife)GetHandObject<Knife>();
        Meal meal = (Meal)GetHandObject<Meal>();
        meal.ForEach(knife.Peel);
        return this;
    }
    public Cook Mix(MealStorage mealStorage)
    {
        IMixer mixer = (IMixer)GetHandObject<IMixer>();
        mixer.Mix(mealStorage);
        return this;
    }

    private KitchenObject GetHandObject<T>()
    {
        if (leftHand?.GetType() == typeof(T))
        {
            return leftHand;
        }
        if (rightHand?.GetType() == typeof(T))
        {
            return rightHand;
        }
        if (leftHand is T)
        {
            return leftHand;
        }
        if (rightHand is T)
        {
            return rightHand;
        }

        throw new CookInteractionException($"{typeof(T)} does not exist");
    }

    private bool IsHandsFree()
    {
        return leftHand == null && rightHand == null;
    }
}