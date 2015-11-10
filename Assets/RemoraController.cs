using UnityEngine;
using System.Collections;

public class RemoraController : MonoBehaviour {

	private GameObject[] remoraPool = new GameObject[6];
	public GameObject remoraPrefab;
	GameObject rFin;
	GameObject lFin;
	bool tikTok = false;


	// Use this for initialization
	void Start () {
		//CreateRemoras ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Space) ){
			Fire ();
		}

	
	}

	void Fire(){
		Vector3 position = tikTok ? transform.FindChild ("LeftFin").position : transform.FindChild ("RightFin").position;
		Instantiate(remoraPrefab, position, Quaternion.identity);
		tikTok = !tikTok;

	}


	/*
	private void Reload(){
		if (lFin == null) {
			if ( remoraPool[0] != null){
				remoraPool[0].SendMessage("Load");
				//lFin = 
			}
		}
	}
	/// <summary> Instatiate two lines of remoras in each side of the scene.</summary>
	private void CreateRemoras(){
		for (int i = 0; i < remoraPool.Length; i++) {
			remoraPool[i] = (GameObject)Instantiate(remoraPrefab, Vector3.zero,Quaternion.identity);
			if (i < 3){
				remoraPool[i].transform.position = new Vector3(-3f, -5.7f - (i * 2) );
			}
			else{
				remoraPool[i].transform.position = new Vector3(3f, -5.7f - ((i - 3) * 2f) );
			}

		}
	}
	*/
}
