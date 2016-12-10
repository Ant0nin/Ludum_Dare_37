using UnityEngine;

public class PlayerInteractionListener : MonoBehaviour
{
    public float interactionMaxDistance = 4f;

    Transform view;
    PlayerController player;

    void Start() {
        view = transform.GetChild(0);
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(view.position, view.forward, out hitInfo);
        if (hit && hitInfo.distance < interactionMaxDistance)
        {
            InteractiveObject obj = hitInfo.collider.gameObject.GetComponent<InteractiveObject>();
            if (obj != null)
            {
                obj.OnFocus(player);
                if (Input.GetButton("Fire1"))
                    obj.OnTrigger(player);
            }
        }
    }
}