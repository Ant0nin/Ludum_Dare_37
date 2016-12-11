using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInventorySystem inventory;

    MonoBehaviour listener_dropping;
    MonoBehaviour listener_move;
    MonoBehaviour listener_view;
    MonoBehaviour listener_interact;
    MonoBehaviour listener_inventoryScroll;

    void Start()
    {
        Transform rightHandTransform = transform.GetChild(0).GetChild(0);
        Transform leftHandTransform = transform.GetChild(0).GetChild(1);
        inventory = new PlayerInventorySystem(rightHandTransform, leftHandTransform);

        listener_move = GetComponent<PlayerGroundMoveListener>();
        listener_view = GetComponent<PlayerInteractionListener>();
        listener_interact = GetComponent<PlayerViewListener>();
        listener_dropping = GetComponent<PlayerDroppingListener>();
        listener_inventoryScroll = GetComponent<PlayerInventoryScroolListener>();
    }
    
    public void ReceiveOrder(PlayerOrder order) {
        ReceiveOrder(order, null);
    }

    // mediator :
    public void ReceiveOrder(PlayerOrder order, GameObject go)
    {
        switch(order)
        {
            case PlayerOrder.PICK_ITEM:
                OnPickObject(go);
                break;
            case PlayerOrder.DROP_ITEM:
                OnDropObject();
                break;
            case PlayerOrder.BEGIN_USE:
                OnBeginUse();
                break;
            case PlayerOrder.END_USE:
                OnEndUse();
                break;
            case PlayerOrder.NEXT_ITEM:
                OnNextItem();
                break;
            case PlayerOrder.PREVIOUS_ITEM:
                OnPreviousItem();
                break;
        }
    }

    private void OnPickObject(GameObject go)
    {
        inventory.PickItem(go);
    }

    private void OnDropObject()
    {
        inventory.DropCurrentItem();
    }

    private void OnNextItem()
    {
        inventory.switchToNextItem();
    }

    private void OnPreviousItem()
    {
        inventory.switchToPreviousItem();
    }

    private void OnBeginUse() {
        listener_move.enabled = false;
        listener_view.enabled = false;
        listener_interact.enabled = false;
        listener_inventoryScroll.enabled = false;
    }

    private void OnEndUse() {
        listener_move.enabled = true;
        listener_view.enabled = true;
        listener_interact.enabled = true;
        listener_inventoryScroll.enabled = true;
    }

    public ItemType getCurrentItemType()
    {
        return inventory.getCurrentItemType();
    }
}
