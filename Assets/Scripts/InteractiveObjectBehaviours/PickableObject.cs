using UnityEngine;

public class PickableObject : InteractiveObject
{
    private static string pickControl = "[Left click]";
    public ItemType type;

    public override void OnFocus(PlayerController player)
    {
        this.ui.SetInteractionInfo(pickControl+" Pick " + objectName);
    }

    public override void OnTrigger(PlayerController player)
    {
        player.ReceiveOrder(PlayerOrder.PICK_OBJECT, this.gameObject);
    }
}
