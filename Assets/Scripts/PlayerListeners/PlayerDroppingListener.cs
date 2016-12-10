using UnityEngine;

public class PlayerDroppingListener : MonoBehaviour
{
    PlayerController player;

    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    void Update()
    {
        if(Input.GetButton("Fire2"))
        {
            player.ReceiveOrder(PlayerOrder.DROP_OBJECT);
        }
    }
}
