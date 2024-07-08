class Flour : Ingredients, IKneadable<Dough>
{
    public Dough Knead()
    {
        return new Dough();
    }
}