using System.Reflection.Metadata.Ecma335;

interface IInteractiveObject : IKitchenObject
{
    void InvokeInteraction();
    void InvokeInteraction(ITangibleObject kitchenObject);
    bool HasStorage();
}