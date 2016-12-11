using UnityEngine;
using System.Collections;

public abstract class InteractiveObject : MonoBehaviour
{
    public string objectName = "object";

    protected UI_Manager ui;

    protected void Start() {
        ui = GameObject.Find("UI_Overlay").GetComponent<UI_Manager>();
    }

    public abstract void OnFocus(PlayerController playerCtrl);
    public abstract void OnTrigger(PlayerController playerCtrl);
}