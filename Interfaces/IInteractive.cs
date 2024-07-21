
interface IInteractive : IKitchenObject
{
    void InvokeInteraction();
    void InvokeInteraction(KitchenObject kitchenObject) { }
    bool HasStorage();
}