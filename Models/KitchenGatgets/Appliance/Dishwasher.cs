class Dishwasher(int capacity) : Appliance<KitchenObject>(capacity, false)
{

    public float CleanEffect { get; set; } = 0.01f;

    public void Clean()
    {
        foreach (KitchenObject ktc in items)
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