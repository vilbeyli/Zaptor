using UnityEngine;
using System.Collections;

public class L4EnemyScript : EnemyBaseScript {

	// Use this for initialization
	protected override void Start () 
	{
		base.Start();
		hp = 30;
		speed = -1f;
		score = 25;
	
		isZigZag = false;
		haveShooter = false;
	}
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update();

		 
		
	}
	


}
