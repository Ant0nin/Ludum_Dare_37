using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AutoTransitionToScene : MonoBehaviour
{
    public string sceneTarget = "main";
    public float timeBeforeTransition = 5f;
    public float fadeSpeed = 0.01f;
    public float timeBeforeFadeOut = 3.5f;

    Text overlay_title;
    Text overlay_authors;

    bool b_fade = true; // in/out <=> true/false

    void Start()
    {
        Text[] overlays = GameObject.Find("Overlay").GetComponentsInChildren<Text>();
        overlay_title = overlays[0];
        overlay_authors = overlays[1];

        IEnumerator coroutine1 = NextScene();
        StartCoroutine(coroutine1);

        IEnumerator coroutine2 = FadeOut();
        StartCoroutine(coroutine2);
    }

    void Update()
    {
        if(b_fade) // fade_in
        {
            overlay_title.color = new Color(overlay_title.color.r, overlay_title.color.g, overlay_title.color.b, overlay_title.color.a + fadeSpeed);
            overlay_authors.color = new Color(overlay_authors.color.r, overlay_authors.color.g, overlay_authors.color.b, overlay_authors.color.a + fadeSpeed);
        }
        else // fade out
        {
            overlay_title.color = new Color(overlay_title.color.r, overlay_title.color.g, overlay_title.color.b, overlay_title.color.a - fadeSpeed);
            overlay_authors.color = new Color(overlay_authors.color.r, overlay_authors.color.g, overlay_authors.color.b, overlay_authors.color.a - fadeSpeed);
        }
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(timeBeforeFadeOut);
        overlay_title.color = new Color(overlay_title.color.r, overlay_title.color.g, overlay_title.color.b, 1f);
        overlay_authors.color = new Color(overlay_authors.color.r, overlay_authors.color.g, overlay_authors.color.b, 1f);
        b_fade = false;
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(timeBeforeTransition);
        SceneManager.LoadScene(sceneTarget);
    }
}