using UnityEngine;
using System.Collections.Generic;

public class PlayerInventorySystem
{
    List<PickableObject> switchableItems;
    PickableObject currentItem; // current item
    PickableObject persistantItem; // only for flashlight

    Transform rightHandTransform;
    Transform leftHandTransform;

    public PlayerInventorySystem(Transform rightHand, Transform leftHand)
    {
        switchableItems = new List<PickableObject>();
        rightHandTransform = rightHand;
        leftHandTransform = leftHand;
    }

    public void PickItem(GameObject go)
    {
        PickableObject item = go.GetComponent<PickableObject>();
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        item.GetComponent<Rigidbody>().isKinematic = true;

        Transform handTarget;
        if (item.type == ItemType.FLASHLIGHT) { // single exception
            handTarget = leftHandTransform;
            persistantItem = item;
        }
        else
        {
            if (currentItem)
                currentItem.GetComponent<Renderer>().enabled = false;

            switchableItems.Add(item);
            handTarget = rightHandTransform;
            currentItem = item;
        }

        go.transform.SetParent(handTarget);
        go.transform.rotation = handTarget.rotation;
        go.transform.position = handTarget.position;
    }

    public void DropCurrentItem()
    {
        PickableObject targetItem;
        bool hasSwitchableItems = (switchableItems.Count > 0);

        if (!hasSwitchableItems)
        {
            targetItem = persistantItem;
            targetItem.GetComponent<Renderer>().enabled = true;
            DetachItemFromHand(targetItem);
            persistantItem = null;
        }
        else
        {
            if(switchableItems.Count > 1)
            {
                SwitchToNextItem();
                currentItem.GetComponent<Renderer>().enabled = true;
            }

            targetItem = GetPreviousItem();
            targetItem.GetComponent<Renderer>().enabled = true;
            DetachItemFromHand(targetItem);
            switchableItems.Remove(GetPreviousItem());

            if (switchableItems.Count == 0)
                currentItem = null;
        }
    }

    private void DetachItemFromHand(PickableObject target)
    {
        target.GetComponent<Collider>().enabled = true;
        target.GetComponent<Rigidbody>().detectCollisions = true;
        target.GetComponent<Rigidbody>().isKinematic = false;
        target.transform.parent = null;
    }

    public void SwitchToNextItem()
    {
        currentItem = GetNextItem();

        if (switchableItems.Count > 1)
        {
            GetPreviousItem().GetComponent<Renderer>().enabled = false;
            currentItem.GetComponent<Renderer>().enabled = true;
        }
    }

    private PickableObject GetNextItem()
    {
        int currentIndex = switchableItems.IndexOf(currentItem);
        currentIndex++;
        if (currentIndex > (switchableItems.Count - 1))
            return switchableItems[0];
        else
            return switchableItems[currentIndex];
    }

    public void SwitchToPreviousItem()
    {
        currentItem = GetPreviousItem();

        if (switchableItems.Count > 1)
        {
            GetNextItem().GetComponent<Renderer>().enabled = false;
            currentItem.GetComponent<Renderer>().enabled = true;
        }
    }

    private PickableObject GetPreviousItem()
    {
        int currentIndex = switchableItems.IndexOf(currentItem);
        currentIndex--;
        if (currentIndex < 0)
            return switchableItems[switchableItems.Count - 1];
        else
            return switchableItems[currentIndex];
    }

    public ItemType getCurrentItemType()
    {
        return (currentItem == null ? ItemType.NONE : currentItem.type);
    }

    public int getItemsCount()
    {
        return switchableItems.Count + (persistantItem != null ? 1 : 0);
    }
}

