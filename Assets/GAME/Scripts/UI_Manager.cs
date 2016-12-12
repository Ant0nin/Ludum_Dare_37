using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public float fadeSpeed = 0.1f;

    Text dialogArea;
    Text interactionArea;
    Text middleArea;
    Text playerMindArea;
    RawImage mask;

    bool b_fadeIn = true;
    bool b_fadeOut = false;

    private void Start()
    {
        Text[] textAreas = transform.GetComponentsInChildren<Text>();
        interactionArea = textAreas[0];
        dialogArea = textAreas[1];
        middleArea = textAreas[2];
        playerMindArea = textAreas[3];
        mask = GetComponentInChildren<RawImage>();
    }

    public void SetInteractionInfo(string text)
    {
        interactionArea.text = text;
    }

    public void SetDialog(string text)
    {
        dialogArea.text = text;
    }

    public void SetImportantText(string text)
    {
        middleArea.text = text;
    }

    public void FadeIn()
    {
        b_fadeIn = true;
        b_fadeOut = false;
    }

    public void FadeOut()
    {
        b_fadeIn = false;
        b_fadeOut = true;
    }

    private void Update()
    {
        if(b_fadeIn)
            mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, mask.color.a - fadeSpeed);
        else if(b_fadeOut)
            mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, mask.color.a + fadeSpeed);

        if (mask.color.a >= 1.0f)
        {
            mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, 1f);
            b_fadeOut = false;
        }
        else if (mask.color.a <= 0.0f)
        {
            mask.color = new Color(mask.color.r, mask.color.g, mask.color.b, 0f);
            b_fadeIn = true;
        }
    }
}