using UnityEngine;
using System.Collections;

public class PointsScript : MonoBehaviour {
	private int score;

	// Update is called once per frame
	void Update () 
	{
		try
		{
			score = PlayerController.score;

			// switch (number of digits in score)
			switch(int.Parse(Mathf.Floor(Mathf.Log10 (score)).ToString()))	
			{
			case 0:
				GetComponent<GUIText>().text = "00000" + score.ToString();
				break;
			case 1:
				GetComponent<GUIText>().text = "0000" + score.ToString();
				break;
			case 2:
				GetComponent<GUIText>().text = "000" + score.ToString();
				break;
			case 3:
				GetComponent<GUIText>().text = "00" + score.ToString();
				break;
			case 4:
				GetComponent<GUIText>().text = "0" + score.ToString();
				break;
			case 5:
				GetComponent<GUIText>().text = score.ToString();
				break;
			}
			
		}
		catch{}
	}
}
