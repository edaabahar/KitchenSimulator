using System.Threading;

class Cook
{
    public void Kneading(IKneadable<Goods> goods)
    {
        Thread.Sleep(1000);
        goods.Knead();
    }

    // hamur açma ya da köfte yuvarlama
    public void Rolling(List<Goods> goods)
    {
        Thread.Sleep(1000);
    }

    public void Cutting(List<Goods> goods)
    {
        Thread.Sleep(1000);
    }

    public void Peeling(List<Goods> goods)
    {
        Thread.Sleep(1000);
    }

    public void Mixing(List<Goods> goods)
    {
        Thread.Sleep(1000);
    }
}