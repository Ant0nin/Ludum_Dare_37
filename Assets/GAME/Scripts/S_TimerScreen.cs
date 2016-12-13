using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TimerScreen : MonoBehaviour {

	public float timer_length = 360f;
	public float timer_current;
	public GameObject text_3D;
	public string temp;
    Game_Manager game;
	public Material green1;
	public Material green2;

	// Use this for initialization
	void Start ()
	{
		timer_current = timer_length;
        game = GameObject.Find("GameManager").GetComponent<Game_Manager>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer_current -=Time.deltaTime;

		temp = timer_current.ToString();
		temp = temp.Substring(0, 3);

		text_3D.GetComponent<TextMesh>().text = temp;

        if(timer_current <= 0f)
        {
            timer_current = 0f;

            game.Lose();
            Destroy(this);
        }
	}
}
