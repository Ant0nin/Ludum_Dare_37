using System;
using UnityEngine;

public class TerminalObject : InteractiveObject
{
    public ItemType necessaryItem = ItemType.ACCESS_CARD;

    private Game_Manager game;

    protected new void Start()
    {
        base.Start();
        game = GameObject.Find("GameManager").GetComponent<Game_Manager>();
    }

    public override void OnFocus(PlayerController player)
    {
        ui.SetPlayerMind(SentenceKey.COMPUTER);
        if(player.getCurrentItemType() == necessaryItem)
            this.ui.SetInteractionInfo(ControlDesc.USE_ITEM + " Use " + objectName);
        else
            this.ui.SetInteractionInfo("");
    }

    public override void OnTrigger(PlayerController player)
    {
        if (player.getCurrentItemType() == necessaryItem)
            game.Win();
    }

    public override void OnTriggerHold(PlayerController playerCtrl)
    {
    }
}