class Flour : Ingredients, IKneadable<Dough>
{

    public Dough Knead()
    {
        return new Dough();
    }

    public Dough Knead(List<Goods> goods)
    {
        return new Dough();
    }
}