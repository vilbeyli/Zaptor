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
				guiTexture.enabled = false;
				break;
			case 1:
				guiTexture.enabled = true;
				guiTexture.texture = bomb1;
				guiTexture.pixelInset = new Rect(-28f, -h/2, w, h);
				break;
			case 2:
				guiTexture.enabled = true;
				guiTexture.texture = bomb2;
				guiTexture.pixelInset = new Rect(-29f, -h/2, w*2, h);
				break;
			case 3:
				guiTexture.enabled = true;
				guiTexture.texture = bomb3;
				guiTexture.pixelInset = new Rect(-30f, -h/2, w*3, h);
				break;
			case 4:
				guiTexture.enabled = true;
				guiTexture.texture = bomb4;
				guiTexture.pixelInset = new Rect(-31f, -h/2, w*4, h);
				break;
			case 5:
				guiTexture.enabled = true;
				guiTexture.texture = bomb5;
				guiTexture.pixelInset = new Rect(-32f, -h/2, w*5, h);
				break;
			}
		}
		catch{
		
		}
	}
}
