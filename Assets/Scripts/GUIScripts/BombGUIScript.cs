using UnityEngine;
using System.Collections;

public class BombGUIScript : MonoBehaviour {

	public Texture bomb1;
	public Texture bomb2;
	public Texture bomb3;
	public Texture bomb4;
	public Texture bomb5;

	private int bombCount;

	// base height and width of the bomb texture
	public float h = 15f, w = 15f;
	
	// Update is called once per frame
	void Update () 
	{
	
		try{
			bombCount = GameObject.Find ("Player").GetComponent<PlayerController> ().bombCount;
			switch (bombCount) {
			case 0:
				GetComponent<GUITexture>().enabled = false;
				break;
			case 1:
				GetComponent<GUITexture>().enabled = true;
				GetComponent<GUITexture>().texture = bomb1;
				GetComponent<GUITexture>().pixelInset = new Rect(-28f, -h/2, w, h);
				break;
			case 2:
				GetComponent<GUITexture>().enabled = true;
				GetComponent<GUITexture>().texture = bomb2;
				GetComponent<GUITexture>().pixelInset = new Rect(-29f, -h/2, w*2, h);
				break;
			case 3:
				GetComponent<GUITexture>().enabled = true;
				GetComponent<GUITexture>().texture = bomb3;
				GetComponent<GUITexture>().pixelInset = new Rect(-30f, -h/2, w*3, h);
				break;
			case 4:
				GetComponent<GUITexture>().enabled = true;
				GetComponent<GUITexture>().texture = bomb4;
				GetComponent<GUITexture>().pixelInset = new Rect(-31f, -h/2, w*4, h);
				break;
			case 5:
				GetComponent<GUITexture>().enabled = true;
				GetComponent<GUITexture>().texture = bomb5;
				GetComponent<GUITexture>().pixelInset = new Rect(-32f, -h/2, w*5, h);
				break;
			}
		}
		catch{
		
		}
	}
}
