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
                offset = float.Parse(lines[i]),
                text = lines[++i],
                audio = Resources.Load<AudioClip>("Dialogs/Audio/" + lines[++i]),
            };
            i++;
            sentences.Add(st);
        }
    }

    public void Diffuse()
    {
        foreach(DialogSentence st in sentences)
        {
            IEnumerator coroutine = this.WaitAndDiffuseSentence(st);
            StartCoroutine(coroutine);
        }

        // TODO : stop dialog

        // TODO
        /*if (autoDestroyAfterDiffusion)
            GameObject.Destroy(this.gameObject);*/
    }

    private IEnumerator WaitAndDiffuseSentence(DialogSentence st)
    {
        yield return new WaitForSeconds(st.offset);
        ui.SetDialog(st.text);
        this.audioSource.PlayOneShot(st.audio);
    }
}
