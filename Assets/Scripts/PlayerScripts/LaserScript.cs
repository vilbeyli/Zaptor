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

	private bool justHit = false;
	
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
				justHit = true;
				processHit (hit.collider.gameObject.tag);
			}
			else 
			{
				endPosition = new Vector3(startPosition.x, 9.9f, 0);
				laser.SetPosition(0, startPosition);	
				laser.SetPosition(1, endPosition);		
				justHit = false;
			}

			// play the laser effect
			gameObject.GetComponentInChildren<ParticleSystem>().Play();
			gameObject.audio.Play();
		}
		
		// Fading effect
		if(justFired == true)
		{
			// update laser beam position (prevent bending after shooting)
			laser.SetPosition(0, transform.position);
			if(Physics.Raycast(transform.position, new Vector3(0,1,0), out hit, 12.58f, 1<<8)){
				endPosition = new Vector3(transform.position.x, endPosition.y, 0f);
				if(justHit == false && timeElapsed <= 0.1f)
				{	// if laser didin't initially hit but hit after updating position (while moving)
					processHit(hit.collider.gameObject.tag);
					justHit = true;
				}
			}
			else  // if still no hit, let laser go to the edge of the screen
				endPosition = new Vector3(transform.position.x, 9.9f, 0);
			laser.SetPosition(1, endPosition);

			// apply fading effect to the laser beam
			timeElapsed += Time.deltaTime;
			if(timeElapsed > 0.05f) laser.SetWidth(0.05f, 0.05f);
			if(timeElapsed > 0.075f) laser.SetWidth(0.025f, 0.025f);
			if(timeElapsed > 0.1f)
			{	// laser fades completely after 0.1 seconds.
				laser.SetPosition(0, new Vector3(0,0,0));
				laser.SetPosition(1, new Vector3(0,0,0));
				laser.SetWidth(0.1f, 0.1f);
			}

			// apply laser cannon cooldown
			if(timeElapsed > 0.26)	
			{
				timeElapsed = 0.0f;
				justFired = false;
			}
		}
	}

	void processHit(string tag)
	{
		switch(tag)
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

}
