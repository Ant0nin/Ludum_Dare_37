using UnityEngine;

public class PickableObject : InteractiveObject
{
    public ItemType type;

    public override void OnFocus(PlayerController player)
    {
        Debug.Log("Interactive object detected !");
    }

    public override void OnTrigger(PlayerController player)
    {
        Debug.Log("Interaction triggering !");
        player.ReceiveOrder(PlayerOrder.PICK_OBJECT, this.gameObject);
    }
}
