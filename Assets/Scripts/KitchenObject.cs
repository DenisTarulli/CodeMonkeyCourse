using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    /// <summary>
    /// Sets the new clear counter for the kitchenObject and clears the previous one
    /// </summary>
    /// <param name="clearCounter">New clear counter</param>
    public void SetClearCounter(ClearCounter clearCounter)
    {
        if (this.clearCounter != null)
        {
            // Clears the kitchen object field of the previous clear counter (sets it to null)
            this.clearCounter.ClearKitchenObject();
        }

        // Sets the new clear counter of this kitchen object
        this.clearCounter = clearCounter;

        if (clearCounter.HasKitchenObject())
        {
            Debug.LogError("Counter already has a KitchenObject!");
        }

        // Asigns this kitchen object to the field "kitchenObject" of the new clear counter
        clearCounter.SetKitchenObject(this);

        // Moves the visual to the new clear counter parent
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();
        transform.localPosition = Vector3.zero;
    }

    public ClearCounter GetclearCounter()
    {
        return clearCounter;
    }
}
