using UnityEngine;
using System.Collections;

public class L1EnemyScript : EnemyBaseScript 
{

	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();	// common member initializations
		hp = 8;
		speed = Random.Range(-3.2f, -1.8f);
		isZigZag = false;
		score = 5;
	}
	
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update ();
	}

}

