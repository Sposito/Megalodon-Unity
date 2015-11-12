using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerSpeed = 5f;

	public float rangeHorizontal = 4.5f;
	
	private float excitement = 1f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Unstuck ();
		MoveUsingAxis ();
		TiltBack ();

	}

	private void MoveUsingAxis(){
		if (Mathf.Abs(transform.position.x) <= rangeHorizontal) {
			transform.position += (Vector3.right * playerSpeed / 10f * Input.GetAxis ("Horizontal"));
			transform.Rotate(Vector3.forward * Input.GetAxis("Horizontal") * -4f);
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



	void TiltBack(){
		if (transform.rotation.eulerAngles.z != 0) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.identity, 0.025f);
			//if(Mathf.Abs(transform.rotation.eulerAngles.z) < 5)
				//transform.rotation = Quaternion.identity;
		}
	}

	void CalmDown(){
		if (excitement > 1f)
			excitement -= 0.005f;

	}
}
