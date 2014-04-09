using UnityEngine;
using System.Collections;

public class ShakeCameraScript : MonoBehaviour {

	private bool shakeCam = false;
	public float offset;
	public float interval;

	void Update()
	{
		if(shakeCam == true)
		{
			StartCoroutine(Shake());
			shakeCam = false;
		}
	}
	

	IEnumerator Shake()
	{
		transform.Translate(new Vector3(offset, 0f, 0f));
		yield return new WaitForSeconds(interval);
		transform.Translate(new Vector3(-offset, 0f, 0f));
		yield return new WaitForSeconds(interval);
		transform.Translate(new Vector3(offset, 0f, 0f));
		yield return new WaitForSeconds(interval);
		transform.Translate(new Vector3(-offset, 0f, 0f));
		yield return new WaitForSeconds(interval);
		transform.Translate(new Vector3(offset, 0f, 0f));
		yield return new WaitForSeconds(interval);
		transform.Translate(new Vector3(-offset, 0f, 0f));
	}

	public void ShakeCamera()
	{
		shakeCam = true;
	}

	public void restartGame()
	{
		StartCoroutine(Restart ());
	}

	IEnumerator Restart()
	{
		print ("Waiting for 5 seconds for new game!");
		yield return new WaitForSeconds(5f);
		print ("wait is over");
		Application.LoadLevel("game");
	}

}
