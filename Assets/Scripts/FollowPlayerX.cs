using UnityEngine;
using System.Collections;

public class FollowPlayerX : MonoBehaviour {
	[Range(0,15)]
	public float speed;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Mathf.Lerp (transform.position.x, SingletonController.player.transform.position.x, speed/100);
		transform.position = new Vector3 (x, transform.position.y);
	}
}
