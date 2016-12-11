using UnityEngine;

public class ScrewableObject : InteractiveObject
{
    public float distanceThreshold = 2.0f;
    public float translationSpeed = 1.0f;
    public float rotationSpeed = 1.0f;
    public ItemType necessaryItem = ItemType.SCREWDRIVER;

    private Vector3 initialPos;
    private bool b_action = false;

    protected new void Start()
    {
        base.Start();
        initialPos = transform.position;
    }

    public override void OnFocus(PlayerController player)
    {
        if (player.getPickedObjectType() == necessaryItem)
            this.ui.SetInteractionInfo(ControlDesc.USE_ITEM + " Unscrew " + objectName);
    }

    public override void OnTrigger(PlayerController player)
    {
        if(player.getPickedObjectType() == necessaryItem)
            b_action = true;
    }

    private void Update()
    {
        if(b_action)
        {
            transform.Translate(0, translationSpeed * Time.deltaTime, 0);
            transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
        }
        b_action = false;

        float coveredDistance = Vector3.Distance(initialPos, transform.position);
        if(coveredDistance > distanceThreshold)
        {
            gameObject.AddComponent<Rigidbody>();
            Destroy(this);
        }
    }
}
