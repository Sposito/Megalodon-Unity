using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Exit(){
		Application.Quit ();
	}

	public void Restart(){
		SingletonController.bossTotalLife = 3;
		SingletonController.bossLife = 3;
		SingletonController.playerLife = 3;
		SingletonController.heartnemones [0].SetActive (true);
		SingletonController.heartnemones [1].SetActive (true);
		SingletonController.heartnemones [2].SetActive (true);

		Application.LoadLevel (0);



	}
}
