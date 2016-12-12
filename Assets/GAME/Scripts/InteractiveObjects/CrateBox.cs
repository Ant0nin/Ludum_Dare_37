using System;
using UnityEngine;

public class CrateBox : InteractiveObject
{
    public override void OnFocus(PlayerController playerCtrl)
    {
        ui.SetPlayerMind(SentenceKey.CRATE);
    }

    public override void OnTrigger(PlayerController playerCtrl)
    {
    }

    public override void OnTriggerHold(PlayerController playerCtrl)
    {
    }
}