using UnityEngine;

public class AutomaticDoorTrigger : MonoBehaviour
{
    public OpenableDoor[] targetDoors;

    private void OnTriggerEnter(Collider other)
    {
        foreach (OpenableDoor door in targetDoors)
            door.Activate();
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (OpenableDoor door in targetDoors)
            door.Activate();
    }
}