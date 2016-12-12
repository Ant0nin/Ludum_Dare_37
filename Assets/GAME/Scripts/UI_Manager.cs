using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public float fadeSpeed = 0.1f;
    public float sentenceSpeed = 0.01f;

    Text dialogArea;
    Text interactionArea;
    Text middleArea;
    Text playerMindArea;
    RawImage mask;

    bool b_fadeIn = true;
    bool b_fadeOut = false;
    bool b_init = false;

    SentencesDictionary dictionary;

    void Start()
    {
        Text[] textAreas = transform.GetComponentsInChildren<Text>();
        interactionArea = textAreas[0];
        dialogArea = textAreas[1];
        middleArea = textAreas[2];
        playerMindArea = textAreas[3];
        mask = GetComponentInChildren<RawImage>();
        dictionary = new SentencesDictionary();
        b_init = true;
    }

    public void SetInteractionInfo(string text)
    {
        if(b_init)
            interactionArea.text = text;
    }

    public void SetDialog(string text)
    {
        if(b_init)
            dialogArea.text = text;
    }

    public void SetImportantText(string text)
    {
        if (b_init)
            middleArea.text = text;
    }

    public void SetPlayerMind(SentenceKey key)
    {
        if (b_init)
        {
            playerMindArea.text = dictionary.GetSentence(key);
            playerMindArea.color = new Color(playerMindArea.color.r, playerMindArea.color.g, playerMindArea.color.b, 1.0f);
        }
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
        playerMindArea.color = new Color(playerMindArea.color.r, playerMindArea.color.g, playerMindArea.color.b, playerMindArea.color.a - sentenceSpeed);

        if (b_fadeIn)
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