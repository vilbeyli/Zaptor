using UnityEngine;
using System.Collections;

public class L2EnemyScript : EnemyBaseScript {
	
	// Use this for initialization
	protected override void Start () 
	{
		base.Start ();
		hp = 12;
		speed = Random.Range(-3.0f, -3.6f);
		zigZagInterval = 1.5f;
		
	}
	
	
	// Update is called once per frame
	protected override void Update () 
	{
		base.Update ();
	}
}