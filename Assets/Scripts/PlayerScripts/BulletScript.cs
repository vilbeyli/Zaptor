using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
	private float speed = 25f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate (new Vector3 (0, speed*Time.deltaTime, 0));
		if (transform.position.y > 10.2)
			Destroy (gameObject);

		
	}
}
