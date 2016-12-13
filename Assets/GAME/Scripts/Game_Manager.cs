using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public float timeBeforeReload = 2f;
    UI_Manager ui;

	public AudioClip audioWin;
	public AudioClip audioLose;
	private AudioSource diffuseur;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ui = GameObject.Find("UI_Overlay").GetComponent<UI_Manager>();

		diffuseur = this.GetComponent<AudioSource>();
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
        ui.SetImportantText("You ejected the Captain, you survived!");
		diffuseur.PlayOneShot(audioWin);
        RestartLevel(timeBeforeReload); // TODO : quit game instead
    }

    public void Lose()
    {
        ui.FadeOut();
        ui.SetImportantText("The Captain killed you...");
		diffuseur.PlayOneShot(audioLose);
        IEnumerator coroutine = RestartLevel(timeBeforeReload);
        StartCoroutine(coroutine);
    }
}