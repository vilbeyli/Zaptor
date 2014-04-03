using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour 
{
	
	LineRenderer laser;
	public static bool justFired = false;
	private float timeElapsed = 0.0f;
	private Vector3 startPosition;
	private Vector3 endPosition;
	private RaycastHit hit;
	private PlayerController player;
	
	// Use this for initialization
	void Start () 
	{
		GameObject playerObject = GameObject.FindWithTag ("Player");
		if(playerObject != null)
		{
			player = playerObject.GetComponent<PlayerController>();
		}

		laser = GameObject.Find ("Player/LaserCannon").GetComponent<LineRenderer>();
		laser.SetPosition(0, new Vector3(0,0,0));
		laser.SetPosition(1, new Vector3(0,0,0));
	}
	
	// Update is called once per frame
	void Update () 
	{

		// If laser is fired
		if(player.weaponLevel >= 4 && Input.GetButtonDown("Fire1") && justFired == false)
		{
			startPosition = transform.position;
			justFired = true;
			
			// Collision
			if(Physics.Raycast(transform.position, new Vector3(0,1,0), out hit, 12.58f, 1<<8))
			{
				//print(hit.collider.gameObject.tag + " " + hit.collider.gameObject.name);
				switch(hit.collider.gameObject.tag)
				{
				case "Enemy":
					// adjust laser beam position
					endPosition = new Vector3(startPosition.x,
					                          hit.collider.gameObject.transform.position.y, 0f);
					
					laser.SetPosition(0, startPosition);
					laser.SetPosition(1, endPosition);

					// trigger laser hit events
					switch(hit.collider.gameObject.name)
					{
					case "L1Enemy(Clone)":
					case "L1Enemy":
						hit.collider.gameObject.GetComponent<L1EnemyScript>().hp -= 5;
						break;
					case "L2Enemy(Clone)":
					case "L2Enemy":
						hit.collider.gameObject.GetComponent<L2EnemyScript>().hp -= 5;
						break;
					case "L3Enemy(Clone)":
					case "L3Enemy":
						hit.collider.gameObject.GetComponent<L3EnemyScript>().hp -= 5;
						break;
					}
					
					break;

				}
			}
			else {
				startPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
				endPosition = new Vector3(startPosition.x, 9.9f, 0);
				laser.SetPosition(0, startPosition);
				laser.SetPosition(1, endPosition);
			}

			// play the laser effect
			gameObject.GetComponentInChildren<ParticleSystem>().Play();
			gameObject.audio.Play();
		}
		
		// Fading effect
		if(justFired == true)
		{
			// update laser beam position
			laser.SetPosition(0, transform.position);
			if(Physics.Raycast(transform.position, new Vector3(0,1,0), out hit, 12.58f, 1<<8))
				endPosition = new Vector3(transform.position.x, endPosition.y, 0f);
			else
				endPosition = new Vector3(transform.position.x, 9.9f, 0);
			laser.SetPosition(1, endPosition);

			timeElapsed += Time.deltaTime;
			//print ("Time elapsed: " + timeElapsed);
			if(timeElapsed > 0.05f) laser.SetWidth(0.05f, 0.05f);
			if(timeElapsed > 0.075f) laser.SetWidth(0.025f, 0.025f);
			if(timeElapsed > 0.1f)
			{
				laser.SetPosition(0, new Vector3(0,0,0));
				laser.SetPosition(1, new Vector3(0,0,0));
				laser.SetWidth(0.1f, 0.1f);
			}
			if(timeElapsed > 0.26)
			{
				timeElapsed = 0.0f;
				justFired = false;
			}
		}
	}
}
