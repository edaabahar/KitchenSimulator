class Form
{
    FormTypes FormType { get; set; }
    float CutCoefficient { get; set; }


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
            FormType = FormTypes.Liquid;
        }
        else if (CutCoefficient == 1)
        {
            FormType = FormTypes.Raw;
        }
        else if (CutCoefficient >= Math.Pow(0.5, 1))
        {
            FormType = FormTypes.Half;
        }
        else if (CutCoefficient >= Math.Pow(0.5, 2))
        {
            FormType = FormTypes.Quarter;
        }
        else if (CutCoefficient >= Math.Pow(0.5, 5))
        {
            FormType = FormTypes.Julien;
        }
        else if (CutCoefficient >= Math.Pow(0.5, 15))
        {
            FormType = FormTypes.Cube;

        }
        else if (CutCoefficient < Math.Pow(0.5, 15))
        {
            FormType = FormTypes.Grained;

        }
        else
        {
            throw new Exception("Invalid cut coefficient.");
        }
        Console.WriteLine(FormType + " " + CutCoefficient);
    }
}