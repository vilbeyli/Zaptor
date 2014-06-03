using UnityEngine;
using System.Collections;

public class PauseTxtScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		guiText.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(PauseScript.gamePaused)
			guiText.enabled = true;
		else
			guiText.enabled = false;
		
	}

	void OnMouseEnter()
	{
		// change color on mouse over
		guiText.color = Color.green;
		audio.Play();
	}
	
	void OnMouseExit()
	{
		// change color back to white
		guiText.color = Color.white;
	}
	
	void OnMouseDown()
	{
		PauseScript.gamePaused = false;
		if(this.name == "TXTRestart"){
			Application.LoadLevel("game");
		}
		if(this.name == "TXTResume")
		{
			GameObject.Find("Main Camera").audio.Play ();
		}
		if(this.name == "TXTMainMenu")
			Application.LoadLevel("menu");
	}
}
