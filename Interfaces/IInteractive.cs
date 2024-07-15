
interface IInteractive : IKitchenObject
{
    void InvokeInteraction();
    void InvokeInteraction(ITangible kitchenObject) { }
    bool HasStorage();
}