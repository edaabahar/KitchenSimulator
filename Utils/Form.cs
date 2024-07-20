class Form
{
    // TODO: we need cut coefficient limit for some objects.
    public FormTypes Type { get; set; }
    float CutCoefficient { get; set; }

    public bool IsCuttableByHand()
    {
        return CutCoefficient >= Math.Pow(0.5, 2);
    }


    public Form(float cutCoefficient)
    {
        CutCoefficient = cutCoefficient;
        Update();
    }
    public void Cut()
    {
        CutCoefficient /= 2;
        Update();
    }

    public void Update()
    {

        if (CutCoefficient == 0)
        {
            Type = FormTypes.Liquid;
        }
        else if (CutCoefficient == 1)
        {
            Type = FormTypes.Raw;
        }
        else if (CutCoefficient >= Math.Pow(0.5, 1))
        {
            Type = FormTypes.Half;
        }
        else if (CutCoefficient >= Math.Pow(0.5, 2))
        {
            Type = FormTypes.Quarter;
        }
        else if (CutCoefficient >= Math.Pow(0.5, 5))
        {
            Type = FormTypes.Julien;
        }
        else if (CutCoefficient >= Math.Pow(0.5, 15))
        {
            Type = FormTypes.Cube;

        }
        else if (CutCoefficient < Math.Pow(0.5, 15))
        {
            Type = FormTypes.Grained;

        }
        else
        {
            throw new Exception("Invalid cut coefficient.");
        }
        Console.WriteLine(Type + " " + CutCoefficient);
    }
}