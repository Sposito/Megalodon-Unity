using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerSpeed = 5f;

	public float rangeHorizontal = 4.5f;

	public Vector3 lastFramePosition;
	public float lastRotation;

	// Use this for initialization
	void Start () {
		lastFramePosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Unstuck ();
		MoveUsingAxis ();

	}

	private void MoveUsingAxis(){
		if (Mathf.Abs(transform.position.x) <= rangeHorizontal) {
			transform.Translate (Vector3.right * playerSpeed / 10f * Input.GetAxis ("Horizontal"));
		}

	}

	private void Unstuck(){

		//HORIZONTAL UNSTUCK
		if (transform.position.x < -rangeHorizontal) {
			transform.position = new Vector3(-rangeHorizontal,transform.position.y);

		}

		else if (transform.position.x > rangeHorizontal) {
			transform.position = new Vector3(rangeHorizontal,transform.position.y);
		}

		//VERTICAL UNSTUCK

		//TODO

	}

	private void TurnWhileSwim(){
		Vector3 temp = transform.position;
		if (lastFramePosition.x != transform.position.x) {
			transform.rotation = Quaternion.Euler(0f,0f, lastFramePosition.x - transform.position.x);
		}
		transform.position = temp;
	}
}
