class KneadingMachine() : Appliance<Meal>(1, false), IMixer
{
    public float MixEffect { get; set; }

    public void Mix()
    {
        foreach (Meal cm in kitchenObjects)
        {
            cm.ApplyMix(MixEffect);
        }
    }
}