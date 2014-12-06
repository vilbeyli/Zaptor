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
				guiText.text = "00000" + score.ToString();
				break;
			case 1:
				guiText.text = "0000" + score.ToString();
				break;
			case 2:
				guiText.text = "000" + score.ToString();
				break;
			case 3:
				guiText.text = "00" + score.ToString();
				break;
			case 4:
				guiText.text = "0" + score.ToString();
				break;
			case 5:
				guiText.text = score.ToString();
				break;
			}
			
		}
		catch{}
	}
}
