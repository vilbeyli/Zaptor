using UnityEngine;
using System.Collections;

public class L4EnemyShooterScript : MonoBehaviour {

	public GameObject L4Projectile;
	public float interval;

	private float start;

	// Use this for initialization
	void Start () 
	{
		start = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// if its time to shoot
		if(Time.time - start >= interval)
		{
			Instantiate(L4Projectile, transform.position, transform.rotation);
			start = Time.time;
		}


	}
}
