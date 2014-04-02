using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour {
	private float adjust;
	private float hp;

	// Update is called once per frame
	void Update () 
	{
		try{
			hp = (float)GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().hp;
			if(hp > 0){
				adjust = (100f-hp)/10;
				guiTexture.pixelInset = new Rect (-16, -128+adjust, 32, 256f * hp / 100f);
			}
		}
		catch{
			guiTexture.enabled = false;
		}	
	}
}
