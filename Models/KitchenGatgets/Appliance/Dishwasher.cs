class Dishwasher(int capacity) : Appliance<KitchenObject>(capacity)
{

    public float CleanEffect { get; set; } = 0.01f;

    public void Clean()
    {
        foreach (KitchenObject ktc in kitchenObjects)
        {
            ((IWashable)ktc).DirtyRatio -= CleanEffect;
            if (((IWashable)ktc).DirtyRatio < 0.01)
            {
                ((IWashable)ktc).DirtyRatio = 0f;
            }
        }
    }

    public void Clean(int second)
    {
        for (int i = 0; i < second; i++)
        {
            Clean();
        }
    }

}