using UnityEngine;
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
			AudioScript.TogglePause(gamePaused);
		}
		
		if(gamePaused == true)
		{
			Time.timeScale = 0;
			GameObject.Find("PauseMenu").GetComponent<GUITexture>().enabled = true;
		}
		else
		{
			Time.timeScale = 1;
			GameObject.Find("PauseMenu").GetComponent<GUITexture>().enabled = false;
		}

	}
}
