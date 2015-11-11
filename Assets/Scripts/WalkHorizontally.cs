using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]

public class WalkHorizontally : MonoBehaviour {
	public float speed = 8f;
	public float amplitude = 4.5f;
	public bool movingToRight = true;
	private bool move = true;

	private SpriteRenderer sR;

	void Start () {
		sR = GetComponent<SpriteRenderer>();
		FixAmplitudebySpriteWidth ();
		SingletonController.boss = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
		MoveAround ();

	}

	
	void MoveAround(){
		if (transform.position.x >= -amplitude && movingToRight && move) {
			transform.Translate (Vector3.right * speed / 100);
			if (transform.position.x > amplitude){
				transform.position = new Vector3(amplitude, transform.position.y);
				movingToRight = false;
			}
		}
		else if (transform.position.x <= amplitude && !movingToRight && move) {
			transform.Translate (Vector3.left * speed / 100);
			if (transform.position.x < -amplitude){
				transform.position = new Vector3(-amplitude, transform.position.y);
				movingToRight = true;
			}
		}
	}
	
	void FixAmplitudebySpriteWidth(){
		float w = sR.sprite.bounds.size.x;
		amplitude = amplitude - (w / 2);
		
	}
	

}
