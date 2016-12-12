using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public float timeBeforeReload = 2f;
    UI_Manager ui;

    AudioSource audioWin;
    AudioSource audioLose;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ui = GameObject.Find("UI_Overlay").GetComponent<UI_Manager>();
        AudioSource[] sounds = GetComponents<AudioSource>();
        audioWin = sounds[0];
        audioLose = sounds[1];
    }

    private IEnumerator RestartLevel(float timeOffset)
    {
        yield return new WaitForSeconds(timeOffset);
        SceneManager.LoadScene("main");
    }

    public void Win()
    {
        // TODO : Eject bad guy
        ui.FadeOut();
        ui.SetImportantText("You win !");
        audioWin.Play();
        RestartLevel(timeBeforeReload); // TODO : quit game instead
    }

    public void Lose()
    {
        ui.FadeOut();
        ui.SetImportantText("Game Over");
        audioLose.Play();
        IEnumerator coroutine = RestartLevel(timeBeforeReload);
        StartCoroutine(coroutine);
    }
}