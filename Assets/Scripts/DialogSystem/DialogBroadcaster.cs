using UnityEngine;
using System.Collections.Generic;
using System.Globalization;
using System.Collections;

public class DialogBroadcaster : MonoBehaviour
{
    public string dialogFilename;
    public bool autoStart = true;
    public bool autoDestroyAfterDiffusion = true;

    AudioSource audioSource;
    List<DialogSentence> sentences;
    UI_Manager ui;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ui = GameObject.Find("UI_Overlay").GetComponent<UI_Manager>();

        LoadDialog(dialogFilename);
        if (autoStart)
            Diffuse();
    }

    public void LoadDialog(string filename)
    {
        dialogFilename = filename;
        TextAsset dialogImport = Resources.Load<TextAsset>("Dialogs/"+ dialogFilename);
        sentences = new List<DialogSentence>();
        string[] lines = dialogImport.text.Split('\n');
        int i = 0;

        while(i < lines.Length)
        {
            DialogSentence st = new DialogSentence()
            {
                text = lines[i],
                audio = Resources.Load<AudioClip>("Dialogs/Audio/" + lines[++i]),
                duration = float.Parse(lines[++i]),
            };
            i++;
            sentences.Add(st);
        }
    }

    public void Diffuse()
    {
        float offset = 0.0f;
        IEnumerator coroutine;
        foreach (DialogSentence st in sentences)
        {
            coroutine = this.WaitAndDiffuseSentence(st, offset);
            StartCoroutine(coroutine);
            offset += st.duration;
        }
        coroutine = this.WaitAndStopDialog(offset);
    }

    private IEnumerator WaitAndDiffuseSentence(DialogSentence st, float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        ui.SetDialog(st.text);
        this.audioSource.PlayOneShot(st.audio);
    }

    private IEnumerator WaitAndStopDialog(float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);
        ui.SetDialog("");
        if (autoDestroyAfterDiffusion)
            GameObject.Destroy(this.gameObject);
    }
}
