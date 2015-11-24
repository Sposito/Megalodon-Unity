using UnityEngine;
using System.Collections;

public class BubblesOnTriiger2D : MonoBehaviour {

	public GameObject particles;
	public AudioSource sound;



	
	public int hits = 0;
	
	public bool boss;
	
	void Start () {
		particles = (GameObject)Resources.Load ("Prefabs/BubbleExplosion");
		sound = GameObject.Find ("BubblesSound").GetComponent<AudioSource>();

	}
	
	
	void Update () {

	}
	
	void OnTriggerExit2D(Collider2D other){
		//TODO float inputMagnitude = M
		if(other.name == "Player" /*&& inputMagnitude == 1f*/){

			Instantiate (particles, transform.position, Quaternion.identity);
			sound.Play();
			hits++;
		}
		
	}
}
