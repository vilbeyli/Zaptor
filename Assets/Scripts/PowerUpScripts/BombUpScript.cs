using UnityEngine;
using System.Collections;

public class BombUpScript : MonoBehaviour {
	
	public float speed;
	public float rotationSpeed;
	
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (new Vector3 (0f, rotationSpeed*Time.deltaTime, 0f));
		transform.Translate (0f, speed * Time.deltaTime, 0f);
		
		if(transform.position.y < -12f)
		{
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			if(other.gameObject.GetComponent<PlayerController>().bombCount < 5)
			{
				other.gameObject.GetComponent<PlayerController>().bombCount++;
			}
			else
			{
				other.gameObject.GetComponent<PlayerController>().score += 50;
			}	
			
			Destroy(gameObject);
		}
	}

}
