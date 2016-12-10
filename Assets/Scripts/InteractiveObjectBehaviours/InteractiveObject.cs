using UnityEngine;
using System.Collections;

public abstract class InteractiveObject : MonoBehaviour
{ 
    public abstract void OnFocus(PlayerController playerCtrl);
    public abstract void OnTrigger(PlayerController playerCtrl);
}