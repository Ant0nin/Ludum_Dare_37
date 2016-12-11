using UnityEngine;

public class PickableObject : InteractiveObject
{
    public ItemType type;

    public override void OnFocus(PlayerController player)
    {

    }

    public override void OnTrigger(PlayerController player)
    {
        player.ReceiveOrder(PlayerOrder.PICK_OBJECT, this.gameObject);
    }
}
