using UnityEngine;
using System.Collections;

public class EnemyShooterController : MonoBehaviour {

	public bool remoraBool = true;

	GameObject gO;
	void Start () {
		if (remoraBool) {
			gO = (GameObject)Resources.Load("Prefabs/Remora");
				
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Shoot(){
		//Instantiate (gO,
	}
}
