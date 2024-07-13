[Serializable]
public class CookInteractionException : Exception
{
    public CookInteractionException()
    { }

    public CookInteractionException(string message)
        : base(message)
    { }

    public CookInteractionException(string message, Exception innerException)
        : base(message, innerException)
    { }
}