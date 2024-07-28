class Dishwasher(int capacity) : Appliance<KitchenObject>(capacity, false)
{

    public float CleanEffect { get; set; } = 0.01f;

    public void Clean()
    {
        items.ForEach(ko =>
        {
            IWashable ktc = (IWashable)ko;
            ktc.DirtyRatio -= CleanEffect;
            if (ktc.DirtyRatio < 0.01)
            {
                ktc.DirtyRatio = 0f;
            }
        });
    }

    public void Clean(int second)
    {
        for (int i = 0; i < second; i++)
        {
            Clean();
        }
    }

}