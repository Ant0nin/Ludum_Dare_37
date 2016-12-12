using System;
using UnityEngine;

public class SpaceWindow : InteractiveObject
{
    public override void OnFocus(PlayerController playerCtrl)
    {
        ui.SetPlayerMind(SentenceKey.WINDOW);
    }

    public override void OnTrigger(PlayerController playerCtrl)
    {
    }

    public override void OnTriggerHold(PlayerController playerCtrl)
    {
    }
}