using UnityEngine;

public class PlayerDroppingListener : MonoBehaviour
{
    PlayerController mediator;

    void Start()
    {
        mediator = GetComponent<PlayerController>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            mediator.ReceiveOrder(PlayerOrder.DROP_ITEM);
        }
    }
}
