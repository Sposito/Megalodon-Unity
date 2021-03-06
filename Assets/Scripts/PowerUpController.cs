﻿using UnityEngine;
using System.Collections;



public class PowerUpController : MonoBehaviour {

	private GameObject particles;
	private AudioSource sound;
	private PlayerController playerController;
	public enum pUPKINDS{turtle, scallop, eal}
	private pUPKINDS kind;

	public Sprite[] sprites = new Sprite[3];


	void Start () {
		sound = GameObject.Find ("BubblesSound").GetComponent<AudioSource>();
		particles = (GameObject)Resources.Load ("Prefabs/BubbleExplosion");
		playerController = SingletonController.player.GetComponent<PlayerController>();
	}

	public void SetSprite(pUPKINDS kinds){
		transform.GetChild (0).GetComponent<SpriteRenderer> ().sprite = sprites [(int)kinds];
		kind = kinds;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			Instantiate (particles, transform.position, Quaternion.identity);
			sound.Play();
			//playerController.turtleCount = 4;
			GameObject.Destroy(playerController.powerUp1);
			playerController.powerUp1 = (GameObject)Instantiate(Resources.Load("Prefabs/TurtlesPowerUp"),Vector3.zero,Quaternion.identity);
			

			}
			SingletonController.player.GetComponent<PlayerController>().turtleCount = 4;

			Destroy(gameObject);
		}

}
