using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    /// <summary>
    /// Sets the new parent for the kitchenObject and clears the previous one
    /// </summary>
    /// <param name="kitchenObjectParent">New parent</param>
    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent)
    {
        if (this.kitchenObjectParent != null)
        {
            // Clears the kitchen object field of the previous parent (sets it to null)
            this.kitchenObjectParent.ClearKitchenObject();
        }

        // Sets the new parent of this kitchen object
        this.kitchenObjectParent = kitchenObjectParent;

        if (kitchenObjectParent.HasKitchenObject())
        {
            Debug.LogError("IKitchenObjectParent already has a KitchenObject!");
        }

        // Asigns this kitchen object to the field "kitchenObject" of the new parent
        kitchenObjectParent.SetKitchenObject(this);

        // Moves the visual to the new parent
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
}
