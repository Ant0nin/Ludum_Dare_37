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
            /*if (currentItem)
                currentItem.GetComponent<Renderer>().enabled = false;*/

            switchableItems.Add(item);
            handTarget = rightHandTransform;
            currentItem = item;
        }

        go.transform.SetParent(handTarget);
        go.transform.position = handTarget.position;
    }

    public void DropCurrentItem()
    {
        PickableObject item = currentItem;
        if (!item)
            return;

        if(item != persistantItem)
        {
            switchToNextItem();
            switchableItems.Remove(item);
        }

        item.GetComponent<Collider>().enabled = true;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        item.GetComponent<Rigidbody>().isKinematic = false;

        item.transform.parent = null;
        item = null;
    }

    public void switchToNextItem()
    {
        //currentItem.GetComponent<Renderer>().enabled = false;

        int currentIndex = switchableItems.IndexOf(currentItem);
        currentIndex++;
        if (currentIndex > (switchableItems.Count - 1))
            currentItem = switchableItems[0];
        else
            currentItem = switchableItems[currentIndex];

        //currentItem.GetComponent<Renderer>().enabled = true;
    }

    public void switchToPreviousItem()
    {
        //currentItem.GetComponent<Renderer>().enabled = false;

        int currentIndex = switchableItems.IndexOf(currentItem);
        currentIndex--;
        if (currentIndex < 0)
            currentItem = switchableItems[switchableItems.Count - 1];
        else
            currentItem = switchableItems[currentIndex];

        //currentItem.GetComponent<Renderer>().enabled = true;
    }

    public ItemType getCurrentItemType()
    {
        return (currentItem == null ? ItemType.NONE : currentItem.type);
    }
}

