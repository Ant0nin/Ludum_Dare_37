using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public float timeBeforeReload = 2f;
    UI_Manager ui;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        ui = GameObject.Find("UI_Overlay").GetComponent<UI_Manager>();
    }

    private IEnumerator RestartLevel(float timeOffset)
    {
        yield return new WaitForSeconds(timeOffset);
        SceneManager.LoadScene("main");
    }

    public void Win()
    {
        ui.FadeOut();
        ui.SetImportantText("You win !");
        RestartLevel(timeBeforeReload);
    }

    public void Lose()
    {
        ui.FadeOut();
        ui.SetImportantText("Game Over");
        IEnumerator coroutine = RestartLevel(timeBeforeReload);
        StartCoroutine(coroutine);
    }
}