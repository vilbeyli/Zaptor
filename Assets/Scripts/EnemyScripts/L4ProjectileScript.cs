using UnityEngine;
using System.Collections;

public class L4ProjectileScript : MonoBehaviour {
	private Vector3 dir;
	public int speed;

	// Use this for initialization
	void Start () 
	{
		try
		{
			dir = GameObject.Find("Player").transform.position - transform.position;
			dir.Normalize();
		}
		catch
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(dir*Time.deltaTime*speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{

			other.gameObject.GetComponent<PlayerController>().hp -= 6;
			Destroy(gameObject);
		}
	}
}
