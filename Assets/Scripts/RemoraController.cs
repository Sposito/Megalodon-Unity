using UnityEngine;
using System.Collections;

public class RemoraController : MonoBehaviour {

//	private GameObject[] remoraPool = new GameObject[6];
	public GameObject remoraPrefab;
	GameObject rFin;
	GameObject lFin;
	bool tikTok = false;


	// Use this for initialization
	void Start () {
		//CreateRemoras ();
	}
	

	void Update () {
		if(Input.GetKeyUp(KeyCode.Space) ){
			Fire ();
		}

	
	}

	void Fire(){
		Vector3 position = tikTok ? transform.FindChild ("LeftFin").position : transform.FindChild ("RightFin").position;
		GameObject remora = (GameObject)Instantiate(remoraPrefab, position, transform.rotation);
		remora.layer = 9; // This sets the remora in the Player's layer of collision, meaning it only hits enemy "stuff"
		tikTok = !tikTok;

	}


}
