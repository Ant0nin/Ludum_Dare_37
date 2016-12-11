using UnityEngine;

public class PickableObject : InteractiveObject
{
    public ItemType type;

    public override void OnFocus(PlayerController player)
    {
        this.ui.SetInteractionInfo(ControlDesc.INTERACT +" Pick " + objectName);
    }

    public override void OnTrigger(PlayerController player)
    {
        player.ReceiveOrder(PlayerOrder.PICK_OBJECT, this.gameObject);
    }
}
