using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    List<PickableObject> inventory; // all switchable items
    PickableObject rightHandedItem; // switchable item
    PickableObject leftHandedItem; // only for flashlight

    Transform rightHandTransform;
    Transform leftHandTransform;

    MonoBehaviour listener_dropping;
    MonoBehaviour listener_move;
    MonoBehaviour listener_view;
    MonoBehaviour listener_interact;

    void Start()
    {
        inventory = new List<PickableObject>();
        rightHandTransform = transform.GetChild(0).GetChild(0);
        leftHandTransform = transform.GetChild(0).GetChild(1);

        listener_move = GetComponent<PlayerGroundMoveListener>();
        listener_view = GetComponent<PlayerInteractionListener>();
        listener_interact = GetComponent<PlayerViewListener>();
        listener_dropping = GetComponent<PlayerDroppingListener>();
    }
    
    public void ReceiveOrder(PlayerOrder order) {
        ReceiveOrder(order, null);
    }

    public void ReceiveOrder(PlayerOrder order, GameObject go)
    {
        switch(order)
        {
            case PlayerOrder.PICK_OBJECT:
                OnPickObject(go);
                break;
            case PlayerOrder.DROP_OBJECT:
                OnDropObject();
                break;
            case PlayerOrder.BEGIN_USE:
                OnBeginUse();
                break;
            case PlayerOrder.END_USE:
                OnEndUse();
                break;
        }
    }

    private void OnPickObject(GameObject go)
    {
        PickableObject item = go.GetComponent<PickableObject>();
        item.GetComponent<Collider>().enabled = false;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        item.GetComponent<Rigidbody>().isKinematic = true;

        Transform handTarget;
        if (item.type == ItemType.FLASHLIGHT)
            handTarget = leftHandTransform;
        else
        {
            inventory.Add(item);
            handTarget = rightHandTransform;
        }

        go.transform.SetParent(handTarget);
        go.transform.position = handTarget.position;
        listener_dropping.enabled = true;
    }

    private void OnDropObject()
    {
        PickableObject item = rightHandedItem;
        inventory.Remove(item);

        item.GetComponent<Collider>().enabled = true;
        item.GetComponent<Rigidbody>().detectCollisions = true;
        item.GetComponent<Rigidbody>().isKinematic = false;

        item.transform.parent = null;
        item = null;
        listener_dropping.enabled = false;
    }

    private void OnBeginUse() {
        listener_move.enabled = false;
        listener_view.enabled = false;
        listener_interact.enabled = false;
    }

    private void OnEndUse() {
        listener_move.enabled = true;
        listener_view.enabled = true;
        listener_interact.enabled = true;
    }
    
    public ItemType getPickedObjectType() {
        return (rightHandedItem == null ? ItemType.NONE : rightHandedItem.type);
    }
}
