namespace ContainerShip.Assignment2;

public class OverfillException : ApplicationException
{
    public OverfillException(string text) : base(text)
    {
    }
}