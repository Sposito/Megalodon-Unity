using UnityEngine;
using System.Collections;

public class ReceiveDamage : MonoBehaviour {

	public GameObject particles;
	public AudioSource sound;

	public int hits = 0;

	public bool boss;

	void Start () {
		sound = GameObject.Find ("BubblesSound").GetComponent<AudioSource>();
	}
	

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Projectile")){
			print("Started!");
			Instantiate (particles, other.transform.position, Quaternion.identity);
			sound.Play();
			hits++;

			if (boss)
				SingletonController.bossLife -= 1f;

			Destroy (other.gameObject);
		}

	}
}
