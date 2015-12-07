using UnityEngine;
using System.Collections;

public class PlayerTurtleController : MonoBehaviour {

	public float speed = .01f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0f) {
			transform.position = SingletonController.player.transform.position;
			transform.Rotate (0f, 0f, speed);

			if(transform.childCount == 0){
				Destroy(gameObject);
				SingletonController.playerTurtlePUP = false;
			}
		}

	}
}
