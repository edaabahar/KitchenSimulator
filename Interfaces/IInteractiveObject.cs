
interface IInteractiveObject : IKitchenObject
{
    void InvokeInteraction();
    void InvokeInteraction(ITangibleObject kitchenObject);
    void InvokeInteraction(Goods goods);
    bool HasStorage();
}