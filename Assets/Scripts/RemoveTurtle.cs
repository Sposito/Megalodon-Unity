﻿using UnityEngine;
using System.Collections;
[RequireComponent(typeof(ReceiveDamage))]
public class RemoveTurtle : MonoBehaviour {

	ReceiveDamage rD;
	GameObject powerUp;
	TurtleLoop tL;
	void Start () {
		rD = GetComponent<ReceiveDamage> ();
		tL = GetComponent<TurtleLoop> ();
		powerUp = (GameObject)Resources.Load ("Prefabs/PowerUpBubble");
	}
	

	void Update () {
		if (rD.hits > 0){

			
			if (tL.havePowerUp){
				GameObject pUp = (GameObject)Instantiate(powerUp, transform.position,Quaternion.identity);
			}
			GameObject.Destroy (gameObject);
		}
	}
}