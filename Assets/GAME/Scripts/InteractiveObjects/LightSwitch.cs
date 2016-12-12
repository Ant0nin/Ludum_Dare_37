using System;
using UnityEngine;

public class LightSwitch : InteractiveObject
{
    string targetLightTag = "RoomLight";

    public override void OnFocus(PlayerController playerCtrl)
    {
        this.ui.SetInteractionInfo(ControlDesc.INTERACT + " Use " + objectName);
    }

    public override void OnTrigger(PlayerController playerCtrl)
    {
        GameObject[] lightObjects = GameObject.FindGameObjectsWithTag(targetLightTag);
        foreach(GameObject obj in lightObjects)
        {
            Light l = obj.GetComponent<Light>();
            l.enabled = !l.enabled;
        }
    }

    public override void OnTriggerHold(PlayerController playerCtrl)
    {
    }
}