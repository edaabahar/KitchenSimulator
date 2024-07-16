interface IWashable
{
    public bool IsClean();
    public void Clean()
    {
        DirtyRatio = 0.0f;
    }

    public float DirtyRatio { get; set; }
}