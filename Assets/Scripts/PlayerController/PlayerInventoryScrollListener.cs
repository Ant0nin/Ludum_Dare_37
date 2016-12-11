using UnityEngine;

public class PlayerInventoryScroolListener : MonoBehaviour
{
    PlayerController mediator;
    //UI_Manager ui;

    void Start()
    {
        mediator = GetComponent<PlayerController>();
        //ui = GameObject.Find("UI_Overlay").GetComponent<UI_Manager>();
    }

    void Update()
    {
        // TODO : show inventory overview in UI

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            mediator.ReceiveOrder(PlayerOrder.NEXT_ITEM);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            mediator.ReceiveOrder(PlayerOrder.PREVIOUS_ITEM);
        }
    }
}