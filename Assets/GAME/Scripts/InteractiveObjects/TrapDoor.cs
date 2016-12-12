using System;
using UnityEngine;

public class TrapDoor : InteractiveObject
{
    public string screwTargetTag = "TrapdoorScrew";
    public Vector3 forceWhenUnlock = new Vector3(0, 10, 0);

    private void Update()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(screwTargetTag);
        int countFallenScrews = 0;

        foreach(GameObject obj in objects)
        {
            if(obj.GetComponent<Rigidbody>() != null)
            {
                countFallenScrews++;
            }
        }

        if(countFallenScrews == objects.Length)
        {
            gameObject.GetComponent<Collider>().enabled = false;
            Rigidbody rigid = gameObject.AddComponent<Rigidbody>();
            rigid.AddForce(forceWhenUnlock);
            Destroy(this);
        }
    }

    public override void OnFocus(PlayerController playerCtrl)
    {
        ui.SetPlayerMind(SentenceKey.TRAPDOOR);
    }

    public override void OnTrigger(PlayerController playerCtrl)
    {
    }

    public override void OnTriggerHold(PlayerController playerCtrl)
    {
    }
}