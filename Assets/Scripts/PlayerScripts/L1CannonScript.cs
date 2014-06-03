using UnityEngine;
using System.Collections;

public class L1CannonScript : MonoBehaviour {

	public GameObject Bullet;
	public GameObject BBullet;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1") && !PauseScript.gamePaused) 
		{
			transform.parent.audio.Play ();
			int wepLvl = transform.parent.gameObject.GetComponent<PlayerController>().weaponLevel;
			if(wepLvl == 1)
			{
				Instantiate(Bullet, transform.position, transform.rotation);
			}

			if (wepLvl >= 2)
			{
				Instantiate(BBullet, transform.position, transform.rotation);
			}
			if(wepLvl == 3 || wepLvl == 4)
			{
				Quaternion quatL = new Quaternion(-8f, 90f, 0f, 0f);
				Quaternion quatR = new Quaternion(8f, 90f, 0f, 0f);

				if(this.name == "FireCannonL")
					Instantiate(Bullet, transform.position, quatL);
				else if(this.name == "FireCannonR")
					Instantiate(Bullet, transform.position, quatR);
			}
			if (wepLvl >= 5)
			{
				Quaternion quatL = new Quaternion(-8f, 90f, 0f, 0f);
				Quaternion quatR = new Quaternion(8f, 90f, 0f, 0f);
				
				if(this.name == "FireCannonL")
					Instantiate(BBullet, transform.position, quatL);
				else if(this.name == "FireCannonR")
					Instantiate(BBullet, transform.position, quatR);
			}

		}
	}


}
