using UnityEngine;
using System.Collections;

public class RemoveScallop : MonoBehaviour {

	ReceiveDamage rD;
	GameObject powerUp;
	TurtleLoop tL;
	bool playerLayer;
	void Start () {
		rD = GetComponent<ReceiveDamage> ();
		powerUp = (GameObject)Resources.Load ("Prefabs/PowerUpBubble");
		playerLayer = (gameObject.layer == 9);
	}
	
	void Update () {
		if (rD.hits > 0){
			
			
			//if (playerLayer ){
			//	GameObject pUp = (GameObject)Instantiate(powerUp, transform.position,Quaternion.identity);
			//	pUp.GetComponent<PowerUpController>().SetSprite(PowerUpController.pUPKINDS.turtle);
			//}
			GameObject.Destroy (gameObject);
		}
	}
}
