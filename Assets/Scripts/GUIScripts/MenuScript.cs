﻿using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	public AudioClip beep;

	void Start()
	{
		transform.GetChild(0).gameObject.SetActive(false);
	}

	void OnMouseEnter()
	{
		// change color on mouse over
		guiText.color = Color.green;
		transform.GetChild(0).gameObject.SetActive(true);
		//AudioSource.PlayClipAtPoint(beep, transform.position);
		audio.Play();
	}

	void OnMouseExit()
	{
		// change color back to white
		guiText.color = Color.white;
		transform.GetChild(0).gameObject.SetActive(false);
	}

	void OnMouseDown()
	{
		if(this.name == "Play")
			Application.LoadLevel("game");
		if(this.name == "Quit")
			Application.Quit();
		if(this.name == "Instructions")
			Application.LoadLevel("instuctions");
		if(this.name == "Creadits")
			Application.LoadLevel("credits");
	}
}
