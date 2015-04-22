using UnityEngine;
using System.Collections;

public class MenuMusic : MonoBehaviour {

	private static GameObject single = null;

	void Start()
	{
		GetComponent<AudioSource>().Play();
		DontDestroyOnLoad(this.gameObject);
	}

	void Awake()
	{
		if(single == null)
			single = this.gameObject;
		else
			Destroy(gameObject);
	}
}
