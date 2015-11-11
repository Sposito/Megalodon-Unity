using UnityEngine;
using System.Collections;

public class ReceiveDamage : MonoBehaviour {

	public GameObject particles;
	public AudioSource sound;

	void Start () {
		sound = GameObject.Find ("BubblesSound").GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Projectile")){
			print("Started!");
			Instantiate (particles, other.transform.position, Quaternion.identity);
			sound.Play();
			Destroy (other.gameObject);
		}

	}
}
