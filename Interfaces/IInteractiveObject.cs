using System.Reflection.Metadata.Ecma335;

interface IInteractiveObject : IKitchenObject
{
    void InvokeInteraction();
    void InvokeInteraction(IKitchenObject kitchenObject);
    bool HasStorage();
}