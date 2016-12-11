using System;
using UnityEngine;

public class OpenableDoor : InteractiveObject
{
    public float speed = 0.01f;
    public bool doorClosed = true;
    public bool useOnce = false;

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
        this.ui.SetInteractionInfo(ControlDesc.INTERACT + (doorClosed ? " Open " : " Close ") + objectName);
    }

    public override void OnTrigger(PlayerController playerCtrl)
    {
        b_translateToTarget = true;
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

            doorClosed = !doorClosed;
            b_translateToTarget = false;
            t = 0f;
            Vector3 tmp = startPosition;
            startPosition = endPosition;
            endPosition = tmp;
        }
    }
}
