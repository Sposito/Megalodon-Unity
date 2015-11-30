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

		//HORIZONTAL
		if (Mathf.Abs(transform.position.x) <= rangeHorizontal) {
			transform.position += (Vector3.right * playerSpeed / 10f * Input.GetAxis ("Horizontal"));
			transform.Rotate(Vector3.forward * Input.GetAxis("Horizontal") * -4f);
		}

		//VERTICAL
		if (transform.position.y <= -1f && transform.position.y >= -4.5f) {
			transform.position += (Vector3.up * playerSpeed / 10f * Input.GetAxis ("Vertical"));
		//Rotate when swming down

			if(Input.GetAxis("Vertical") < 0  && transform.position.y > -4.5f )
				transform.Rotate(Vector3.forward * Input.GetAxis("Vertical") * -14f);
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
		//TODO THIS VALUES ARE HARDCODED! IT MUST BE CHANGE IN THE FUTURE!!
		if (transform.position.y > -1)
			transform.position = new Vector3 (transform.position.x, -1f);
		else if (transform.position.y < -4.5f)
			transform.position = new Vector3 (transform.position.x, -4.5f);


		  

	}



	void TiltBack(){
		if (transform.rotation.eulerAngles.z != 0) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.identity, 0.05f);
			//if(Mathf.Abs(transform.rotation.eulerAngles.z) < 5)
				//transform.rotation = Quaternion.identity;
		}

		//ROTATE UNSTUCK
		if (Mathf.Abs (transform.rotation.eulerAngles.z) < 2f || Mathf.Abs (transform.rotation.eulerAngles.z) > 358f)
			transform.rotation = Quaternion.identity;
	}

	void CalmDown(){
		if (excitement > 1f)
			excitement -= 0.005f;

	}
}
