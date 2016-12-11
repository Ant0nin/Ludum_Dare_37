using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    Text tipArea;
    Text dialogArea;
    Text interactionArea;

    private void Start()
    {
        Text[] textAreas = transform.GetComponentsInChildren<Text>();
        tipArea = textAreas[0];
        interactionArea = textAreas[1];
        dialogArea = textAreas[2];
    }

    public void SetTip(string text)
    {
        tipArea.text = text;
    }

    public void SetInteractionInfo(string text)
    {
        interactionArea.text = text;
    }

    public void SetDialog(string text)
    {
        dialogArea.text = text;
    }
}