using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float playerSpeed = 5f;
	public int turtleCount = 0;

	public float rangeHorizontal = 4.5f;

	public float tiltBackSpeed = 5f;
	
	private float excitement = 1f;

	public GameObject powerUp1;

	GameObject turtle;
	GameObject scalop;
	void Start () {
		turtle = (GameObject) Resources.Load ("Prefabs/TurtlesPowerUp");
		scalop = (GameObject) Resources.Load ("Prefabs/PlayerScallops");
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0f) {
			Unstuck ();
			MoveUsingAxis ();
			TiltBack ();
		}

		if(Input.GetKeyUp(KeyCode.T ) || Input.GetKeyUp(KeyCode.Joystick1Button4) ){
			if (!SingletonController.playerTurtlePUP){
				Instantiate(turtle,Vector3.right * 20,Quaternion.identity);
				SingletonController.playerTurtlePUP = true;
			}
		}

		if(Input.GetKeyUp(KeyCode.Y) || Input.GetKeyUp(KeyCode.Joystick1Button5) ){
			if (!SingletonController.playerScalopPUP){
				Instantiate(scalop, Vector3.zero,Quaternion.Euler(0f,0f,90f) );
				SingletonController.playerScalopPUP = true;
			}
		}



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


	//TODO
	void TiltBack(){
		if (transform.rotation.eulerAngles.z != 0) {
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.identity, tiltBackSpeed / 100);
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
