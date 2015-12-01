using UnityEngine;
using System.Collections;
[RequireComponent(typeof(ReceiveDamage))]
public class RemoveTurtle : MonoBehaviour {

	ReceiveDamage rD;
	GameObject powerUp;
	TurtleLoop tL;
	bool playerLayer;
	void Start () {
		rD = GetComponent<ReceiveDamage> ();
		tL = GetComponent<TurtleLoop> ();
		powerUp = (GameObject)Resources.Load ("Prefabs/PowerUpBubble");
		playerLayer = (gameObject.layer == 9);
	}
	

	void Update () {
		if (rD.hits > 0){

			
			if (playerLayer ? false : tL.havePowerUp){
				GameObject pUp = (GameObject)Instantiate(powerUp, transform.position,Quaternion.identity);
				pUp.GetComponent<PowerUpController>().SetSprite(PowerUpController.pUPKINDS.turtle);
			}
			GameObject.Destroy (gameObject);
		}
	}
}
