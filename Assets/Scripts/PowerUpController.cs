using UnityEngine;
using System.Collections;

public class PowerUpController : MonoBehaviour {

	private GameObject particles;
	private AudioSource sound;
	void Start () {
		sound = GameObject.Find ("BubblesSound").GetComponent<AudioSource>();
		particles = (GameObject)Resources.Load ("Prefabs/BubbleExplosion");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			Instantiate (particles, transform.position, Quaternion.identity);
			sound.Play();
			Destroy(gameObject);
		}
	}
}
