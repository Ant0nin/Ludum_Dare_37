using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PickableObject pickedObject;
    Transform pickedObjectTransform;

    MonoBehaviour listener_dropping;
    MonoBehaviour listener_move;
    MonoBehaviour listener_view;
    MonoBehaviour listener_interact;

    void Start()
    {
        pickedObject = null;
        pickedObjectTransform = transform.GetChild(0).GetChild(0);

        listener_move = GetComponent<PlayerGroundMoveListener>();
        listener_view = GetComponent<PlayerInteractionListener>();
        listener_interact = GetComponent<PlayerViewListener>();
        listener_dropping = GetComponent<PlayerDroppingListener>();
    }
    
    public void ReceiveOrder(PlayerOrder order) {
        ReceiveOrder(order, null);
    }

    public void ReceiveOrder(PlayerOrder order, GameObject go)
    {
        switch(order)
        {
            case PlayerOrder.PICK_OBJECT:
                OnPickObject(go);
                break;
            case PlayerOrder.DROP_OBJECT:
                OnDropObject();
                break;
            case PlayerOrder.BEGIN_USE:
                OnBeginUse();
                break;
            case PlayerOrder.END_USE:
                OnEndUse();
                break;
        }
    }

    private void OnPickObject(GameObject go)
    {
        pickedObject = go.GetComponent<PickableObject>();
        pickedObject.GetComponent<Collider>().enabled = false;
        pickedObject.GetComponent<Rigidbody>().useGravity = false;
        pickedObject.GetComponent<Rigidbody>().detectCollisions = false;

        go.transform.SetParent(pickedObjectTransform);
        go.transform.position = pickedObjectTransform.position;
        listener_dropping.enabled = true;
    }

    private void OnDropObject()
    {
        pickedObject.GetComponent<Collider>().enabled = true;
        pickedObject.GetComponent<Rigidbody>().useGravity = true;
        pickedObject.GetComponent<Rigidbody>().detectCollisions = true;

        pickedObject.transform.parent = null;
        pickedObject = null;
        listener_dropping.enabled = false;
    }

    private void OnBeginUse() {
        listener_move.enabled = false;
        listener_view.enabled = false;
        listener_interact.enabled = false;
    }

    private void OnEndUse() {
        listener_move.enabled = true;
        listener_view.enabled = true;
        listener_interact.enabled = true;
    }
    
    public ItemType getPickedObjectType() {
        return (pickedObject == null ? ItemType.NONE : pickedObject.type);
    }
}
