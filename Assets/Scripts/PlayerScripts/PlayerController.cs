/*
 * Mention MillionthVector and, if feasible,
 * place a link to his blog http://millionthvector.blogspot.de.
 * 
 */

/*
 * "Sax, Rock, and Roll" Kevin MacLeod (incompetech.com) 
 * Licensed under Creative Commons: By Attribution 3.0
 * http://creativecommons.org/licenses/by/3.0/
 *
 */

using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public GameObject expl;

	public int hp = 100;
	public int weaponLevel = 1;
	public int bombCount = 0;
	public int score = 0;

	public float speed = 0.3f;

	// Update is called once per frame
	void Update () 
	{

		// rotate ship when moving horizontally
		if(Input.GetAxis("Horizontal") < 0)
			renderer.material.mainTextureOffset = new Vector2(0f, 0f);
		else if (Input.GetAxis("Horizontal") > 0)
			renderer.material.mainTextureOffset = new Vector2(0.668f, 0f);
		else
			renderer.material.mainTextureOffset = new Vector2(0.333f, 0f);

		/*********************************************************/
		/********************** TRANSFORM CODE *******************/
		/*********************************************************/
		//horizontal <- || -horizontal ->
		//vertical down || -vertical up
		float h = -Input.GetAxis ("Horizontal")*speed;
		float v = -Input.GetAxis ("Vertical")*speed;

		// do not let the ship get out of the camera
		Vector3 tmpPos = transform.position;
		tmpPos.x = Mathf.Clamp (tmpPos.x, -12.26f, 10.826f);
		tmpPos.y = Mathf.Clamp (tmpPos.y, -8.9f, 8.9f);
		transform.position = tmpPos;
		
		transform.Translate (h, v, 0);


		if(hp <= 0)
		{
			Instantiate(expl, transform.position, new Quaternion());
			Destroy(gameObject);
		}

	}
}
