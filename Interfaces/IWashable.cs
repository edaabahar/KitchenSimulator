interface IWashable
{
    public bool IsClean { get; set; }
    public void Clean()
    {
        IsClean = true;
    }
}