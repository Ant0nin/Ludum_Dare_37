using System;
using UnityEngine;

public class StrangeMan : InteractiveObject
{
    public override void OnFocus(PlayerController playerCtrl)
    {
        ui.SetPlayerMind(SentenceKey.OTHER_MAN);
    }

    public override void OnTrigger(PlayerController playerCtrl)
    {
    }

    public override void OnTriggerHold(PlayerController playerCtrl)
    {
    }
}