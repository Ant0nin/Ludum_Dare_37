using UnityEngine;

public class PlayerInteractionListener : MonoBehaviour
{
    public float interactionMaxDistance = 4f;

    UI_Manager ui;
    Transform view;
    PlayerController player;

    void Start() {
        view = transform.GetChild(0);
        player = GetComponent<PlayerController>();
        ui = GameObject.Find("UI_Overlay").GetComponent<UI_Manager>();
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
                    obj.OnTriggerHold(player);
                if (Input.GetButtonDown("Fire1"))
                    obj.OnTrigger(player);
            }
            else
                ui.SetInteractionInfo("");
        }
        else
            ui.SetInteractionInfo("");
    }
}