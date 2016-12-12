using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_TimerScreen : MonoBehaviour {

	public float timer_length = 360f;
	public float timer_current;
	public GameObject text_3D;
	public string temp;

	// Use this for initialization
	void Start ()
	{
		timer_current = timer_length;
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer_current -=Time.deltaTime;

		temp = timer_current.ToString();
		temp = temp.Substring(0, 3);

		text_3D.GetComponent<TextMesh>().text = temp;

	}
}
