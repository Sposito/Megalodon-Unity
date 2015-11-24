using UnityEngine;
using System.Collections;

public class MegalodonBite : MonoBehaviour {
	bool movingDown =false;
	float amplitude = 10f;
	float speed = 5f;


	void MoveAround(){
		if (transform.position.x >= -amplitude && movingDown ) {
			transform.position += (Vector3.right * speed / 100);
			if (transform.position.x > amplitude){
				transform.position = new Vector3(amplitude, transform.position.y);
				movingDown = false;
			}
		}
		else if (transform.position.x <= amplitude && !movingDown) {
			transform.position += (Vector3.left * speed / 100);
			if (transform.position.x < -amplitude){
				transform.position = new Vector3(-amplitude, transform.position.y);
				movingDown = true;
			}
		}
	}

}
