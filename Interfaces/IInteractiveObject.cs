using System.Reflection.Metadata.Ecma335;

interface IInteractiveObject : IKitchenObject
{
    void Interact();
    void Interact(IKitchenObject kitchenObject);
    bool HasStorage();
}