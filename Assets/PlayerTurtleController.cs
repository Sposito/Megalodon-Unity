using UnityEngine;
using System.Collections;

public class PlayerTurtleController : MonoBehaviour {

	public float speed = .01f;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = SingletonController.player.transform.position;
		transform.Rotate (0f, 0f, speed);
	}
}
