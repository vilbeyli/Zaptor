using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {

	Vector3 startMarker;
	Vector3 endMarker;
	private float speed;
	private float startTime;
	private float journeyLength;
	
	// Use this for initialization
	void Start () 
	{
		startTime = Time.time;
		startMarker = new Vector3(transform.position.x, transform.position.y, 0);
		endMarker = new Vector3 (0.078f, -0.089f, 0f);
		journeyLength = Vector3.Distance(startMarker, endMarker);
		speed = journeyLength/1.75f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);
		//transform.Rotate(new Vector3(1f, 0f, 0f) , 320*Time.deltaTime);
		transform.RotateAround (Vector2.right, 20 * Time.deltaTime);

		if(transform.position == endMarker)
		{
			// destroy the bomb
			Destroy (gameObject, 0.05f);
			
			// explosion effect
			
			// destroy all enemy units
			foreach(GameObject o in GameObject.FindGameObjectsWithTag("Enemy"))
			{
				switch(o.gameObject.name)
				{
					case "L1Enemy(Clone)":
						o.GetComponent<L1EnemyScript>().Kill ();
						break;
					case "L2Enemy(Clone)":
						o.GetComponent<L2EnemyScript>().Kill ();
						break;
					case "L3Enemy(Clone)":
						o.GetComponent<L3EnemyScript>().Kill ();
						break;
				}	
			}
		}
	}
}
