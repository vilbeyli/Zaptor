using UnityEngine;
using System.Collections;

public class EnemyBaseScript : MonoBehaviour {
	public GameObject expl;
	public GameObject enemyProjectile;
	public GameObject HPUp;
	public GameObject WepUp;
	public GameObject BombUp;
	
	public int hp;

	// shoot variables
	protected float shootInterval;
	protected float start1, start2;
	protected bool shootSymmetric;
	protected Vector3 pos1, pos2;
	protected float xradius = 0.7f;
	protected float yradius = 0f;

	// translation variables
	protected bool isZigZag;
	protected float zigZagTime;
	protected float zigZagInterval = 1f;
	protected float speed = -0.02f;
	protected Vector3 direction;

	// drop chances
	protected float hpDrop = 0.90f;
	protected float bombDrop = 0.95f;
	protected float wepDrop = 0.97f; 
	
	// Use this for initialization
	protected virtual void Start () 
	{

		// SHOOTER INITIALIZATION
		if(Random.Range (0f, 1f) < 0.5f)
			shootSymmetric = true;
		else
			shootSymmetric = false;

		// intervals
		shootInterval = Random.Range (1.5f, 3f);	
		start1 = Time.time;
		start2 = start1 + shootInterval / 2;


		// TRANSLATION INITIALIZATION
		if(Random.Range(0f, 1f) <= 0.5f)
			isZigZag = true;
		else
			isZigZag = false;
		if(isZigZag == true)
		{
			zigZagTime = Time.time;
			direction = new Vector3(1f, 1f, 0f);
		}

	}

	protected virtual void Update()
	{
		if(isZigZag == true)
		{
			transform.Translate(direction*speed*Time.deltaTime);
			if(Time.time - zigZagTime >= zigZagInterval){
				direction.x = -direction.x;
				zigZagTime = Time.time;
			}
		}
		else
		{
			transform.Translate (new Vector3(0f, 1f, 0f)*speed*Time.deltaTime);
		}

		updateShooterPositions ();
		shoot ();
		checkHP ();
	}
	

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Bullet"){
			hp--;
			Destroy(other.gameObject);
		}
		if (other.transform.tag == "BBullet") {
			hp -= 2;
			Destroy (other.gameObject);
		}
		if (other.transform.tag == "Player"){
			Kill ();
			other.gameObject.GetComponent<PlayerController>().hp -= 10;
		}
	}

	protected void updateShooterPositions()
	{
		pos1 = transform.position;
		pos1.x += xradius;
		pos2 = pos1;
		pos2.x -= 2*xradius;
		pos1.y += yradius;
		pos2.y += yradius;
	}

	protected void shoot()
	{
		if(Time.time >= start1 + shootInterval)
		{
			Instantiate(enemyProjectile, pos1, new Quaternion(0f, -1f, 0f, 0f));
			
			// reset time
			start1 = Time.time;

			if(shootSymmetric == true)
				Instantiate(enemyProjectile, pos2, new Quaternion(0f, -1f, 0f, 0f));
		}
		
		if(shootSymmetric == false)
		{
			if(Time.time >= start2 + shootInterval)
			{
				// projectile instantiation
				Instantiate(enemyProjectile, pos2, new Quaternion(0f, -1f, 0f, 0f));
				
				// reset time
				start2 = Time.time;
			}
		}
	}

	protected void checkHP()
	{
		if (hp <= 0)
		{	
			// update score
			if(gameObject.name == "L1Enemy(Clone)")
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score += 5;
			else if(gameObject.name == "L2Enemy(Clone)")
				GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().score += 10;

			// destroy object
			Destroy (gameObject);
			Instantiate(expl, transform.position, new Quaternion());
			
			// PowerUps
			float roll = Random.Range (0f, 1f);
			if(roll >= hpDrop)
			{
				if(roll >= wepDrop)
				{
					Instantiate(WepUp, transform.position, new Quaternion());
				}
				else if (roll < wepDrop && roll >= bombDrop)
				{
					Instantiate(BombUp, transform.position, new Quaternion());
				}
				else if (roll < bombDrop)
				{
					Instantiate(HPUp, transform.position, new Quaternion());
				}
			}
		}

		// off screen ? destroy;
		if(transform.position.y < -12f)
			Destroy(gameObject);
		
	}

	public void Kill()
	{
		hp -= 100;
	}
}
