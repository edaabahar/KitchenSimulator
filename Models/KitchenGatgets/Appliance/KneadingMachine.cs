class KneadingMachine : ComplexMealStorage
{
    public void Knead()
    {
        if (ComplexMeal == null)
        {
            throw new Exception();
        }
        ComplexMeal.Homogeneity += 0.01f;
        // Todo: Add more parameters to knead
    }
}