using System;
using UnityEngine;

public class PickableObject : InteractiveObject
{
    public ItemType type;

    public override void OnFocus(PlayerController player)
    {
        switch(type)
        {
            case ItemType.ACCESS_CARD:
                ui.SetPlayerMind(SentenceKey.CARD_BEFORE);
                break;
            case ItemType.SCREWDRIVER:
                ui.SetPlayerMind(SentenceKey.SCREWDRIVER_BEFORE);
                break;
            case ItemType.FLASHLIGHT:
                ui.SetPlayerMind(SentenceKey.FLASHLIGHT_BEFORE);
                break;
        }

        this.ui.SetInteractionInfo(ControlDesc.INTERACT +" Pick " + objectName);
    }

    public override void OnTrigger(PlayerController player)
    {
        switch (type)
        {
            case ItemType.ACCESS_CARD:
                ui.SetPlayerMind(SentenceKey.CARD_AFTER);
                break;
            case ItemType.SCREWDRIVER:
                ui.SetPlayerMind(SentenceKey.SCREWDRIVER_AFTER);
                break;
            case ItemType.FLASHLIGHT:
                ui.SetPlayerMind(SentenceKey.FLASHLIGHT_AFTER);
                break;
        }

        player.ReceiveOrder(PlayerOrder.PICK_ITEM, this.gameObject);
    }

    public override void OnTriggerHold(PlayerController playerCtrl)
    {
    }
}
