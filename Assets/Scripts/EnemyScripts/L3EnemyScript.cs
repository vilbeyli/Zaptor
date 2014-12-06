using UnityEngine;
using System.Collections;

public class L3EnemyScript : MonoBehaviour {

	public GameObject expl;

	public float hp = 4f;
	public float speed = -16f;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		//translate
		transform.Translate (new Vector3(0f, 1f, 0f)*speed*Time.deltaTime);

		// hp <= 0 ?
		if(hp <= 0)
		{
			Destroy (gameObject);
			Instantiate(expl, transform.position, new Quaternion());
			PlayerController.score += 5;
		}

		// off screen ? destroy;
		if(transform.position.y < -12f)
			Destroy(gameObject);
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Bullet"){
			hp--;
			Destroy(other.gameObject);
		}
		if (other.transform.tag == "BBullet"){
			hp -= 2;
			Destroy(other.gameObject);
		}
		if (other.transform.tag == "Player"){
			Kill ();
			other.gameObject.GetComponent<PlayerController>().hp -= 5;
		}
	}

	public void Kill()
	{
		hp -= 100;
	}
}
