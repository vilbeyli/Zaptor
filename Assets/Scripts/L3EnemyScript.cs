using UnityEngine;
using System.Collections;

public class L3EnemyScript : MonoBehaviour {

	public GameObject expl;

	private float hp = 2f;
	private float speed = -10f;

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
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score += 5;
		}

		// off screen ? destroy;
		if(transform.position.y < -12f)
			Destroy(gameObject);
	
	}

	void OnCollisionEnter(Collision other)
	{
		if (other.transform.tag == "Bullet")
			hp--;
		if (other.transform.tag == "BBullet")
			hp -= 2;
		if (other.transform.tag == "Player"){
			hp -= 8;
			other.gameObject.GetComponent<PlayerController>().hp -= 5;
		}
	}
}
