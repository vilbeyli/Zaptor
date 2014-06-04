﻿using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public static bool gamePaused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		// pause handling
		if(Input.GetButtonDown("Pause"))
		{
			gamePaused = !gamePaused;
			if(gamePaused)
				GameObject.Find("Main Camera").audio.Pause();
			else
				GameObject.Find("Main Camera").audio.Play();
			
		}
		
		if(gamePaused == true)
		{
			Time.timeScale = 0;
			GameObject.Find("PauseMenu").guiTexture.enabled = true;
		}
		else
		{
			Time.timeScale = 1;
			GameObject.Find("PauseMenu").guiTexture.enabled = false;
		}

	}
}