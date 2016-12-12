using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_FramerateLimiter : MonoBehaviour {

	public int target_framerate;

	void Awake () {
		QualitySettings.vSyncCount = 0;  // VSync must be disabled
		Application.targetFrameRate = target_framerate;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
