using UnityEngine;
using System.Collections;

public class AudioScript : MonoBehaviour {

	private static AudioSource menuMusic, gameMusic;
	static public bool inGame;

	//----------------------------------------------
	// Singleton
	static AudioScript _instance;

	static public AudioScript instance
	{
		get
		{
			if(_instance == null)
			{
				_instance = GameObject.FindObjectOfType<AudioScript>();
				DontDestroyOnLoad(_instance.gameObject);
			}
			return _instance;
		}
	}

	void Awake()
	{
		if(_instance == null)
		{
			// If the first instance, make it singleton
			_instance = this;
			DontDestroyOnLoad(this);
		}
		else
		{
			// if it singleton already exists
			// destroy the other
			if(this != _instance)
				Destroy(this.gameObject);

		}
	}

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(gameObject);
		inGame = false;
		menuMusic = GetComponents<AudioSource>()[0];
		gameMusic = GetComponents<AudioSource>()[1];
		menuMusic.Play ();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnLevelWasLoaded(int level)
	{
		if(level == 1)
		{
			menuMusic.Stop ();
			gameMusic.Play ();
		}
		else
		{
			gameMusic.Stop ();
			if(!menuMusic.isPlaying)
				menuMusic.Play ();
		}
	}

	static public void TogglePause(bool pause)
	{
		if(!pause) gameMusic.Play (); else gameMusic.Pause ();
	}
}
