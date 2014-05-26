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
#define debug

using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour 
{
	public GameObject expl;
	public AudioClip powerUp;

	public int hp = 100;
	public int weaponLevel = 1;
	public int bombCount = 0;
	public int score = 0;

	public float speed = 0.3f;

	// Update is called once per frame
	void Update () 
	{

		// rotate ship when moving horizontally
		Vector3 tf = transform.position ;
		tf.y -= 1.7f;
		if(Input.GetAxis("Horizontal") < 0){	// left
			renderer.material.mainTextureOffset = new Vector2(0f, 0f);
			tf.x -= 0.15f;
			GameObject.Find("Jets").transform.position = tf;
			
		}
		else if (Input.GetAxis("Horizontal") > 0){	// right
			renderer.material.mainTextureOffset = new Vector2(0.668f, 0f);
			tf.x += 0.15f;
			GameObject.Find("Jets").transform.position = tf;
		}
		else{
			renderer.material.mainTextureOffset = new Vector2(0.333f, 0f);

			GameObject.Find("Jets").transform.position = tf;
		}

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
		tmpPos.y = Mathf.Clamp (tmpPos.y, -8.5f, 8.5f);
		transform.position = tmpPos;
		
		transform.Translate (h, v, 0);


		if(hp <= 0)
		{
			Instantiate(expl, transform.position, new Quaternion());
			Destroy(gameObject);
			GameObject.Find("Main Camera").GetComponent<ShakeCameraScript>().restartGame();
		}



#if debug
		if(Input.GetButtonDown("Cheat"))
		{
			hp = 100;
			weaponLevel = 5;
			bombCount = 5;
			score = 800;
		}
#endif

	}

	void OnCollisionEnter(Collision other)
	{
		if(other.transform.tag == "PowerUp")
			AudioSource.PlayClipAtPoint(powerUp, other.transform.position);
		 
	}


}
