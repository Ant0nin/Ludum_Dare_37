using System;
using UnityEngine;

public class OpenableDoor : InteractiveObject
{
    public float speed = 0.01f;
    public bool doorClosed = true;
    public bool useOnce = false;
    public bool automaticDoor = false;

    private bool b_translateToTarget = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float t = 0.0f;

    protected new void Start()
    {
        base.Start();
        Transform targetTransform = transform.GetChild(0);
        startPosition = transform.position;
        endPosition = targetTransform.position;
    }

    public override void OnFocus(PlayerController playerCtrl)
    {
        ui.SetPlayerMind(SentenceKey.ARMORY);
        if(!automaticDoor)
            this.ui.SetInteractionInfo(ControlDesc.INTERACT + (doorClosed ? " Open " : " Close ") + objectName);
    }

    public override void OnTrigger(PlayerController playerCtrl)
    {
        if(!automaticDoor)
            b_translateToTarget = true;
    }

    public void Activate()
    {
        if (b_translateToTarget == true) // in progress
            SwapState();
        else
            b_translateToTarget = true;
    }

    private void SwapState()
    {
        t = 1f - t;
        doorClosed = !doorClosed;
        Vector3 tmp = startPosition;
        startPosition = endPosition;
        endPosition = tmp;
    }

    void Update()
    {
        if(b_translateToTarget)
        {
            t += speed;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
        }

        if(t >= 1f)
        {
            if(useOnce)
            {
                Destroy(this);
                return;
            }
            
            SwapState();
            t = 0f;
            b_translateToTarget = false;
        }
    }

    public override void OnTriggerHold(PlayerController playerCtrl)
    {
    }
}
