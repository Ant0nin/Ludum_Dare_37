using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_VideoMan : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();
		((MovieTexture)GetComponent<Renderer>().material.mainTexture).loop = true;

		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
