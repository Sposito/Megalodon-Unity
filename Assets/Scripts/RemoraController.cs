using UnityEngine;
using System.Collections;

public class RemoraController : MonoBehaviour {

//	private GameObject[] remoraPool = new GameObject[6];
	public GameObject remoraPrefab;
	GameObject rFin;
	GameObject lFin;
	bool tikTok = false;
	int bullets = 2;
	public float reloadTime = 1f;
	float timer = 0f;


	// Use this for initialization
	void Start () {
		//CreateRemoras ();

	
	}
	

	void Update () {
		timer += Time.deltaTime;
		AutoReload ();

		if(Input.GetKeyUp(KeyCode.Space ) || Input.GetKeyUp(KeyCode.Joystick1Button2) ){
			if(bullets > 0)
			Fire ();
		}

	
	}

	void Fire(){
		Vector3 position = tikTok ? transform.FindChild ("LeftFin").position : transform.FindChild ("RightFin").position;
		GameObject remora = (GameObject)Instantiate(remoraPrefab, position, transform.rotation);
		remora.layer = 9; // This sets the remora in the Player's layer of collision, meaning it only hits enemy "stuff"
		tikTok = !tikTok;
		bullets--;
		timer = 0f;

	}

	void AutoReload(){
		if (bullets < 2 && timer > reloadTime) {
			bullets++;
			timer = 0f;
		}
	}


}
