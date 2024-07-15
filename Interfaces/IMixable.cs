interface IMixable
{
    float Homogeneity { get; set; }
    public void InvokeMix(IMixer mixer)
    {
        Homogeneity += mixer.MixEffect;
    }

    public bool IsMixed()
    {
        return Homogeneity != 0;
    }
}